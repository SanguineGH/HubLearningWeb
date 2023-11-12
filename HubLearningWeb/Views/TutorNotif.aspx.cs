using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HubLearningWeb.Views
{
    public partial class TutorNotif : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check if the user is authenticated and has a session key (UID).
                if (Session["UID"] != null)
                {
                    string uid = Session["UID"].ToString();

                    // Fetch data from the database and bind it to the Repeater.
                    BindRepeater(uid);
                }
            }
        }

        protected void BindRepeater(string uid)
        {
            string connectionString = "Server=localhost;Database=learninghubwebdb;Uid=root;Pwd=;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT n.nid AS NotificationID, " +
                               "CASE WHEN b.role = 'Tutee' THEN u.name ELSE b.name END AS TutorName, " +
                               "CASE WHEN b.role = 'Tutor' THEN u.name ELSE b.name END AS TuteeName, " +
                               "b.strand AS Strand, " +
                               "b.yearlevel AS YearLevel, " +
                               "b.availability AS Availability, " +
                               "b.location AS Location " +
                               "FROM notification n " +
                               "INNER JOIN bulletin b ON n.Frid = b.rid " +
                               "INNER JOIN users u ON n.Fuid = u.uid " +
                               "WHERE b.uid = @UID AND b.role = 'Tutor'";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@UID", uid);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        transactionRepeater.DataSource = dt;
                        transactionRepeater.DataBind();
                    }
                }
            }
        }

        protected void ViewMore_Click(object sender, EventArgs e)
        {
            // Handle the button click event for "View More" here.
            // You can access the NotificationID using CommandArgument.
            // For example:
            Button button = (Button)sender;
            string notificationID = button.CommandArgument;
            // Add your code to handle the view more action.
        }

        protected void AcceptButton_Click(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Accept")
            {
                string notificationID = e.CommandArgument.ToString();
                InsertTransaction(notificationID);
                RemoveNotification(notificationID);
                BindRepeater(Session["UID"].ToString()); // Rebind the repeater to reflect the changes
            }
        }

        private void RemoveNotification(string notificationID)
        {
            string connectionString = "Server=localhost;Database=learninghubwebdb;Uid=root;Pwd=;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Remove the corresponding row from the notification table
                string removeQuery = "DELETE FROM notification WHERE nid = @NotificationID";
                using (MySqlCommand removeCmd = new MySqlCommand(removeQuery, connection))
                {
                    removeCmd.Parameters.AddWithValue("@NotificationID", notificationID);
                    removeCmd.ExecuteNonQuery();
                }
            }
        }

        private void InsertTransaction(string notificationID)
        {
            string connectionString = "Server=localhost;Database=learninghubwebdb;Uid=root;Pwd=;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Fetch details from the notification table
                string fetchDetailsQuery = "SELECT Frid, Fuid FROM notification WHERE nid = @NotificationID";

                using (MySqlCommand fetchCmd = new MySqlCommand(fetchDetailsQuery, connection))
                {
                    fetchCmd.Parameters.AddWithValue("@NotificationID", notificationID);

                    using (MySqlDataReader reader = fetchCmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int requestor = reader.GetInt32("Frid");
                            int client = reader.GetInt32("Fuid");

                            // Close the reader before executing the next command
                            reader.Close();

                            // Insert into the transaction table
                            string insertQuery = "INSERT INTO transaction (requestor, client, progress) VALUES (@Requestor, @Client, @Progress)";
                            using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, connection))
                            {
                                insertCmd.Parameters.AddWithValue("@Requestor", requestor);
                                insertCmd.Parameters.AddWithValue("@Client", client);
                                insertCmd.Parameters.AddWithValue("@Progress", "Ongoing"); // Adjust as needed
                                insertCmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
        }
    }
}