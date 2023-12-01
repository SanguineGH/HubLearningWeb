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

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT t.tid AS TransactionID, " +
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

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@UID", uid);

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
    }
}