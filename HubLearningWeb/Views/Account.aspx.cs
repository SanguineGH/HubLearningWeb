﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HubLearningWeb.Views
{
    public partial class Account : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void logout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
             Response.Redirect("Index.aspx");
        }
    }
}