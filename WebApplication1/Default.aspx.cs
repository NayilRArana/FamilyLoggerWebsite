using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loggedIn"] != null && (bool)Session["loggedIn"] == true)
            {
                loginButton.Visible = false;
                registrationButton.Visible = false;
            }
            else
            {
                loginButton.Visible = true;
                registrationButton.Visible = true;
            }
        }
    }
}