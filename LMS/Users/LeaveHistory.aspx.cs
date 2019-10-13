using LMS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.Users
{
    public partial class LeaveHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //SelectCommand = "SELECT LR.leaveID, LR.empID, ED.Name, LR.leave_type, LR.DayPart, LR.Category, LR.Reason, LR.fromdate, LR.todate, LR.Status FROM leave_request AS LR LEFT OUTER JOIN empDetails AS ED ON LR.empID = '" + CurrentUser.Employee.EmpID.ToString()+"'";
            //SqlDataSource1.SelectParameters.Add("@empID", CurrentUser.Employee.EmpID);
            SqlDataSource1.SelectParameters["empID"].DefaultValue = CurrentUser.Employee.EmpID.ToString();
            //SqlDataSource1.SelectParameters.Add("@empId", CurrentUser.Employee.EmpID.ToString());
            GetNumberOfDaysLeaveRemaining();
            LeavesTakenValue.Text = CurrentUser.Employee.LeavesTaken.ToString();
            
        }

        public static double GetNumberOfDaysLeaveRemaining()
        {
            List<LeaveRequest> leaveRequests;// = new List<LeaveRequest>();
            Employee employee = DataBaseManager.GetEmployeeAndLeaveDetails(out leaveRequests);
            double days = 0;
            if (leaveRequests!=null)
            {
                foreach (LeaveRequest leave in leaveRequests)
                {
                    //if (leave.leavetype == 2)
                    //{
                    //    days += 0.5;
                    //}
                    //else
                    //{
                    //    DateTime startDate = Convert.ToDateTime(leave.fromdate);
                    //    DateTime endDate = Convert.ToDateTime(leave.todate);
                    //    var difference = (endDate - startDate).TotalDays;
                    //    if (difference == 0)
                    //    {
                    //        days++;
                    //    }
                    //    days += difference + 1;
                    //}
                    if (leave.Status == "Approved" || leave.Status == "Pending")
                    {
                        days += GetNumberOfDaysInLeave(leave);
                    }
                    
                }
            }
            
                
            employee.LeavesTaken = days;
            DataBaseManager.UpdateLeavesTaken(days);
            CurrentUser.Employee.LeavesTaken = employee.LeavesTaken;
            CurrentUser.Employee.TotalLeaves = employee.TotalLeaves;

            return employee.TotalLeaves - employee.LeavesTaken;
        }

        private static double GetNumberOfDaysInLeave(LeaveRequest leave)
        {
            double days = 0;
            if (leave.leavetype == 2)
            {
                days += 0.5;
            }
            else
            {
                DateTime startDate = Convert.ToDateTime(leave.fromdate);
                DateTime endDate = Convert.ToDateTime(leave.todate);
                var difference = (endDate - startDate).TotalDays;
                if (difference == 0)
                {
                    days++;
                }
                days += difference + 1;
            }

            return days;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void CancelLeave_Click(object sender, EventArgs e)
        {
            var connection = DataBaseManager.GetConnector();
            Button cancel = (Button)sender;
            GridViewRow gv = (GridViewRow)cancel.Parent.Parent;
            SqlCommand cmd = new SqlCommand("Update leave_request set Status='Cancelled' where leaveID=@leaveID", connection);
            cmd.Parameters.Add("@leaveID", SqlDbType.UniqueIdentifier).Value = GridView1.DataKeys[gv.RowIndex].Value;
            cmd.ExecuteNonQuery();

            List<LeaveRequest> leaveRequests;// = new List<LeaveRequest>();
            Employee employee = DataBaseManager.GetEmployeeAndLeaveDetails(out leaveRequests);

            for (int i = 0; i < leaveRequests.Count; i++)
            {
                if(leaveRequests[i].Status == "Cancelled")
                {
                    employee.LeavesTaken -= GetNumberOfDaysInLeave(leaveRequests[i]);
                }
            }

            DataBaseManager.UpdateLeavesTaken(employee.LeavesTaken);

        }


        //protected void GetLeaveHistory()
        //{
        //    var connection = DataBaseManager.GetConnector();
        //    string query = "Select leaveID,empID,leave_type,DayPart,Category,Reason,fromdate,todate from leave_request where empID=@empID";

        //    SqlCommand cmd = new SqlCommand(query, connection);
        //    SqlParameter empID = cmd.Parameters.Add("@empID", SqlDbType.UniqueIdentifier);
        //    empID.Value = DataBaseManager.GetCurrentUser().EmpID;
        //    SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //    DataSet ds = new DataSet();
        //    sda.Fill(ds);
        //    GridView1.DataSource = ds;
        //    GridView1.DataBind();
        //}

    }
}