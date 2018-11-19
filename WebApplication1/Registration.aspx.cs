using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace WebApplication1
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterButton.Click += RegisterButton_Click;
        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Nayil\source\repos\WebApplication1\WebApplication1\App_Data\FLDatabase.mdf;Integrated Security=True"))
            {
                con.Open();
              
                SqlCommand cmd = new SqlCommand("INSERT INTO users values(@firstName, @lastName, @emailAddress, @password)", con);
                cmd.Parameters.AddWithValue("firstName", fnameBox.Text);
                cmd.Parameters.AddWithValue("lastName", lnameBox.Text);
                cmd.Parameters.AddWithValue("emailAddress", emailBox.Text);
                cmd.Parameters.AddWithValue("password", pwordBox.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                

                fnameBox.Text = "";
                lnameBox.Text = "";
                emailBox.Text = "";
                pwordBox.Text = "";
                confirmpwordBox.Text = "";
            }
        }
    }
}