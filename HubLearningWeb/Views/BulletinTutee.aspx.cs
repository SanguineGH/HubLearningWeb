using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
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

        protected void ConnectNow_Click(object sender, EventArgs e)
        {
            Button connectButton = (Button)sender;
            RepeaterItem item = (RepeaterItem)connectButton.NamingContainer;
            int rid = Convert.ToInt32((item.FindControl("HiddenRid") as HiddenField).Value);

            // Fetch UID from the session
            string uid = Session["UID"].ToString();

            // Check for confirmation
            if (!Page.ClientScript.IsStartupScriptRegistered("connectConfirmation"))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "connectConfirmation",
                    $"if (!showConnectConfirmation({rid})) return;", true);
            }

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

        protected void Submit_Click(object sender, EventArgs e)
        {
            BindDataToRepeater();
        }

        private void BindDataToRepeater()
        {
            // Connect to the database and fetch the data
            string connectionString = "Server=localhost;Database=learninghubwebdb;User=root;Password=;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Get the selected values for each filter
                string selectedStrand = GetSelectedRadioButton("strandGroup");
                string selectedYearLevel = GetSelectedRadioButton("yearLevelGroup");
                List<string> selectedAvailability = GetSelectedCheckboxes("availGroup");
                List<string> selectedLocations = GetSelectedCheckboxes("locGroup");

                // Start building the query
                string query = "SELECT rid, uid, name, looking, role, strand, subject, yearlevel, availability, location, visibility FROM bulletin WHERE looking = 'Tutee'";

                // Add filters to the query based on selected values
                if (!string.IsNullOrEmpty(selectedStrand))
                {
                    query += $" AND strand = '{selectedStrand}'";
                }

                if (!string.IsNullOrEmpty(selectedYearLevel))
                {
                    query += $" AND yearlevel = '{selectedYearLevel}'";
                }

                if (selectedAvailability.Count > 0)
                {
                    // Use the OR clause for multiple values
                    query += " AND (";
                    for (int i = 0; i < selectedAvailability.Count; i++)
                    {
                        query += $"availability LIKE '%{selectedAvailability[i]}%'";
                        if (i < selectedAvailability.Count - 1)
                        {
                            query += " OR ";
                        }
                    }
                    query += ")";
                }

                if (selectedLocations.Count > 0)
                {
                    // Use the OR clause for multiple values
                    query += " AND (";
                    for (int i = 0; i < selectedLocations.Count; i++)
                    {
                        query += $"location LIKE '%{selectedLocations[i]}%'";
                        if (i < selectedLocations.Count - 1)
                        {
                            query += " OR ";
                        }
                    }
                    query += ")";
                }

                query += " AND visibility = ''";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
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

        private string GetSelectedRadioButton(string groupName)
        {
            foreach (Control control in Page.Controls)
            {
                if (control is HtmlForm)
                {
                    foreach (Control formControl in control.Controls)
                    {
                        if (formControl is RadioButton && (formControl as RadioButton).GroupName == groupName && (formControl as RadioButton).Checked)
                        {
                            return (formControl as RadioButton).Text;
                        }
                    }
                }
            }

            return null;
        }

        private List<string> GetSelectedCheckboxes(string checkBoxGroupName)
        {
            List<string> selectedCheckboxes = new List<string>();

            foreach (Control control in Page.Controls)
            {
                if (control is HtmlForm)
                {
                    foreach (Control formControl in control.Controls)
                    {
                        if (formControl is CheckBox && (formControl as CheckBox).Attributes["Group"] == checkBoxGroupName && (formControl as CheckBox).Checked)
                        {
                            selectedCheckboxes.Add((formControl as CheckBox).Text);
                        }
                    }
                }
            }

            return selectedCheckboxes;
        }
        protected void Clear_Click(object sender, EventArgs e)
        {
            // Reset filters and bind the repeater to show all data
            ResetFilters();
            BindDataToRepeater();
        }

        // Add this method to reset filters
        private void ResetFilters()
        {
            // Clear selected radio buttons and checkboxes
            ClearRadioButtonGroup("strandGroup");
            ClearRadioButtonGroup("yearLevelGroup");
            ClearCheckboxes("availGroup");
            ClearCheckboxes("locGroup");
        }

        // Add these helper methods for resetting radio buttons and checkboxes
        private void ClearRadioButtonGroup(string groupName)
        {
            foreach (Control control in Page.Controls)
            {
                if (control is HtmlForm)
                {
                    foreach (Control formControl in control.Controls)
                    {
                        if (formControl is RadioButton && (formControl as RadioButton).GroupName == groupName)
                        {
                            (formControl as RadioButton).Checked = false;
                        }
                    }
                }
            }
        }

        private void ClearCheckboxes(string checkBoxGroupName)
        {
            foreach (Control control in Page.Controls)
            {
                if (control is HtmlForm)
                {
                    foreach (Control formControl in control.Controls)
                    {
                        if (formControl is CheckBox && (formControl as CheckBox).Attributes["Group"] == checkBoxGroupName)
                        {
                            (formControl as CheckBox).Checked = false;
                        }
                    }
                }
            }
        }

    }
}