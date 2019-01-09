using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations;

namespace FamilyLoggerWebsite
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterButton.Click += RegisterButton_Click;
        }

        // FnameBoxNotBlank returns false if the first name textbox on the front end is blank. Returns true otherwise.
        // FnameBoxNotBlank: None -> Bool
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

        // LnameBoxNotBlank returns false if the last name textbox on the front end is blank. Returns true otherwise.
        // LnameBoxNotBlank: None -> Bool
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

        // EmailBoxNotBlank returns false if the email textbox on the front end is blank. Returns true otherwise.
        // EmailBoxNotBlank: None -> Bool
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

        // PwordBoxNotBlank returns false if the password textbox on the front end is blank. Returns true otherwise.
        // PwordBoxNotBlank: None -> Bool
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

        // ConfirmPwordBoxNotBlank returns false if the confirm password textbox on the front end is blank. Returns true otherwise.
        // ConfirmPwordBoxNotBlank: None -> Bool
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

        // ConfirmIsEqualToPassword returns true if the values in the confirm password and password textboxes are equal. Returns false otherwise.
        // ConfirmIsEqualToPassword: None -> Bool
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

        // PasswordLengthIsRight returns true if the length of the value in the password box is between 5 and 20, not inclusive. Returns false otherwise.
        // PasswordLengthIsRight: None -> Bool
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

        // EmailIsValid returns true if the value in the email address textbox on the front end is valid.
        // EmailIsValid: None -> Bool
        // side effects: creates an instance of an object.
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

        // NotAlreadyRegistered returns true if the email address in the corresponding textbox cannot found in the database. Returns false otherwise.
        // NotAlreadyRegistered: None -> Bool
        // side effects: reads from the Azure database
        protected bool NotAlreadyRegistered()
        {
            using (SqlConnection con = new SqlConnection(@"Server=tcp:familylogger.database.windows.net,1433;Initial Catalog=FamilyLogger;Persist Security Info=False;User ID=floggeradmin;Password=Ambergris9;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
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

        // RegisterButton_Click checks that no field on the front end is left blank, the password is of an appropriate length, the confirm password box is equal to the
        //      password box, the email address is valid, and that the user is not already registered. If all of those conditions are satisfied, the user's information
        //      is pushed to the database. If not, all boxes are cleared and relevant error messages are displayed.
        // RegisterButton_Click: object EventArgs -> None
        // side effects: inserts values into the Azure database, mutates session variables, mutates HTML attribues on the front end, redirects to another page
        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Server=tcp:familylogger.database.windows.net,1433;Initial Catalog=FamilyLogger;Persist Security Info=False;User ID=floggeradmin;Password=Ambergris9;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
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