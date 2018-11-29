using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterButton.Click += RegisterButton_Click;
        }

        protected bool FnameBoxNotBlank()
        {
            if (fnameBox.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        protected bool LnameBoxNotBlank()
        {
            if (lnameBox.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        protected bool EmailBoxNotBlank()
        {
            if (emailBox.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        protected bool PwordBoxNotBlank()
        {
            if (pwordBox.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        protected bool ConfirmPwordBoxNotBlank()
        {
            if (confirmpwordBox.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        protected bool ConfirmIsEqualToPassword()
        {
            if (confirmpwordBox.Text == pwordBox.Text)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected bool PasswordLengthIsRight()
        {
            if ((pwordBox.Text.Length > 5) && (pwordBox.Text.Length < 20))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected bool EmailIsValid()
        {
            if (new EmailAddressAttribute().IsValid(emailBox.Text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected bool NotAlreadyRegistered()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Nayil\source\repos\WebApplication1\WebApplication1\App_Data\FLDatabase.mdf;Integrated Security=True"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM users WHERE email = @email", con);

                cmd.Parameters.AddWithValue("email", emailBox.Text);
                int rowCount = (int)cmd.ExecuteScalar();
                if (rowCount < 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }
        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Nayil\source\repos\WebApplication1\WebApplication1\App_Data\FLDatabase.mdf;Integrated Security=True"))
            {
                if (FnameBoxNotBlank() && LnameBoxNotBlank() && EmailBoxNotBlank() && PwordBoxNotBlank()
                    && ConfirmPwordBoxNotBlank() && ConfirmIsEqualToPassword() && PasswordLengthIsRight() && EmailIsValid() && NotAlreadyRegistered())
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO users values(@firstName, @lastName, @emailAddress, @password)", con);
                    cmd.Parameters.AddWithValue("firstName", fnameBox.Text);
                    cmd.Parameters.AddWithValue("lastName", lnameBox.Text);
                    cmd.Parameters.AddWithValue("emailAddress", emailBox.Text);
                    cmd.Parameters.AddWithValue("password", pwordBox.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Session["RegistrationSuccessful"] = true;
                    Server.Transfer("Login.aspx");
                }
                else
                {
                    fnameError.Text = "";
                    lnameError.Text = "";
                    emailError.Text = "";
                    pwordError.Text = "";
                    confirmpwordError.Text = "";
                    if (!FnameBoxNotBlank())
                    {
                        fnameError.Text = fnameError.Text + "Field must not be blank.";
                    }
                    if (!LnameBoxNotBlank())
                    {
                        lnameError.Text = lnameError.Text + "Field must not be blank.";
                    }
                    if (!EmailBoxNotBlank())
                    {
                        emailError.Text = emailError.Text + "Field must not be blank.";
                    }
                    if (!PwordBoxNotBlank())
                    {
                        pwordError.Text = pwordError.Text + "Field must not be blank.";
                    }
                    if (!ConfirmPwordBoxNotBlank())
                    {
                        confirmpwordError.Text = confirmpwordError.Text + "Field must not be blank.";
                    }
                    if (!ConfirmIsEqualToPassword() && ConfirmPwordBoxNotBlank())
                    {
                        confirmpwordError.Text = confirmpwordError.Text + "Confirm Password must be equal to Password.";
                    }
                    if (!PasswordLengthIsRight() && PwordBoxNotBlank())
                    {
                        pwordError.Text = pwordError.Text + "Password length must be greater than 5, less than 20.";
                    }
                    if (!EmailIsValid() && EmailBoxNotBlank())
                    {
                        emailError.Text = emailError.Text + "Email address must be valid.";
                    }
                    if (!NotAlreadyRegistered())
                    {
                        emailError.Text = emailError.Text + "You are already registered.";
                    }
                }
            }
        }
    }
}