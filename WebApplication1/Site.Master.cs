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
        // EndSession logs the user out.
        // side effects: mutates session variables
        protected void EndSession()
        {
            Session["loggedIn"] = false;
            Session["fname"] = null;
            Session["lname"] = null;
            Session["email"] = null;
        }

        // logoutButton_Click logs the user out when the corresponding button is clicked.
        // side effects: mutates session variables, redirects to another page
        protected void logoutButton_Click(object sender, EventArgs e)
        {
            EndSession();
            Response.Redirect("/Default");
        }

        // Page_Load decides which links to show on the navbar depending on login status.
        // side effects: mutates HTML attributes on the front end.
        protected void Page_Load(object sender, EventArgs e)
        {
            logoutButton.ServerClick += logoutButton_Click;
            if (Session["loggedIn"] != null && (bool)Session["loggedIn"] == true)
            {
                loginLink.Visible = false;
                registrationLink.Visible = false;
                downloadLink.Visible = true;
                logoutButton.Visible = true;
                welcomeMessage.Visible = true;

            }
            else
            {
                loginLink.Visible = true;
                registrationLink.Visible = true;
                logoutButton.Visible = false;
                welcomeMessage.Visible = false;
                downloadLink.Visible = false;

            }
        }
    }
}