using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjFinalRemaxAspBalaSubramanyamLanka
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }

        protected void Register_Click(object sender, EventArgs e)
        {
            Response.Redirect("register.aspx");
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            Session["LoggedInUserID"] = null;
            Session["LoggedInUserFirstName"] = null;
            Session["LoggedInUserLastName"] = null;
            Session["LoggedInUserEmail"] = null;
            Response.Redirect("login.aspx");
        }
    }
}