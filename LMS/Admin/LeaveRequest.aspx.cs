using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace LMS.Admin
{
    public partial class LeaveRequest : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void ApproveLink_Click(object sender, EventArgs e)
        {
            var connection = DataBaseManager.GetConnector();
            LinkButton update = (LinkButton)sender;
            GridViewRow gv = (GridViewRow)update.Parent.Parent;
            SqlCommand cmd = new SqlCommand("Update leave_request set Status='Approved' where leaveID=@leaveID", connection);
            cmd.Parameters.Add("@leaveID", SqlDbType.UniqueIdentifier).Value = GridView1.DataKeys[gv.RowIndex].Value;
            if (cmd.ExecuteNonQuery() > 0)
            {

            }
            
            Response.Redirect("~/Admin/LeaveRequest.aspx");
        }

        protected void RejectLink_Click(object sender, EventArgs e)
        {
            var connection = DataBaseManager.GetConnector();
            LinkButton update = (LinkButton)sender;
            GridViewRow gv = (GridViewRow)update.Parent.Parent;
            SqlCommand cmd = new SqlCommand("Update leave_request set Status='Rejected' where leaveID=@leaveID", connection);
            cmd.Parameters.Add("@leaveID", SqlDbType.UniqueIdentifier).Value = GridView1.DataKeys[gv.RowIndex].Value;
            if (cmd.ExecuteNonQuery() > 0)
            {

            }
            Response.Redirect("~/Admin/LeaveRequest.aspx");

        }
    }
}