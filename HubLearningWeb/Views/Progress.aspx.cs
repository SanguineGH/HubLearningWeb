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
using System.Security.Cryptography;
using System.Diagnostics;

namespace HubLearningWeb.Views
{
    public partial class Progress : System.Web.UI.Page
    {
        private string tid
        {
            get { return ViewState["TransactionID"] as string; }
            set { ViewState["TransactionID"] = value; }
        }
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

                string userRole = GetUserRole(Session["UID"].ToString());

                // Disable or hide the Edit and Complete buttons if the user is in the Tutee role
                if (userRole == "Tutee")
                {
                    btnEdit.Style["display"] = "none"; // Hide the edit button
                    btnComplete.Style["display"] = "none"; // Hide the complete button
                }

                // Try to get TransactionID from the query string
                tid = Request.QueryString["TransactionID"];

                BindProgressGridView();
            }
        }

        private string GetUserRole(string uid)
        {
            string userRole = "";
            string connectionString = "Server=localhost;Database=learninghubwebdb;Uid=root;Pwd=;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT role FROM bulletin WHERE uid = @UID";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@UID", uid);

                    // Execute the query to fetch the role
                    object result = cmd.ExecuteScalar();

                    // Check if a role is retrieved
                    if (result != null && result != DBNull.Value)
                    {
                        userRole = result.ToString();
                    }
                }
            }

            return userRole;
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
                // Extract the TransactionID from the CommandArgument
                tid = e.CommandArgument.ToString();

                ScriptManager.RegisterStartupScript(this, GetType(), "ShowTransactionID", $"console.log('TransactionID: {tid}');", true);

                // Your additional logic here based on the tid...
                // For example, showing/hiding elements, performing actions, etc.
                            hidediv.Style["display"] = "none";

            // Reset lblTopMiddle and lblCenter text
            lblTopMiddle.Text = "";
            lblCenter.Text = "";
                HtmlGenericControl additionalContent = (HtmlGenericControl)FindControl("additionalContent");
                if (additionalContent != null)
                {
                    additionalContent.Style["display"] = additionalContent.Style["display"] == "none" ? "block" : "none";
                }
            }
        }
        protected void progressGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hfRowIndex = (HiddenField)e.Row.FindControl("hfRowIndex");
                hfRowIndex.Value = e.Row.RowIndex.ToString();
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
            ScriptManager.RegisterStartupScript(this, GetType(), "ShowTransactionID", $"console.log('TransactionID: {tid}');", true);
            // Get the clicked button's command argument (day information)
            Button clickedButton = (Button)sender;
            string dayInformation = clickedButton.CommandArgument;

            // Find and display the hidediv
            HtmlGenericControl hidediv = (HtmlGenericControl)FindControl("hidediv");
            hidediv.Style["display"] = "block";

            CenterTextarea.Text = "";

            // Update the top middle label with the day information
            Label lblTopMiddle = (Label)hidediv.FindControl("lblTopMiddle");
            if (lblTopMiddle != null)
            {
                lblTopMiddle.Text = dayInformation;
            }

            // Check if tid has a valid value
            if (!string.IsNullOrEmpty(tid))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ConsoleLogDetailsClick",
                    "console.log('Details_Click triggered.');", true);
                // Extract the button number from the button ID (assuming btnDetailsX format)
                string buttonNumber = ((Button)sender).ID.Replace("btnDetails", "");

                // Construct the column name based on the button number (e.g., "Day1")
                string columnName = "day" + buttonNumber;

                ViewState["SelectedColumnName"] = columnName;
                ViewState["SelectedTID"] = tid;
                // Call the method directly without storing the result in a variable
                RetrieveDayDetailsFromDatabase(tid, columnName);

                // Show the lblCenter and hide the edit form
                lblCenter.Visible = true;
                editCenterForm.Style["display"] = "none";

                string columnValue = RetrieveDayDetailsFromDatabase(tid, columnName);

                bool isColumnEmpty = string.IsNullOrEmpty(columnValue);
                btnComplete.Visible = isColumnEmpty;
                btnEdit.Visible = isColumnEmpty;

            }
        }

        private string RetrieveDayDetailsFromDatabase(string tid, string columnName)
        {
            try
            {
                string connectionString = "Server=localhost;Database=learninghubwebdb;Uid=root;Pwd=;";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Construct the query to retrieve data from the specified column
                    string query = $"SELECT {columnName} FROM learning WHERE tid = @TID";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@TID", tid);

                        // Debugging: Output the constructed query to the console
                        ScriptManager.RegisterStartupScript(this, GetType(), "ConsoleLogRetrieveDay",
                            "console.log('Retrieve Day triggered.');", true);

                        // Debugging: Output the parameter values to the console
                        foreach (MySqlParameter parameter in cmd.Parameters)
                        {
                            Console.WriteLine($"Parameter {parameter.ParameterName}: {parameter.Value}");
                        }

                        // Attempt to execute the query and retrieve the data
                        object result = cmd.ExecuteScalar();

                        // Debugging: Output the result to the console
                        Console.WriteLine($"Result: {result}");

                        if (result != null)
                        {
                            // If there is a result, set the retrieved day details in lblCenter label
                            lblCenter.Text = result.ToString();

                            // Show the lblCenter and hide the edit form
                            lblCenter.Visible = true;
                            editCenterForm.Style["display"] = "none";
                        }
                        else
                        {
                            // If there is no result, log a message to the console
                            Console.WriteLine("No data found for the specified parameters.");
                        }

                        // Return the result
                        return result?.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                // Log any exceptions to the console
                Console.WriteLine($"Exception: {ex.Message}");
                return null;
            }
        }
        protected void Edit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ViewState["SelectedColumnName"] as string) && !string.IsNullOrEmpty(ViewState["SelectedTID"] as string))
            {
                // Retrieve the column name and transaction ID
                string columnName = ViewState["SelectedColumnName"].ToString();
                string tid = ViewState["SelectedTID"].ToString();

                // Check the specific column value in the learning table
                string columnValue = RetrieveDayDetailsFromDatabase(tid, columnName);

                // If the column has a value, hide the btnComplete; otherwise, show it
                btnEdit.Visible = string.IsNullOrEmpty(columnValue);

            }
        }
        protected void Save_Click(object sender, EventArgs e)
        {
            string columnName = ViewState["SelectedColumnName"] as string;
            string tid = ViewState["SelectedTID"] as string;

            // Get the text from the textarea
            string newText = CenterTextarea.Text.Trim(); // Trim to remove extra spaces

            if (string.IsNullOrEmpty(newText))
            {
                // Show an alert indicating the textarea is empty
                ScriptManager.RegisterStartupScript(this, GetType(), "EmptyTextareaAlert", "alert('Text Area is empty. The details will not be saved.');", true);
                return; // Halt the method if the textarea is empty
            }

            if (!string.IsNullOrEmpty(columnName) && !string.IsNullOrEmpty(tid))
            {
                // Update the database with the new text
                UpdateDayDetailsInDatabase(tid, columnName, newText);

                // Reset the textarea after successful update
                CenterTextarea.Text = "";
            }
        }
        private void UpdateDayDetailsInDatabase(string tid, string columnName, string newText)
        {
            try
            {
                string connectionString = "Server=localhost;Database=learninghubwebdb;Uid=root;Pwd=;";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Construct the update query for the specific column
                    string query = $"UPDATE learning SET {columnName} = @NewText WHERE tid = @TID";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@NewText", newText);
                        cmd.Parameters.AddWithValue("@TID", tid);

                        // Execute the update query
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Update successful
                            // You might want to show a success message or handle accordingly
                            lblCenter.Text = newText;
                        }
                        else
                        {
                            // Update failed
                            // Handle failure case or show error message
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                // Log or display error message
            }
        }
        protected void Close_Click(object sender, EventArgs e)
        {
            // Hide additional content and hidedivclass
            additionalContent.Style["display"] = "none";
            hidediv.Style["display"] = "none";

            // Reset lblTopMiddle and lblCenter text
            lblTopMiddle.Text = "";
            lblCenter.Text = "";

        }
        protected void Complete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ViewState["SelectedColumnName"] as string) && !string.IsNullOrEmpty(ViewState["SelectedTID"] as string))
            {
                // Retrieve the column name and transaction ID
                string columnName = ViewState["SelectedColumnName"].ToString();
                string tid = ViewState["SelectedTID"].ToString();

                // Check the specific column value in the learning table
                string columnValue = RetrieveDayDetailsFromDatabase(tid, columnName);

                // If the column has a value, hide the btnComplete; otherwise, show it
                btnComplete.Visible = string.IsNullOrEmpty(columnValue);
                btnEdit.Visible = string.IsNullOrEmpty(columnValue);
            }
        }
    }
}