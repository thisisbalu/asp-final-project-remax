using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjFinalRemaxAspBalaSubramanyamLanka
{
    public partial class register : System.Web.UI.Page
    {

        String connectionString = ConfigurationManager.ConnectionStrings["RemaxDB"].ConnectionString;
        OleDbConnection dbConnection = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            // Checking if user is logged in or not
            Button loginButton = this.Master.FindControl("btnLogin") as Button;
            Button logoutButton = this.Master.FindControl("btnLogout") as Button;
            Button registerButton = this.Master.FindControl("btnRegister") as Button;
            Label lblUser = this.Master.FindControl("lblLoggedInUsername") as Label;
            if (Session["LoggedInUserID"] != null)
            {
                loginButton.Visible = false;
                logoutButton.Visible = true;
                registerButton.Visible = false;
                lblUser.Text = "Welcome " + Session["LoggedInUserFirstName"].ToString() + "!";
            }
            else
            {
                loginButton.Visible = true;
                logoutButton.Visible = false;
                registerButton.Visible = true;
                lblUser.Text = "";
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            dbConnection = new OleDbConnection(connectionString);
            dbConnection.Open();
            String firstName = inputFirstName.Text.Trim();
            String lastName = inputLastName.Text.Trim();
            String email = inputEmail.Text.Trim();
            String username = inputUsername.Text.Trim();
            String password = inputPassword.Text.Trim();
            String userRole = "BUYER";

            String sql = "select * from Users where Username = @paramUsername";
            OleDbCommand command = new OleDbCommand(sql, dbConnection);
            command.Parameters.AddWithValue("paramUsername", username);
            OleDbDataReader reader = command.ExecuteReader();

            if(reader.HasRows)
            {
                dbConnection.Close();
                lblError.Text = "User exists with the username provided, Please change username";
                return;
            }

            sql = "select * from Users where email = @paramEmail";
            command = new OleDbCommand(sql, dbConnection);
            command.Parameters.AddWithValue("paramEmail", email);
            reader = command.ExecuteReader();

            if(reader.HasRows)
            {
                dbConnection.Close();
                lblError.Text = "User exists with the email provided, Please change email";
                return;
            }

            sql = "insert into Users (FirstName, LastName, Email, Username, [Password], UserRole, ImageUrl) " +
                "values (@paramFName, @paramLName, @paramEmail, @paramUName, @paramPassword, @paramUserRole, @paramImage)";
            command = new OleDbCommand(sql, dbConnection);
            command.Parameters.AddWithValue("paramFName", firstName);
            command.Parameters.AddWithValue("paramLName", lastName);
            command.Parameters.AddWithValue("paramEmail", email);
            command.Parameters.AddWithValue("paramUName", username);
            command.Parameters.AddWithValue("paramPassword", password);
            command.Parameters.AddWithValue("paramUserRole", userRole);
            command.Parameters.AddWithValue("paramImage", "Images/Users/empty.jpg");
            command.ExecuteNonQuery();
            dbConnection.Close();
            Response.Redirect("login.aspx");
        }
    }
}