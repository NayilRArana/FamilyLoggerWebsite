using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace FamilyLoggerWebsite
{
    public partial class SiteMaster : MasterPage
    {
        protected void EndSession()
        {
            Session["loggedIn"] = false;
            Session["fname"] = null;
            Session["lname"] = null;
            Session["email"] = null;
        }

        protected void logoutButton_Click(object sender, EventArgs e)
        {
            EndSession();
            Response.Redirect("/Default");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            logoutButton.ServerClick += logoutButton_Click;
            if (Session["loggedIn"] != null && (bool)Session["loggedIn"] == true)
            {
                loginLink.Visible = false;
                registrationLink.Visible = false;
                logoutButton.Visible = true;
                welcomeMessage.Visible = true;

            }
            else
            {
                loginLink.Visible = true;
                registrationLink.Visible = true;
                logoutButton.Visible = false;
                welcomeMessage.Visible = false;

            }
        }
    }
}