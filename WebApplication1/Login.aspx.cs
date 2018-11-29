﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoginButton.Click += LoginButton_Click;
            if (Session["RegistrationSuccessful"]!= null && (bool)Session["RegistrationSuccessful"] == true)
            {
                registrationMessage.Text = ("Registration successful! Login here.");
            }
        }

        protected bool LoginSuccessful()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Nayil\source\repos\WebApplication1\WebApplication1\App_Data\FLDatabase.mdf;Integrated Security=True"))
            {
                con.Open();
                SqlCommand matchCount = new SqlCommand("SELECT COUNT(*) FROM users WHERE email = @email AND password = @password", con);
                matchCount.Parameters.AddWithValue("email", emailBoxLogin.Text);
                matchCount.Parameters.AddWithValue("password", pwordBoxLogin.Text);
                
                int rowCount = (int)matchCount.ExecuteScalar();
                if (rowCount < 1)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
        }

        protected void BeginSession()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Nayil\source\repos\WebApplication1\WebApplication1\App_Data\FLDatabase.mdf;Integrated Security=True"))
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
            }   
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            if (LoginSuccessful())
            {
                BeginSession();
                Response.Redirect("/Default");
            }
            else
            {
                LoginMessage.Text = "Email or password is incorrect.";
            }
            
        }
    }
}