using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace LMS.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Login_Details"] == null)
            {

                Response.Redirect("~/Login.aspx");
            }
            Label1.Text ="Welcome"+" "+ Session["username"].ToString();
            EmpCount();

           





        }
        protected void EmpCount()
        {
            SqlConnection con = new SqlConnection(@"Data Source=JOJO;Initial Catalog=LMS;Integrated Security=True");
            con.Open();
            string query = "Select count(*) from empDetails";

            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();



            while (dr.Read())

            {

                Label3.Text = dr.GetValue(0).ToString();

                

            }



        }
    }
}