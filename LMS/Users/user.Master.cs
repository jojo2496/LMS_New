using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace LMS.Users
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Login_Details"] == null)
            {
                
                Response.Redirect("~/Login.aspx");
            }
            Label1.Text = "Welcome" + " " + Session["username"].ToString();
        }
        
    }
}