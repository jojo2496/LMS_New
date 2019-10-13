using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using LMS.Users;
using LMS.Models;

namespace LMS
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblerror.Visible = false;
            Session["username"] = txtuser.Text;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = DataBaseManager.GetConnector(); //new SqlConnection(@"Data Source=JOJO;Initial Catalog=LMS;Integrated Security=True");
                                                                //con.Open();


            SqlDataAdapter ada = new SqlDataAdapter("Select * from Login_Details where   username= '" + txtuser.Text + "' and password='" + txtpass.Text + "' ", con);//and usertype='"+ComboBox1.SelectedValue.ToString()+"'",con);
            
            DataTable dt = new DataTable();
            ada.Fill(dt);
            
            if(dt.Rows.Count==1)    
            {
                CurrentUser.Employee = DataBaseManager.GetCurrentUser(txtuser.Text);
                DataTable employeeData = DataBaseManager.GetEmployeeDataTable();
                CurrentUser.SetDetails(employeeData);

                Session["Login_Details"] = UniqueID;
                if(CurrentUser.Employee.Usertype == "Admin")//ComboBox1.SelectedIndex==0
                {
                    Response.Redirect("~/Admin/admin_home.aspx");
                }
                else
                {
                    Response.Redirect("~/Users/user_home.aspx");
                }
            }
            else
            {
                lblerror.Visible = true;
            }
            //con.Close();
        }
    }
}