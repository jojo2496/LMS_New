using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using LMS.Models;
using System.Net;
using System.Net.Mail;

namespace LMS
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        //SqlConnection con = new SqlConnection(@"Data Source=JOJO;Initial Catalog=LMS;Integrated Security=True");
        static Guid code;
        protected void Page_Load(object sender, EventArgs e)
        {
            Label6.Visible = false;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Employee employee = FindEmployeeWithUsername(TextBox1.Text);
            if (employee!=null)
            {
                Guid vCode = new Guid();
                if(SendVerificationCodeEmail(vCode,employee.Email))
                {
                    verificationLabel.Visible = true;
                    verificationCode.Visible = true;
                    verifyButton.Visible = true;
                    code = vCode;
                }
            }
        }

        private Employee FindEmployeeWithUsername(string username)
        {
            SqlCommand command = new SqlCommand("Select Email From empDetails Where username = @username", DataBaseManager.GetConnector());
            command.Parameters.AddWithValue("@username", username);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                Employee emp = new Employee { Email = reader["Email"].ToString() };
                reader.Close();
                return emp;
            }
            else
            {
                reader.Close();
                return null;
            }
            
        }

        private bool SendVerificationCodeEmail(Guid vCode,string email)
        {
            var fromAddress = new MailAddress("lms.jojomojo@gmail.com", "LMSAdmin");
            var toAddress = new MailAddress(email, "");
            const string fromPassword = "MoneyHeist!";
            const string subject = "Password reset verification code";
            string body =  "Please enter this code in the verification code box and click 'Verify' to proceed.\nCode: " + vCode.ToString();
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }


            return true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
        }

        protected void verifyButton_Click(object sender, EventArgs e)
        {
            string enteredCode = verificationCode.Text;
            if (enteredCode == code.ToString())
            {

            }
        }
    }
}