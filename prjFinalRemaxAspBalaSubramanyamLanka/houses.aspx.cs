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
    public partial class houses : System.Web.UI.Page
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
            // Populating all the houses
            dbConnection = new OleDbConnection(connectionString);
            dbConnection.Open();
            String sql = "select * from Properties";
            OleDbCommand command = new OleDbCommand(sql, dbConnection);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                TableRow aRow = new TableRow();
                TableCell aCell = new TableCell();
                Image houseImage = new Image();
                houseImage.Width = 250;
                houseImage.ImageUrl = reader["ImageUrl"].ToString();
                aCell.Controls.Add(houseImage);
                aRow.Cells.Add(aCell);

                aCell = new TableCell();
                aCell.Text = reader["About"].ToString().Substring(0, 250);
                aRow.Cells.Add(aCell);

                aCell = new TableCell();
                aCell.Text = reader["BedRooms"].ToString();
                aRow.Cells.Add(aCell);

                aCell = new TableCell();
                aCell.Text = reader["BathRooms"].ToString();
                aRow.Cells.Add(aCell);

                aCell = new TableCell();
                aCell.Text = reader["PropertyType"].ToString();
                aRow.Cells.Add(aCell);

                aCell = new TableCell();
                aCell.Text = reader["City"].ToString();
                aRow.Cells.Add(aCell);

                aCell = new TableCell();
                aCell.Text = "$" + reader["Price"].ToString();
                aRow.Cells.Add(aCell);

                aCell = new TableCell();
                LinkButton readButton = new LinkButton();
                readButton.Text = "View";
                readButton.PostBackUrl = "house.aspx?MLS=" + reader["MLS"].ToString();
                aCell.Controls.Add(readButton);
                aRow.Cells.Add(aCell);

                tableHouses.Rows.Add(aRow);
            }
            dbConnection.Close();
        }
    }
}