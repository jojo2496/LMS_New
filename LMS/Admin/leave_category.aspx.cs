using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace LMS.Admin
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        SqlConnection connection = new SqlConnection(@"Data Source=JOJO;Initial Catalog=LMS;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            string insertquery = "insert into leave_Category(CategoryID,Leave_Category,ShortName) values(@CategoryID,@Leave_Category,@ShortName)";
            SqlCommand cmd = new SqlCommand(insertquery, connection);
            

            cmd.Parameters.AddWithValue("@CategoryID",TextBox1.Text);
            cmd.Parameters.AddWithValue("@Leave_Category", TextBox2.Text);
            cmd.Parameters.AddWithValue("@ShortName", TextBox3.Text);


            cmd.ExecuteNonQuery();
            connection.Close();
           
            
                Response.Write("Category successfully saved...");
            Response.Redirect("~/Admin/leave_category.aspx");
           
        }
    }
}