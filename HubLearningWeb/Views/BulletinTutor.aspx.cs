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
    public partial class BulletinTutor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check if the UID is set in the session
                if (Session["UID"] != null)
                {
                    string uidValue = Session["UID"].ToString();
                    BindDataToRepeater();
                }
                else
                {
                    // Handle the case where the session variable 'UID' is not set, which may indicate the user is not authenticated
                }
            }
        }

        protected void ConnectNow_Click(object sender, EventArgs e)
        {
            Button connectButton = (Button)sender;
            RepeaterItem item = (RepeaterItem)connectButton.NamingContainer;
            int rid = Convert.ToInt32((item.FindControl("HiddenRid") as HiddenField).Value);

            // Fetch UID from the session
            string uid = Session["UID"].ToString();

            // Connect to the database and insert values into the notification table
            string connectionString = "Server=localhost;Database=learninghubwebdb;User=root;Password=;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO notification (Fuid, Frid) VALUES (@Fuid, @Frid)";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Fuid", uid);
                    command.Parameters.AddWithValue("@Frid", rid);

                    command.ExecuteNonQuery();
                }
            }

            // You can add any additional logic or redirection after the connection is made

        }

        private void BindDataToRepeater()
        {
            // Connect to the database and fetch the data
            string connectionString = "Server=localhost;Database=learninghubwebdb;User=root;Password=;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT rid, name, looking, strand, subject, availability, location FROM bulletin WHERE looking = 'Tutor' AND visibility = ''";

                // Replace 'uidValue' with the actual UID you want to retrieve
                string uidValue = Session["UID"].ToString();

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UID", uidValue);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        CardRepeater.DataSource = dataTable;
                        CardRepeater.DataBind();
                    }
                }
            }
        }
    }
}