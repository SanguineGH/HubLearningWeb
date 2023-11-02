using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace HubLearningWeb.Views
{
    public partial class Account : System.Web.UI.Page
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

                    // Replace with your connection string
                    string connectionString = "Server=localhost;Database=learninghubwebdb;User=root;Password=;";

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
                                    // Retrieve data from the database and set it to the labels with additional text
                                    InfoName.Text = "Name: " + reader["name"].ToString();
                                    InfoStudId.Text = "Student ID: " + reader["studId"].ToString();
                                    InfoAge.Text = "Age: " + reader["age"].ToString();
                                    InfoSex.Text = "Sex: " + reader["sex"].ToString();
                                    InfoLocation.Text = "Location: " + reader["location"].ToString();
                                    InfoYearLvl.Text = "Year Level: " + reader["yearlevel"].ToString();
                                    ContactEmail.Text = "Email: " + reader["email"].ToString();
                                    ContactNumber.Text = "Contact Number: " + reader["contact"].ToString();
                                    ContactSocmed.Text = "Social Media: " + reader["socmed"].ToString();
                                    // Retrieve and display the bio
                                    BioTextarea.Text = reader["bio"].ToString();
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

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            // Get the new bio from the textarea
            string newBio = BioTextarea.Text;

            // Update the bio in the database
            UpdateBioInDatabase(newBio);

            // Retrieve the updated bio from the database
            string updatedBio = RetrieveBioFromDatabase();

            // Update the "ContactBio" label
            ContactBioLabel.Text = updatedBio;


        }

        private void UpdateBioInDatabase(string newBio)
        {
            // Connection string and SQL query to update the bio in the database
            string connectionString = "Server=localhost;Database=learninghubwebdb;User=root;Password=;";
            string query = "UPDATE users SET bio = @Bio WHERE uid = @UID";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Assuming you have a session variable named "UID" to identify the user
                    string uidValue = Session["UID"].ToString();

                    // Set the parameters
                    command.Parameters.AddWithValue("@Bio", newBio);
                    command.Parameters.AddWithValue("@UID", uidValue);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        private string RetrieveBioFromDatabase()
        {
            // Connection string and SQL query to retrieve the bio from the database
            string connectionString = "Server=localhost;Database=learninghubwebdb;User=root;Password=;";
            string query = "SELECT bio FROM users WHERE uid = @UID";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Assuming you have a session variable named "UID" to identify the user
                    string uidValue = Session["UID"].ToString();

                    // Set the parameter
                    command.Parameters.AddWithValue("@UID", uidValue);

                    connection.Open();

                    // Execute the query and return the bio
                    string bio = command.ExecuteScalar().ToString();

                    return bio;
                }
            }
        }
        protected void logout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
             Response.Redirect("Index.aspx");
        }

    }
}