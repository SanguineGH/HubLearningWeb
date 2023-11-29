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
                if (Session["UID"] != null)
                {
                    string uid = Session["UID"].ToString();

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
            Button button = (Button)sender;
            string notificationID = button.CommandArgument;
        }

        protected void AcceptButton_Click(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Accept")
            {
                string notificationID = e.CommandArgument.ToString();

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

                            // Get current session user ID (assuming it's stored in Session["UID"])
                            int tutor = Convert.ToInt32(Session["UID"]);

                            reader.Close();

                            string insertQuery = "INSERT INTO transaction (requestor, client, tutor, progress, trandate) VALUES (@Requestor, @Client, @Tutor, @Progress, @TranDate)";
                            using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, connection))
                            {
                                insertCmd.Parameters.AddWithValue("@Requestor", requestor);
                                insertCmd.Parameters.AddWithValue("@Client", client);
                                insertCmd.Parameters.AddWithValue("@Tutor", tutor);
                                insertCmd.Parameters.AddWithValue("@Progress", "Ongoing");
                                insertCmd.Parameters.AddWithValue("@TranDate", DateTime.Now);

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

                string updateQuery = "UPDATE bulletin SET visibility = @Visibility WHERE rid = @RID";

                using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, connection))
                {
                    updateCmd.Parameters.AddWithValue("@Visibility", visibilityValue);
                    updateCmd.Parameters.AddWithValue("@RID", rid);

                    updateCmd.ExecuteNonQuery();
                }
            }
        }

        protected void RejectButton_Click(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Reject")
            {
                string notificationID = e.CommandArgument.ToString();
                RemoveNotification(notificationID);
                BindRepeater(Session["UID"].ToString());
            }
        }


    }
}