using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace FamilyLoggerWebsite
{
    public partial class Report : System.Web.UI.Page
    {
        protected string report;

        protected void checkLoginStatus()
        {
            if(Session["loggedIn"] == null || (bool)Session["loggedIn"] == false)
            {
                Response.Redirect("/Login.aspx");
            }
        }

        protected string readReport()
        {
            using (SqlConnection con = new SqlConnection(@"Server=tcp:familylogger.database.windows.net,1433;Initial Catalog=FamilyLogger;Persist Security Info=False;User ID=floggeradmin;Password=Ambergris9;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                try
                {
                    string report = null;
                    con.Open();
                    SqlCommand getReport = new SqlCommand("SELECT report FROM users WHERE email = @email", con);
                    getReport.Parameters.AddWithValue("email", (string)Session["email"]);
                    SqlDataReader reader = getReport.ExecuteReader();
                    if (reader.Read())
                    {
                        report = System.Text.Encoding.Default.GetString((byte[])reader[0]);
                    }
                    return report;
                }
                catch
                {
                    return "";
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            checkLoginStatus();
            report = readReport();

        }
    }
}