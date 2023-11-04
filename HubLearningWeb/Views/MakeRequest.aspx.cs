using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace HubLearningWeb.Views
{
    public partial class MakeRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check if the UID is set in the session
                if (Session["UID"] != null)
                {
                    // Retrieve the UID from the session
                    string uidValue = Session["UID"].ToString();

                    // Replace with your MySQL connection string
                    string connectionString = "Server=localhost;Database=learninghubwebdb;Uid=root;Pwd=;";

                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();

                        // Replace 'uidValue' with the actual UID you want to retrieve
                        uidValue = Session["UID"].ToString(); // Assuming the UID is stored in the session

                        string query = "SELECT name, yearlevel, age, email, contact, availability, sex, socmed, location, studId, bio FROM users WHERE uid = @UID";

                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@UID", uidValue);

                            using (MySqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    string nameValue = reader["name"].ToString();
                                    Name.Text = "Name: " + nameValue;
                                    SID.Text = "Student ID: " + reader["studId"].ToString();
                                    Email.Text = "Email: " + reader["email"].ToString();
                                    Contact.Text = "Contact Number: " + reader["contact"].ToString();
                                }
                            }
                        }
                    }
                }
                else
                {
                    // Handle the case where the session variable 'UID' is not set, which may indicate the user is not authenticated
                }
            }
        }

        protected void ReqSubmit_Click(object sender, EventArgs e)
        {
            // Get the UID from the session.
            string uid = Session["UID"].ToString();

            // Define your MySQL connection string.
            string connectionString = "Server=localhost;Database=learninghubwebdb;Uid=root;Pwd=;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Define the SQL query to insert data into the "bulletin" table.
                string query = "INSERT INTO bulletin (uid, name, looking, strand, subject, availability, location, role) " +
                    "VALUES (@uid, (SELECT name FROM users WHERE uid = @uid), @looking, @strand, @subject, @availability, @location, @role);";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Set the parameters for the MySQL query.
                    command.Parameters.AddWithValue("@uid", uid);

                    string lookingFor = (ReqTutee.Checked) ? "Tutee" : "Tutor";
                    command.Parameters.AddWithValue("@looking", lookingFor);

                    string strand = GetSelectedRadioValue(StrandRadios);
                    command.Parameters.AddWithValue("@strand", strand);

                    string subject = GetSelectedRadioValue(SubjectRadios);
                    command.Parameters.AddWithValue("@subject", subject);

                    // Availability checkboxes (assuming checkboxes are used):
                    string availability = string.Join(", ", new[] {
                        ReqSun.Checked ? "Sunday" : "",
                        ReqMon.Checked ? "Monday" : "",
                        ReqTues.Checked ? "Tuesday" : "",
                        ReqWed.Checked ? "Wednesday" : "",
                        ReqThur.Checked ? "Thursday" : "",
                        ReqFri.Checked ? "Friday" : "",
                        ReqSat.Checked ? "Saturday" : ""
                    }.Where(x => !string.IsNullOrEmpty(x)));

                    command.Parameters.AddWithValue("@availability", availability);

                    // Location checkboxes (assuming checkboxes are used):
                    string location = string.Join(", ", new[] {
                        ReqHome.Checked ? "Home" : "",
                        ReqSchool.Checked ? "School" : "",
                        ReqPublic.Checked ? "Public Place" : ""
                    }.Where(x => !string.IsNullOrEmpty(x)));

                    command.Parameters.AddWithValue("@location", location);

                    // Determine the "role" based on the "looking" value
                    string role = (lookingFor == "Tutee") ? "Tutor" : "Tutee";
                    command.Parameters.AddWithValue("@role", role);

                    // Execute the MySQL command to insert the data.
                    command.ExecuteNonQuery();
                }
            }

            // Reset the checkboxes and radio buttons to their initial state
            ReqTutee.Checked = false;
            ReqTutor.Checked = false;
            UncheckRadioButtons(StrandRadios);
            UncheckRadioButtons(SubjectRadios);
            ReqSun.Checked = false;
            ReqMon.Checked = false;
            ReqTues.Checked = false;
            ReqWed.Checked = false;
            ReqThur.Checked = false;
            ReqFri.Checked = false;
            ReqSat.Checked = false;
            ReqHome.Checked = false;
            ReqSchool.Checked = false;
            ReqPublic.Checked = false;

            // Redirect or display a success message.
            Response.Write("<script>alert('Success')</script>");
        }

        private void UncheckRadioButtons(Control container)
        {
            foreach (Control control in container.Controls)
            {
                if (control is RadioButton radioButton)
                {
                    radioButton.Checked = false;
                }
            }
        }

        private string GetSelectedRadioValue(Control container)
        {
            foreach (Control control in container.Controls)
            {
                if (control is RadioButton radioButton && radioButton.Checked)
                {
                    return radioButton.Text; // Change this to Value if necessary.
                }
            }

            // Default to an empty string if none are selected.
            return string.Empty;
        }
    }
}
