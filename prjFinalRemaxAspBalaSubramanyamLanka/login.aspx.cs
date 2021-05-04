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
    public partial class login : System.Web.UI.Page
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

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            dbConnection = new OleDbConnection(connectionString);
            dbConnection.Open();
            String username = inputUsername.Text.Trim();
            String password = inputPassword.Text.Trim();
            String sql = "select * from Users where Username = @paramUsername and [Password] = @paramPassword";
            OleDbCommand command = new OleDbCommand(sql, dbConnection);
            command.Parameters.AddWithValue("paramUsername", username);
            command.Parameters.AddWithValue("paramPassword", password);
            OleDbDataReader reader = command.ExecuteReader();
            if (reader.HasRows) 
            {
                reader.Read();
                Session["LoggedInUserID"] = Convert.ToInt32(reader["RefUser"].ToString());
                Session["LoggedInUserFirstName"] = reader["FirstName"].ToString();
                Session["LoggedInUserLastName"] = reader["LastName"].ToString();
                Session["LoggedInUserEmail"] = reader["Email"].ToString();
                dbConnection.Close();
                Response.Redirect("index.aspx");
            } else
            {
                lblError.Text = "Username and/or Password Invalid. Please try again!";
            }
            dbConnection.Close();
        }
    }
}