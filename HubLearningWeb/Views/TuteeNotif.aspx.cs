using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Web.Security;

namespace HubLearningWeb.Views
{
    public partial class TuteeNotif : System.Web.UI.Page
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
                               "WHERE b.uid = @UID AND b.role = 'Tutee'";

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
            // You can use the notificationID to fetch additional details if needed.

            // Assuming you want to insert into the transaction table

            // Refresh the Repeater to reflect the changes
            BindRepeater(Session["UID"].ToString());
        }

        protected void AcceptButton_Click(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Accept")
            {
                string notificationID = e.CommandArgument.ToString();

                // Get details from the notification
                int frid = 0;
                string fridQueryString = "SELECT Frid FROM notification WHERE nid = @NotificationID";

                string connectionString = "Server=localhost;Database=learninghubwebdb;Uid=root;Pwd=;";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    using (MySqlCommand cmd = new MySqlCommand(fridQueryString, connection))
                    {
                        cmd.Parameters.AddWithValue("@NotificationID", notificationID);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                frid = reader.GetInt32("Frid");
                            }
                        }
                    }
                }
                InsertTransaction(notificationID);

                UpdateBulletinVisibility(frid, "Nada");

                RemoveNotification(notificationID);
              
                BindRepeater(Session["UID"].ToString());
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
        private void UpdateBulletinVisibility(int rid, string visibilityValue)
        {
            string connectionString = "Server=localhost;Database=learninghubwebdb;Uid=root;Pwd=;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Update the visibility column in the bulletin table
                string updateQuery = "UPDATE bulletin SET visibility = @Visibility WHERE rid = @RID";

                using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, connection))
                {
                    updateCmd.Parameters.AddWithValue("@Visibility", visibilityValue);
                    updateCmd.Parameters.AddWithValue("@RID", rid);

                    updateCmd.ExecuteNonQuery();
                }
            }
        }

    }
}