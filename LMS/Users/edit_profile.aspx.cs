using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace LMS.Users
{
    public partial class WebForm2 : System.Web.UI.Page
    {

        public void Page_Load(object sender, EventArgs e)
        {
            Bind();
            //PopulateTable();
        }

        private void PopulateTable()
        {
            DataTable employeeData = DataBaseManager.GetEmployeeDataTable();
            
            Table userDetailsTable = new Table();
            string[] keys = {"Name", "MobileNo", "Email", "Address", "username", "password" };
            string[] canUpdateFields = { "MobileNo", "Email", "Address" };

            for (int i = 0; i < keys.Length; i++)
            {
                userDetailsTable.Rows.Add(GetRowWithText(keys[i]));
                //if(canUpdateFields.Contains(keys[i]))
                //{
                //    //userDetailsTable.Rows[i].Cells.Add(GetCellWithInputBox(employeeData.Rows[0].Field<string>(keys[i])));
                //}
                //else
                //{
                    userDetailsTable.Rows[i].Cells.Add(GetCellWithText(employeeData.Rows[0].Field<string>(keys[i])));
                //}
                
            }
            Controls.Add(userDetailsTable);
        }

        private TableCell GetCellWithInputBox(string v)
        {
            TextBox textBox = new TextBox
            {
                Text = v
            };
            TableCell cell = new TableCell();
            cell.Controls.Add(textBox);
            return cell;
        }

        private TableRow GetRowWithText(string value)
        {
            TableRow row = new TableRow();
            TableCell cell = new TableCell
            {
                Text = value
            };
            row.Cells.Add(cell);
            return row;
        }

        private TableCell GetCellWithText(string value)
        {
            TableCell cell = new TableCell();
            cell.Text = value;
            return cell;
        }

        

        private void Bind()
        {
            //string CS = ConfigurationManager.ConnectionStrings["LMSConnectionString"].ConnectionString;
            //using (SqlConnection con = new SqlConnection(CS))
            DataTable dt = DataBaseManager.GetEmployeeDataTable();
            UserDetailsView.DataSourceID = null;
            UserDetailsView.DataSource = dt;
            UserDetailsView.DataBind();

        }



        protected void UserDetailsView_ModeChanging(object sender, DetailsViewModeEventArgs e)
        {

            if(UserDetailsView.CurrentMode==DetailsViewMode.ReadOnly)
            {
                UserDetailsView.ChangeMode(DetailsViewMode.Edit);
                
                UserDetailsView.DataBind();
            }
            else
            {
                UserDetailsView.ChangeMode(DetailsViewMode.ReadOnly);
            }
    
        }

        protected void UserDetailsView_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            
            TextBox mobile = UserDetailsView.Rows[4].Cells[1].Controls[0] as TextBox;
            TextBox email = UserDetailsView.Rows[5].Cells[1].Controls[0] as TextBox;
            string address = UserDetailsView.Rows[6].Cells[1].Controls[0].ToString(); //as TextBox;

            CurrentUser.Employee.MobileNo = mobile.Text;
            CurrentUser.Employee.Email = email.Text;
            CurrentUser.Employee.Address = address;

            DataBaseManager.UpdateEmployee(CurrentUser.Employee);

            UserDetailsView.ChangeMode(DetailsViewMode.ReadOnly);

            UserDetailsView.DataBind();
        }

        protected void UserDetailsView_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
        {

        }
    }
}