using System;



namespace LMS.Admin
{

    public partial class WebForm2 : System.Web.UI.Page
    {
         //SqlConnection conn = new SqlConnection(@"Data Source=JOJO;Initial Catalog=LMS;Integrated Security=True");
        // string empID = " ";
        protected void Page_Load(object sender, EventArgs e)
        {
            Label13.Visible = false;
            
        }
        


        protected void Button2_Click(object sender, EventArgs e)
        {
            //Employee employee = new Employee();
            //employee = employee.SetValues(Guid.NewGuid(), txtname.Text, genderlist.SelectedIndex, txtjdate.Text.TrimEnd(),
            //         txtmobile.Text, txtmail.Text, txtadd.Text, txtdob.Text.TrimEnd(), Convert.ToInt32(txttleaves.Text), txtuname.Text, txtpass.Text, ComboBox1.SelectedValue);






            //var result = DataBaseManager.AddEmployee(employee);
            //DataBaseManager.UpdateLoginTable(employee);

            //Response.Write(result);
            //Label13.Visible = true;

            //Response.Redirect("EmpManagement.aspx");




        }


        protected void Button4_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/Admin/EmpManagement.aspx");
        }


    }
}