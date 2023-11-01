using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;

namespace HubLearningWeb.Views
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            string username = Request.Form.Get("Username");
            string password = Request.Form.Get("Password");
            string mycon = "server=localhost;Uid=root;password=;persistsecurityinfo=True;database=learninghubwebdb;SslMode=none";
            MySqlConnection con = new MySqlConnection(mycon);
            MySqlCommand cmd = null;

            try
            {
                con.Open();
                cmd = new MySqlCommand("SELECT password, UID FROM users WHERE studId = @a1", con);
                cmd.Parameters.AddWithValue("@a1", username);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string storedPassword = reader["password"].ToString();
                        string uid = reader["UID"].ToString(); // Retrieve the UID

                        if (storedPassword == password)
                        {
                            // Passwords match, so authentication is successful.

                            // Set the UID as a session variable
                            Session["UID"] = uid;

                            Response.Write("<script>alert('Login successful')</script>");
                            Response.Redirect("Dashboard.aspx");
                        }
                        else
                        {
                            // Passwords don't match, show an error message.
                            Response.Write("<script>alert('Incorrect password')</script>");
                        }
                    }
                    else
                    {
                        // Username not found in the database.
                        Response.Write("<script>alert('Username not found')</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
            finally
            {
                con.Close();
            }
        }
    }
}