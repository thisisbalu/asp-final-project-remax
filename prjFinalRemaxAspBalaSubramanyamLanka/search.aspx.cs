using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjFinalRemaxAspBalaSubramanyamLanka
{
    public partial class search : System.Web.UI.Page
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

            // Reset errors
            errBaths.Text = "";
            errBeds.Text = "";
            errEmail.Text = "";
            errFirstName.Text = "";
            errLastName.Text = "";
            errPrice.Text = "";
            errUsername.Text = "";
            tableAgents.Visible = false;
            tableHouses.Visible = false;

            // Populating dropdowns only once
            if (!IsPostBack)
            {
                dbConnection = new OleDbConnection(connectionString);
                dbConnection.Open();
                String sql = "select DISTINCT City from Properties";
                OleDbCommand command = new OleDbCommand(sql, dbConnection);
                dlCity.DataTextField = "City";
                dlCity.DataValueField = "City";
                dlCity.DataSource = command.ExecuteReader();
                dlCity.DataBind();
                sql = "select DISTINCT PropertyType from Properties";
                command = new OleDbCommand(sql, dbConnection);
                dlProperty.DataTextField = "PropertyType";
                dlProperty.DataValueField = "PropertyType";
                dlProperty.DataSource = command.ExecuteReader();
                dlProperty.DataBind();
                dbConnection.Close();
            }

        }

        protected void btnSearchAgents_Click(object sender, EventArgs e)
        {
            if (!chkFirstName.Checked && !chkLastName.Checked && !chkEmail.Checked && !chkUsername.Checked)
            {
                tableAgents.Visible = false;
                return;
            }
            dbConnection = new OleDbConnection(connectionString);
            ArrayList conditions = new ArrayList();
            String sql = "select * from Users where ";
            if(chkFirstName.Checked)
            {
                string fName = txtFirstName.Text;
                if(fName == "")
                {
                    errFirstName.Text = "Firstname is empty";
                    return;
                }
                conditions.Add("(FirstName = '" + fName + "')");
            }
            if (chkLastName.Checked)
            {
                string lName = txtLastName.Text;
                if (lName == "")
                {
                    errLastName.Text = "Lastname is empty";
                    return;
                }
                conditions.Add("(LastName = '" + lName + "')");
            }
            if (chkEmail.Checked)
            {
                string email = txtEmail.Text;
                if (email == "")
                {
                    errEmail.Text = "Email is empty";
                    return;
                }
                conditions.Add("(Email = '" + email + "')");
            }
            if (chkUsername.Checked)
            {
                string uName = txtUsername.Text;
                if (uName == "")
                {
                    errUsername.Text = "Username is empty";
                    return;
                }
                conditions.Add("(Username = '" + uName + "')");
            }
            string whereCondition = String.Join(" AND ", conditions.ToArray());
            sql = sql + whereCondition;
            dbConnection.Open();
            OleDbCommand command = new OleDbCommand(sql, dbConnection);
            OleDbDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                tableAgents.Visible = true;
                lblSearchText.Text = "";
                while (reader.Read())
                {
                    TableRow aRow = new TableRow();
                    TableCell aCell = new TableCell();
                    Image houseImage = new Image();
                    houseImage.Width = 100;
                    houseImage.ImageUrl = reader["ImageUrl"].ToString();
                    aCell.Controls.Add(houseImage);
                    aRow.Cells.Add(aCell);

                    aCell = new TableCell();
                    aCell.Text = reader["FirstName"].ToString();
                    aRow.Cells.Add(aCell);

                    aCell = new TableCell();
                    aCell.Text = reader["LastName"].ToString();
                    aRow.Cells.Add(aCell);

                    aCell = new TableCell();
                    aCell.Text = reader["Email"].ToString();
                    aRow.Cells.Add(aCell);

                    aCell = new TableCell();
                    aCell.Text = reader["Username"].ToString();
                    aRow.Cells.Add(aCell);

                    aCell = new TableCell();
                    LinkButton readButton = new LinkButton();
                    readButton.Text = "View";
                    readButton.PostBackUrl = "agent.aspx?refUser=" + reader["RefUser"].ToString();
                    aCell.Controls.Add(readButton);
                    aRow.Cells.Add(aCell);

                    tableAgents.Rows.Add(aRow);
                }
            }
            else
            {
                lblSearchText.Text = "No Search Results";
            }
            dbConnection.Close();
        }

            protected void btnSearchHouses_Click(object sender, EventArgs e)
        {
            if(!chkBaths.Checked && !chkBeds.Checked && !chkCity.Checked && !chkPrice.Checked && !chkProperty.Checked)
            {
                tableHouses.Visible = false;
                return;
            }
            dbConnection = new OleDbConnection(connectionString);
            ArrayList conditions = new ArrayList();
            String sql = "select * from Properties where ";
            if(chkBaths.Checked)
            {
                string baths = txtBaths.Text;
                if(baths == null || baths == "")
                {
                    errBaths.Text = "Baths is empty";
                    return;
                }
                conditions.Add("(Bathrooms = " + baths + ")"); 
            }
            if(chkBeds.Checked)
            {
                string beds = txtBeds.Text;
                if(beds == null || beds == "")
                {
                    errBeds.Text = "Beds is empty";
                    return;
                }
                conditions.Add("(Bedrooms = " + beds + ")");
            }
            if(chkCity.Checked)
            {
                conditions.Add("(City = '" + dlCity.Text + "')");
            }
            if (chkProperty.Checked)
            {
                conditions.Add("(PropertyType = '" + dlProperty.Text + "')");
            }
            if(chkPrice.Checked)
            {
                string from = txtFrom.Text;
                string to = txtTo.Text;
                if(from == "" || to == "")
                {
                    errPrice.Text = "Prices are empty";
                    return;
                }
                conditions.Add("(Price BETWEEN " + from + " AND " + to + ")");
            }
            string whereCondition = String.Join(" AND ", conditions.ToArray());
            sql = sql + whereCondition;
            dbConnection.Open();
            OleDbCommand command = new OleDbCommand(sql, dbConnection);
            OleDbDataReader reader = command.ExecuteReader();
            if(reader.HasRows)
            {
                tableHouses.Visible = true;
                lblSearchText.Text = "";
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
            }
            else
            {
                lblSearchText.Text = "No Search Results";
            }
            dbConnection.Close();
        }
    }
}