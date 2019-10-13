using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using LMS.Models;
using LMS.Users;
using LMS;
namespace LMS.Users
{

    public partial class WebForm3 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=JOJO;Initial Catalog=LMS;Integrated Security=True");
       

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Calendar1.Attributes["min"] = DateTime.Now.ToString("yyyy-MM-dd");
                Calendar2.Attributes["min"] = DateTime.Now.ToString("yyyy-MM-dd");
                //EmployeeIdLabel.Text = CurrentUser.Employee.EmpID.ToString();
                lblsuccess.Visible = false;
                remainingleaveslbl.Text = LeaveHistory.GetNumberOfDaysLeaveRemaining().ToString();
            }
           
            //LeaveCount();
           

        }
        protected string RadioButtonText()
        {
            if (RadioButton1.Checked)
            {
                return RadioButton1.Text;
            }
            else
            {
                return RadioButton2.Text;
            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            string radio = string.Empty;
            if (DropDownList1.SelectedIndex == 2)
            {
                if (RadioButton1.Checked)
                {
                    radio = "Pre-Lunch";
                }
                else if(RadioButton2.Checked)
                {
                    radio = "Post-Lunch";
                }
            }
            else
            {
                radio = "Full Day";
            }

        
           
            LeaveRequest leaveRequest = new LeaveRequest();

          
            leaveRequest = leaveRequest.Setvalue(Guid.NewGuid(),CurrentUser.Employee.EmpID,DropDownList1.SelectedIndex, radio, 
                                        categorylist.SelectedValue, GetCategoryId(categorylist.SelectedValue),txtreason.Text,
                                        Calendar1.SelectedDate.ToString(), GetToDateValue(DropDownList1.SelectedIndex));

            LeaveRequest.SetStatus(ref leaveRequest, "Pending");
            
            //LeaveRequest.leaveBalance(leaveRequest, CurrentUser.Employee.TotalLeaves);
            //remainingleaveslbl.Text = CurrentUser.Employee.remainingLeaves;
          //LeaveRequest setStatus = new LeaveRequest();
          // setStatus = setStatus.SetStatus(CurrentUser.Employee.EmpID, CurrentUser.Employee.Name, setStatus.Status="Pending");

            var result = DataBaseManager.LeaveReq(leaveRequest);
            //var status = DataBaseManager.setStatus(status);
            Response.Write(result);
            lblsuccess.Visible = true;
            Response.Redirect("~/Users/user_home.aspx");
            

        }

        private string GetToDateValue(int selectedIndex)
        {
            if (selectedIndex == 2)
                return Calendar1.SelectedDate.ToString();
            else
                return Calendar2.SelectedDate.ToString();
        }

        private int GetCategoryId(string selectedValue)
        {
            string[] categories = DataBaseManager.GetCategories();
            string[] category;
            string id = "1";
            for (int i = 0; i < categories.Length; i++)
            {
                category = categories[i].Split('|');
                if(selectedValue == category[1])
                {
                    id = category[0];
                }
            }

            return Convert.ToInt32(id);
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedItem.Text =="Half-Day Leave" )
            {
                RadioButton1.Enabled = true;
                RadioButton2.Enabled = true;
            }
            else
            {
                RadioButton1.Enabled = false;
                RadioButton2.Enabled = false;
            }
            
        }

       

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(RadioButton1.Checked==true)
            {
                RadioButton2.Checked = false;
            }
        }

        protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton2.Checked==true)
            {
                RadioButton1.Checked = false;
            }
        }

       

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {


            // Select all dates in the past
            if (e.Day.Date < System.DateTime.Today)
            {
                // Disable date
                e.Day.IsSelectable = false;
                // Change color of disabled date
                e.Cell.ForeColor = Color.Gray;
            }
            if (DropDownList1.SelectedValue == "Half-Day Leave")
            {
                Calendar2.SelectedDate = new DateTime(Calendar1.SelectedDate.Year, Calendar1.SelectedDate.Month, Calendar1.SelectedDate.Day);
                Calendar2.VisibleDate = new DateTime(Calendar1.SelectedDate.Year, Calendar1.SelectedDate.Month, Calendar1.SelectedDate.Day);
            }
        }

        protected void Calendar2_DayRender(object sender, DayRenderEventArgs e)
        {



            // Select all dates in the past
            if (e.Day.Date < System.DateTime.Today)
            {
                // Disable date
                e.Day.IsSelectable = false;
                // Change color of disabled date
                e.Cell.ForeColor = Color.Gray;
                
               
            }
            
            //e.Day.IsSelectable = false;

        }

        //protected void LeaveCount()
        //{
        //    var connection=DataBaseManager.GetConnector();
        //    string query = "Select count(TotalLeaves) from empDetails where empID="+CurrentUser.Employee.EmpID;
        //    SqlCommand cmd = new SqlCommand(query, connection);
        //    SqlDataReader dr = cmd.ExecuteReader();
        //    while(dr.Read())
        //    {
        //        remainingleaveslbl.Text = dr.GetValue(0).ToString();            }

        //}
        


    }

}
    
