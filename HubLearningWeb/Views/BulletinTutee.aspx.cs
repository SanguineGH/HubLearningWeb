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
	public partial class BulletinTutee : System.Web.UI.Page
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

        private void BindDataToRepeater()
        {
            // Connect to the database and fetch the data
            string connectionString = "Server=localhost;Database=learninghubwebdb;User=root;Password=;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT name, looking, strand, subject, availability, location FROM bulletin WHERE UID";

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