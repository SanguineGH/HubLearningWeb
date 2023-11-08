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
                string query = "SELECT t.tid AS TransactionID, " +
                               "CASE WHEN b.role = 'Tutee' THEN u.name ELSE b.name END AS TutorName, " +
                               "CASE WHEN b.role = 'Tutor' THEN u.name ELSE b.name END AS TuteeName, " +
                               "b.subject AS Subject, " +
                               "b.strand AS Strand, " +
                               "b.yearlevel AS YearLevel, " +
                               "b.availability AS Availability, " +
                               "b.location AS Location " +
                               "FROM transaction t " +
                               "INNER JOIN bulletin b ON t.requestor = b.rid " +
                               "INNER JOIN users u ON t.client = u.uid " +
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
            
        }
    }
}