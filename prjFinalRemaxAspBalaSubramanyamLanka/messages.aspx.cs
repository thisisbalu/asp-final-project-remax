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
    public partial class messages : System.Web.UI.Page
    {
        String connectionString = ConfigurationManager.ConnectionStrings["RemaxDB"].ConnectionString;
        OleDbConnection dbConnection = null;
        string role = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            // Checking if user is logged in or not
            Button loginButton = this.Master.FindControl("btnLogin") as Button;
            Button logoutButton = this.Master.FindControl("btnLogout") as Button;
            Button registerButton = this.Master.FindControl("btnRegister") as Button;
            Label lblUser = this.Master.FindControl("lblLoggedInUsername") as Label;
            tableUser.Visible = false;
            tableAgent.Visible = false;
            lblTitle.Text = "";
            if (Session["LoggedInUserID"] != null)
            {
                if (Request.QueryString["messageId"] != null)
                {
                    string refMessage = Request.QueryString["messageId"].ToString();
                    dbConnection = new OleDbConnection(connectionString);
                    dbConnection.Open();
                    string readSql = "update Messages set New = False where RefMessage =" + refMessage;
                    OleDbCommand myCmd1 = new OleDbCommand(readSql, dbConnection);
                    myCmd1.ExecuteNonQuery();
                    dbConnection.Close();
                    Response.Redirect("messages.aspx");
                }

                loginButton.Visible = false;
                logoutButton.Visible = true;
                registerButton.Visible = false;
                lblUser.Text = "Welcome " + Session["LoggedInUserFirstName"].ToString() + "!";

                dbConnection = new OleDbConnection(connectionString);
                dbConnection.Open();
                String sql = "select * from Users Where RefUser = " + Session["LoggedInUserID"].ToString();
                OleDbCommand command = new OleDbCommand(sql, dbConnection);
                OleDbDataReader reader = command.ExecuteReader();
                if(reader.Read())
                {
                    role = reader["UserRole"].ToString();
                }

                if(role == "BUYER")
                {
                    tableUser.Visible = true;
                    lblTitle.Text = "SENT MESSAGES TO AGENTS";
                    sql = "select * from Messages Where SenderUserRef = " + Session["LoggedInUserID"].ToString();
                    command = new OleDbCommand(sql, dbConnection);
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        TableRow aRow = new TableRow();
                        TableCell aCell = new TableCell();
                        aCell.Text = reader["CreatedDate"].ToString();
                        aCell.Width = 200;
                        aRow.Cells.Add(aCell);

                        string userSql = "select * from Users where RefUser = " + reader["ReceiverUserRef"].ToString();
                        OleDbConnection userConnection = new OleDbConnection(connectionString);
                        userConnection.Open();
                        OleDbCommand userCommand = new OleDbCommand(userSql, userConnection);
                        OleDbDataReader userReader = userCommand.ExecuteReader();
                        if (userReader.Read())
                        {
                            aCell = new TableCell();
                            aCell.Text = userReader["FirstName"].ToString() + " " + userReader["LastName"].ToString();
                            aRow.Cells.Add(aCell);

                            aCell = new TableCell();
                            aCell.Text = userReader["Email"].ToString();
                            aRow.Cells.Add(aCell);
                            userConnection.Close();
                        }

                        aCell = new TableCell();
                        aCell.Text = reader["Subject"].ToString();
                        aCell.Width = 300;
                        aRow.Cells.Add(aCell);

                        aCell = new TableCell();
                        aCell.Text = reader["Message"].ToString();
                        aCell.Width = 300;
                        aRow.Cells.Add(aCell);

                        tableUser.Rows.Add(aRow);
                    }
                    dbConnection.Close();
                } else
                {
                    tableAgent.Visible = true;
                    lblTitle.Text = "RECEIVED MESSAGES FROM BUYERS";
                    sql = "select * from Messages Where ReceiverUserRef = " + Session["LoggedInUserID"].ToString() + " ORDER BY CreatedDate DESC";
                    command = new OleDbCommand(sql, dbConnection);
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        TableRow aRow = new TableRow();
                        TableCell aCell = new TableCell();
                        aCell.Text = reader["CreatedDate"].ToString();
                        aCell.Width = 200;
                        aRow.Cells.Add(aCell);

                        string userSql = "select * from Users where RefUser = " + reader["SenderUserRef"].ToString();
                        OleDbConnection userConnection = new OleDbConnection(connectionString);
                        userConnection.Open();
                        OleDbCommand userCommand = new OleDbCommand(userSql, userConnection);
                        OleDbDataReader userReader = userCommand.ExecuteReader();
                        if (userReader.Read())
                        {
                            aCell = new TableCell();
                            aCell.Text = userReader["FirstName"].ToString() + " " + userReader["LastName"].ToString();
                            aRow.Cells.Add(aCell);

                            aCell = new TableCell();
                            aCell.Text = userReader["Email"].ToString();
                            aRow.Cells.Add(aCell);
                            userConnection.Close();
                        }

                        aCell = new TableCell();
                        aCell.Text = reader["Subject"].ToString();
                        //aCell.Width = 300;
                        aRow.Cells.Add(aCell);

                        aCell = new TableCell();
                        aCell.Text = reader["Message"].ToString();
                        aCell.Width = 300;
                        aRow.Cells.Add(aCell);

                        if(reader["New"].ToString() == "True")
                        {
                            aCell = new TableCell();
                            LinkButton readButton = new LinkButton();
                            readButton.Text = "Yes (Mark as Read)";
                            readButton.PostBackUrl = "messages.aspx?messageId=" + reader["RefMessage"].ToString();
                            aCell.Controls.Add(readButton);
                            aRow.Cells.Add(aCell);
                        } else
                        {
                            aCell = new TableCell();
                            aCell.Text = "No";
                            aRow.Cells.Add(aCell);
                        }

                        tableAgent.Rows.Add(aRow);
                    }
                    dbConnection.Close();
                }

            }
            else
            {
                loginButton.Visible = true;
                logoutButton.Visible = false;
                registerButton.Visible = true;
                lblUser.Text = "";
                lblTitle.Text = "Please login to check the messages";
            }
        }
    }
}