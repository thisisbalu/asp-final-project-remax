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
    public partial class house : System.Web.UI.Page
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
                lblSendMessageTitle.Text = "Please login to send a message to agent!";
                txtSubject.Visible = false;
                txtMessage.Visible = false;
                btnSend.Visible = false;
            }

            // Checking the request parameter MLS
            if (Request.QueryString["MLS"] != null) {
                string mls = Request.QueryString["MLS"].ToString();
                int propertyReference = -1;
                dbConnection = new OleDbConnection(connectionString);
                dbConnection.Open();
                // Reading Property from MLS value
                String sql = "select * from Properties where MLS = @paramMLS";
                OleDbCommand command = new OleDbCommand(sql, dbConnection);
                command.Parameters.AddWithValue("paramMLS", mls);
                OleDbDataReader reader = command.ExecuteReader();
                if(reader.Read())
                {
                    lblAddress.Text = reader["Address"].ToString();
                    lblCityProvince.Text = reader["City"].ToString() + ", " + reader["Province"].ToString() + ", " + reader["PostalCode"].ToString();
                    lblAbout.Text = reader["About"].ToString().Substring(0, 250);
                    lblPrice.Text = "$ " + reader["Price"].ToString();
                    lblBeds.Text = reader["BedRooms"].ToString();
                    lblBaths.Text = reader["BathRooms"].ToString();
                    lblSqFtArea.Text = reader["SqFtArea"].ToString();
                    lblMLS.Text = reader["MLS"].ToString();
                    lblType.Text = reader["PropertyType"].ToString();
                    imgHouse.ImageUrl = reader["ImageUrl"].ToString();
                    propertyReference = Convert.ToInt32(reader["RefProperty"].ToString());
                }

                // Reading the Agent information from RefProperty and Listings table
                sql = "select * from Listings where RefProperty = @paramRefProperty";
                command = new OleDbCommand(sql, dbConnection);
                command.Parameters.AddWithValue("paramRefProperty", propertyReference);
                reader = command.ExecuteReader();
                if(reader.Read())
                {
                    int agentReference = Convert.ToInt32(reader["RefUser"].ToString());
                    sql = "select * from Users where RefUser = @paramRefAgent";
                    command = new OleDbCommand(sql, dbConnection);
                    command.Parameters.AddWithValue("paramRefAgent", agentReference);
                    OleDbDataReader agentReader = command.ExecuteReader();
                    if(agentReader.Read())
                    {
                        imgAgent.ImageUrl = agentReader["ImageUrl"].ToString();
                        lblName.Text = agentReader["FirstName"].ToString() + " " + agentReader["LastName"].ToString();
                        lblEmail.Text = agentReader["Email"].ToString();
                        lblID.Text = agentReader["RefUser"].ToString();
                    }
                    dbConnection.Close();
                } else
                {
                    // If this page is not called with request parameter redirecting to index page
                    dbConnection.Close();
                    Response.Redirect("index.aspx");
                }
            } 
            else
            {
                // If this page is not called with request parameter redirecting to index page
                Response.Redirect("index.aspx");
            }
        }

        protected void btnSendMessage_Click(object sender, EventArgs e)
        {
            string subject = txtSubject.Text.Trim();
            string message = txtMessage.Text.Trim();

            int loggedInUserID = Convert.ToInt32(Session["LoggedInUserID"].ToString());
            int agentUserID = Convert.ToInt32(lblID.Text.Trim());

            dbConnection = new OleDbConnection(connectionString);
            dbConnection.Open();

            string sql = "insert into Messages (Subject,Message,SenderUserRef,ReceiverUserRef, CreatedDate) values (@title,@msg,@sendMsg,@recMesg, @created)";

            OleDbCommand command = new OleDbCommand(sql, dbConnection);
            command.Parameters.AddWithValue("title", subject);
            command.Parameters.AddWithValue("msg", message);
            command.Parameters.AddWithValue("sendMsg", loggedInUserID);
            command.Parameters.AddWithValue("recMesg", agentUserID);
            command.Parameters.AddWithValue("created", DateTime.Now.Date);
            if (command.ExecuteNonQuery() == 1)
            {
                lblSuccess.Text = "Message Sent,Successfully!";
                txtMessage.Visible = false;
                txtSubject.Visible = false;
                btnSend.Visible = false;
                lblSendMessageTitle.Visible = false;
            } else
            {
                lblSuccess.Text = "oops !Something went wrong";
            }
            dbConnection.Close();
        }
    }
}