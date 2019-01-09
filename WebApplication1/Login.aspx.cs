using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace FamilyLoggerWebsite
{
    public partial class Login : System.Web.UI.Page
    {
        // Page_Load may display a message following a successful registration.
        // Page_Load: object EventArgs -> None
        // side effects: May mutate an HTML element on the front-end.
        protected void Page_Load(object sender, EventArgs e)
        {
            LoginButton.Click += LoginButton_Click;
            if (Session["RegistrationSuccessful"]!= null && (bool)Session["RegistrationSuccessful"] == true)
            {
                registrationMessage.Text = ("Registration successful! Login here.");
            }
        }
        
        // BeginSession logs the user in and returns true if the user can be found. If not, it returns false.
        // BeginSession: None -> Bool
        // side effects: reads from a database and mutates session variables
        protected bool BeginSession()
        {
            using (SqlConnection con = new SqlConnection(@"Server=tcp:familylogger.database.windows.net,1433;Initial Catalog=FamilyLogger;Persist Security Info=False;User ID=floggeradmin;Password=Ambergris9;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                con.Open();
                SqlCommand getUserData = new SqlCommand("SELECT * FROM users WHERE email = @email AND password = @password", con);
                getUserData.Parameters.AddWithValue("email", emailBoxLogin.Text);
                getUserData.Parameters.AddWithValue("password", pwordBoxLogin.Text);
                SqlDataReader reader = getUserData.ExecuteReader();
                while (reader.Read())
                {
                    Session["loggedIn"] = true;
                    Session["fname"] = reader["fname"].ToString();
                    Session["lname"] = reader["lname"].ToString();
                    Session["email"] = reader["email"].ToString();
                }
                return (bool)Session["loggedIn"];
            }   
        }

        // LoginButton_Click logs the user in when the button is clicked and if their information can be found. If not, an error message is displayed.
        // LoginButton_Click: None -> None
        // side effects: mutates session variables, redirects, and/or mutates an HTML element on the front-end.
        protected void LoginButton_Click(object sender, EventArgs e)
        {
            Session["loggedIn"] = false;
            Session["fname"] = null;
            Session["lname"] = null;
            Session["email"] = null;
            if (BeginSession())
            {
                Response.Redirect("/Default");
            }
            else
            {
                LoginMessage.Text = "Email or password is incorrect.";
            }
            
        }
    }
}