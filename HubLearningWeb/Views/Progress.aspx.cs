using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Web.UI.HtmlControls;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using System.IO;
using iText.Layout;


namespace HubLearningWeb.Views
{
    public partial class Progress : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check if Session["UID"] is null
                if (Session["UID"] == null)
                {
                    // Redirect to the login page or take appropriate action
                    Response.Redirect("Login.aspx"); // Adjust the URL accordingly
                    return;
                }

                BindProgressGridView();
            }
        }

        protected void BindProgressGridView()
        {
            string connectionString = "Server=localhost;Database=learninghubwebdb;Uid=root;Pwd=;";
            string uid = Session["UID"].ToString();
            int sessionKey = Convert.ToInt32(Session["SessionKey"]);

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query;

                if (sessionKey == 1)
                {
                    // If the session key is 1, retrieve all entries
                    query = "SELECT t.tid AS TransactionID, " +
                            "CASE WHEN b.role = 'Tutor' THEN ut.name ELSE tutor.name END AS TuteeName, " +
                            "CASE WHEN b.role = 'Tutee' THEN ut.name ELSE tutor.name END AS TutorName, " +
                            "CASE WHEN b.role = 'Tutor' THEN ut.studid ELSE tutor.studid END AS TuteeStudentID, " +
                            "CASE WHEN b.role = 'Tutee' THEN ut.studid ELSE tutor.studid END AS TutorStudentID, " +
                            "b.yearlevel AS TuteeYearLevel, b.strand AS TuteeStrand, " +
                            "b.availability AS TutorAvailability, b.location AS TutorLocation, " +
                            "t.days, " + // Include the 'days' column
                            "t.progress " +
                            "FROM transaction t " +
                            "INNER JOIN bulletin b ON t.requestor = b.rid OR t.client = b.rid " +
                            "INNER JOIN users ut ON t.client = ut.uid " +
                            "LEFT JOIN users tutor ON b.uid = tutor.uid";
                }
                else
                {
                    // If the session key is not 1, retrieve entries related to the user
                    query = "SELECT t.tid AS TransactionID, " +
                            "CASE WHEN b.role = 'Tutor' THEN ut.name ELSE tutor.name END AS TuteeName, " +
                            "CASE WHEN b.role = 'Tutee' THEN ut.name ELSE tutor.name END AS TutorName, " +
                            "CASE WHEN b.role = 'Tutor' THEN ut.studid ELSE tutor.studid END AS TuteeStudentID, " +
                            "CASE WHEN b.role = 'Tutee' THEN ut.studid ELSE tutor.studid END AS TutorStudentID, " +
                            "b.yearlevel AS TuteeYearLevel, b.strand AS TuteeStrand, " +
                            "b.availability AS TutorAvailability, b.location AS TutorLocation, " +
                            "t.days, " + // Include the 'days' column
                            "t.progress " +
                            "FROM transaction t " +
                            "INNER JOIN bulletin b ON t.requestor = b.rid OR t.client = b.rid " +
                            "INNER JOIN users ut ON t.client = ut.uid " +
                            "LEFT JOIN users tutor ON b.uid = tutor.uid " +
                            "WHERE b.uid = @UID OR t.requestor = @UID OR t.client = @UID";
                }

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    if (sessionKey != 1)
                    {
                        cmd.Parameters.AddWithValue("@UID", uid);
                    }

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        foreach (DataRow row in dt.Rows)
                        {
                            // Set the progress directly in the "Days" column
                            row.SetField("days", $"{row["days"]}/14");
                        }

                        progressGridView.DataSource = dt;
                        progressGridView.DataBind();
                    }
                }
            }
        }

        private string GetStudentIDByRID(string rid, string role)
        {
            string connectionString = "Server=localhost;Database=learninghubwebdb;Uid=root;Pwd=;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string columnName = role.ToLower() == "tutee" ? "requestor" : "client";
                string query = $"SELECT studid FROM users WHERE uid = (SELECT {columnName} FROM transaction WHERE tid = @RID)";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@RID", rid);
                    return cmd.ExecuteScalar()?.ToString();
                }
            }
        }

        private string GetStudentNameByStudentID(string studentID)
        {
            string connectionString = "Server=localhost;Database=learninghubwebdb;Uid=root;Pwd=;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT name FROM users WHERE studid = @StudentID";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@StudentID", studentID);
                    return cmd.ExecuteScalar()?.ToString();
                }
            }
        }

        protected void progressGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "MoreCommand")
            {
                // Access the server-side div
                HtmlGenericControl additionalContent = (HtmlGenericControl)FindControl("additionalContent");

                // Implement the logic you want when the "More" button is clicked.
                // For example, you can show additional content, load data, etc.

                // For demonstration purposes, let's toggle the display style.
                additionalContent.Style["display"] = additionalContent.Style["display"] == "none" ? "block" : "none";
            }
            if (e.CommandName == "CompleteCommand")
            {
                // Find the button that was clicked
                Button btnComplete = (Button)e.CommandSource;

                // Find the row that contains the button
                GridViewRow row = (GridViewRow)btnComplete.NamingContainer;

                // Get the row index
                int rowIndex = row.RowIndex;

                if (rowIndex >= 0 && rowIndex < progressGridView.Rows.Count)
                {
                    string tid = progressGridView.DataKeys[rowIndex]["TransactionID"].ToString();
                    UpdateProgressToComplete(tid);

                    // Rebind the GridView to reflect the changes
                    BindProgressGridView();
                }
            }
        }

        protected void UpdateProgressToComplete(string tid)
        {
            string connectionString = "Server=localhost;Database=learninghubwebdb;Uid=root;Pwd=;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string updateQuery = "UPDATE transaction SET progress = 'Complete' WHERE tid = @TID";

                using (MySqlCommand cmd = new MySqlCommand(updateQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@TID", tid);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        protected void Details_Click(object sender, EventArgs e)
        {
            // Get the clicked button's command argument (day information)
            Button clickedButton = (Button)sender;
            string dayInformation = clickedButton.CommandArgument;

            // Find and display the hidediv
            HtmlGenericControl hidediv = (HtmlGenericControl)FindControl("hidediv");
            hidediv.Style["display"] = "block";

            // Update the top middle label with the day information
            Label lblTopMiddle = (Label)hidediv.FindControl("lblTopMiddle");
            if (lblTopMiddle != null)
            {
                lblTopMiddle.Text = dayInformation;
            }
        }

        protected void GeneratePDF_Click(object sender, EventArgs e)
        {
            // Create a MemoryStream to hold the PDF
            using (MemoryStream ms = new MemoryStream())
            {
                // Create a PdfWriter instance
                using (PdfWriter writer = new PdfWriter(ms))
                {
                    // Create a PdfDocument instance
                    using (var pdf = new PdfDocument(writer))
                    {
                        // Create a Document instance
                        using (var document = new Document(pdf))
                        {
                            // Add content to the document
                            document.Add(new Paragraph($"Transaction Progress Report ({DateTime.Now})").SetBold());

                            // Add GridView content to the document
                            AddGridViewToDocument(document);

                            // Save the document
                            document.Close();
                        }
                    }
                }

                // Save the PDF to the response stream
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=TransactionReport.pdf");
                Response.OutputStream.Write(ms.ToArray(), 0, ms.ToArray().Length);
            }
        }

        private void AddGridViewToDocument(Document document)
        {
            // Iterate through GridView rows and add content to the document
            foreach (GridViewRow row in progressGridView.Rows)
            {
                // Extract data from GridView row
                var transactionID = row.Cells[0].Text;
                var tuteeName = row.Cells[1].Text;
                var tutorName = row.Cells[3].Text;
                var tutorStudentID = row.Cells[4].Text;
                var tuteeStudentID = row.Cells[2].Text;
                var strand = row.Cells[6].Text;
                var yearLevel = row.Cells[5].Text;
                var availabilities = row.Cells[7].Text;
                var location = row.Cells[8].Text;
                var days = row.Cells[9].Text;
                var progress = row.Cells[10].Text;
                var transactionDate = GetTransactionDate(transactionID); // Assuming you have a method to get the date

                // Add data to the document in the specified format
                var formattedData = $"Transaction ID: {transactionID} - Tutor Name: {tutorName} - Tutor StudentID: {tutorStudentID} - " +
                                    $"Tutee Name: {tuteeName} - Tutee StudentID: {tuteeStudentID} - Strand: {strand} - " +
                                    $"Year Level: {yearLevel} - Availabilities: {availabilities} - Location: {location} - " +
                                    $"Days: {days} - Progress: {progress} - Date: {transactionDate}";

                document.Add(new Paragraph(formattedData).SetBold());
            }
        }

        private string GetTransactionDate(string transactionID)
        {
            string connectionString = "Server=localhost;Database=learninghubwebdb;Uid=root;Pwd=;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT trandate FROM transaction WHERE tid = @TransactionID";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@TransactionID", transactionID);

                    object result = cmd.ExecuteScalar();

                    // Check if the result is DBNull.Value before converting to string
                    return result != DBNull.Value ? Convert.ToDateTime(result).ToString("yyyy-MM-dd") : string.Empty;
                }
            }
        }

    }
}