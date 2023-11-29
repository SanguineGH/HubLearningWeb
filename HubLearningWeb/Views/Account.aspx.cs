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
                if (Session["UID"] != null)
                {
                    string uidValue = Session["UID"].ToString();

                    string connectionString = "Server=localhost;Database=learninghubwebdb;User=root;Password=;";

                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();

                        string query = "SELECT name, yearlevel, age, email, contact, availability, sex, socmed, location, studId, bio, pfp FROM users WHERE uid = @UID";

                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@UID", uidValue);

                            using (MySqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    InfoName.Text = "Name: " + reader["name"].ToString();
                                    InfoStudId.Text = "Student ID: " + reader["studId"].ToString();
                                    InfoAge.Text = "Age: " + reader["age"].ToString();
                                    InfoSex.Text = "Sex: " + reader["sex"].ToString();
                                    InfoLocation.Text = "Location: " + reader["location"].ToString();
                                    InfoYearLvl.Text = "Year Level: " + reader["yearlevel"].ToString();
                                    ContactEmail.Text = "Email: " + reader["email"].ToString();
                                    ContactNumber.Text = "Contact Number: " + reader["contact"].ToString();
                                    ContactSocmed.Text = "Social Media: " + reader["socmed"].ToString();

                                    string profilePictureLink = reader["pfp"].ToString();
                                    ImagePF.ImageUrl = GetDirectLinkFromGoogleDrive(profilePictureLink);

                                    string userBio = reader["bio"].ToString();
                                    ContactBioLabel.Text = userBio;
                                }
                            }
                        }
                    }
                }
                else
                {

                }
            }

        }
        private string GetDirectLinkFromGoogleDrive(string googleDriveLink)
        {

            if (googleDriveLink.Contains("drive.google.com/file/d/"))
            {
                int start = googleDriveLink.IndexOf("drive.google.com/file/d/") + "drive.google.com/file/d/".Length;
                int end = googleDriveLink.IndexOf("/view");

                if (start != -1 && end != -1)
                {
                    string fileId = googleDriveLink.Substring(start, end - start);

                    return $"https://drive.google.com/uc?export=view&id={fileId}";
                }
            }

            return googleDriveLink;
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            string newBio = BioTextarea.Text;

            UpdateBioInDatabase(newBio);

            string updatedBio = RetrieveBioFromDatabase();

            ContactBioLabel.Text = updatedBio;


        }

        private void UpdateBioInDatabase(string newBio)
        {
            string connectionString = "Server=localhost;Database=learninghubwebdb;User=root;Password=;";
            string query = "UPDATE users SET bio = @Bio WHERE uid = @UID";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    string uidValue = Session["UID"].ToString();

                    command.Parameters.AddWithValue("@Bio", newBio);
                    command.Parameters.AddWithValue("@UID", uidValue);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        private string RetrieveBioFromDatabase()
        {
            string connectionString = "Server=localhost;Database=learninghubwebdb;User=root;Password=;";
            string query = "SELECT bio FROM users WHERE uid = @UID";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    string uidValue = Session["UID"].ToString();

                    command.Parameters.AddWithValue("@UID", uidValue);

                    connection.Open();

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