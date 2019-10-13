using LMS.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using LMS.Admin;
using System.Web.UI.WebControls;
using LMS.Users;
using System.Data.SqlTypes;

namespace LMS
{
    public class DataBaseManager
    {
        private static readonly SqlConnection _connection;
        static DataBaseManager()
        {
            _connection = new SqlConnection(@"Data Source=JOJO;Initial Catalog=LMS;Integrated Security=True");
            _connection.Open();
        }
        
        public static string AddEmployee(Employee employee)
        {
            //string conn = " ";
            //conn = ConfigurationManager.ConnectionStrings["conn"].ToString();
            //SqlConnection connection = new SqlConnection(conn);
            try
            {

                //Employee employee = new Employee();
                //employee.SetValues(Guid.NewGuid(), TextBox1.Text, DropDownList1.SelectedValue, TextBox2.Text,
                        // TextBox3.Text, TextBox4.Text, TextBox5.Text, TextBox6.Text, TextBox7, TextBox8.Text, TextBox9.Text, ComboBox1.SelectedValue);
                //_connection.Open();
                SqlCommand objcmd = new SqlCommand("insertemp", _connection);
                objcmd.CommandType = CommandType.StoredProcedure;

                SqlParameter empID = objcmd.Parameters.Add("@empID", SqlDbType.UniqueIdentifier);

                empID.Value = employee.EmpID;



                SqlParameter Name = objcmd.Parameters.Add("@Name", SqlDbType.VarChar);
                Name.Value = employee.Name;

                SqlParameter Gender = objcmd.Parameters.Add("@Gender", SqlDbType.TinyInt);
                Gender.Value = employee.Gender;


                SqlParameter JoiningDate = objcmd.Parameters.Add("@JoiningDate", SqlDbType.DateTime);
                JoiningDate.Value = employee.JoiningDate;
                SqlParameter MobileNo = objcmd.Parameters.Add("@MobileNo", SqlDbType.VarChar);
                MobileNo.Value = employee.MobileNo;

                SqlParameter Email = objcmd.Parameters.Add("@Email", SqlDbType.VarChar);
                Email.Value = employee.Email;
                SqlParameter Address = objcmd.Parameters.Add("@Address", SqlDbType.VarChar);
                Address.Value = employee.Address ;
                SqlParameter DateOfBirth = objcmd.Parameters.Add("@DateOfBirth", SqlDbType.DateTime);
                DateOfBirth.Value = employee.DateOfBirth;
                SqlParameter TotalLeaves = objcmd.Parameters.Add("@TotalLeaves", SqlDbType.TinyInt);
                TotalLeaves.Value = employee.TotalLeaves;
                SqlParameter username = objcmd.Parameters.Add("@username", SqlDbType.VarChar);
                username.Value = employee.Username;
                SqlParameter password = objcmd.Parameters.Add("@password", SqlDbType.VarChar);
                password.Value = employee.Password ;
                SqlParameter usertype = objcmd.Parameters.Add("@usertype", SqlDbType.VarChar);
                usertype.Value = employee.Usertype;
                SqlParameter LeavesTaken = objcmd.Parameters.Add("@LeavesTaken", SqlDbType.Float);
                LeavesTaken.Value = employee.LeavesTaken;

                objcmd.ExecuteNonQuery();

                return ("Employee has been registered..");


            }
            
            catch (Exception ex)
            {
              return(ex.Message.ToString());
            }
            finally
            {
                //connection.Close();
            }

        }

        internal static string[] GetCategories()
        {
            SqlCommand getCategories = new SqlCommand("Select CategoryID,Leave_Category from leave_Category",_connection);
            SqlDataReader reader = getCategories.ExecuteReader();
            List<string> categories = new List<string>();
            while (reader.Read())
            {
                categories.Add(reader["CategoryID"].ToString() + "|" + reader["Leave_Category"]);
            }
            reader.Close();

            return categories.ToArray();
        }

        public static bool UpdateEmployee(Employee employee)
        {
            SqlCommand updateEmployee = new SqlCommand("UPDATE empDetails SET MobileNo = '" + employee.MobileNo + "',Email = '" + employee.Email +
                                            "',Address = '" + employee.Address + "' where empID = '" + employee.EmpID.ToString() + "'", _connection);
            try
            {
                updateEmployee.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
           
        }
        internal static void UpdateLeavesTaken(double days)
        {
            SqlCommand command = new SqlCommand("UPDATE empDetails SET LeavesTaken = @days WHERE empID = @empid;", _connection);
            command.Parameters.Add("@empid", SqlDbType.UniqueIdentifier).Value = CurrentUser.Employee.EmpID;
            command.Parameters.Add("@days", SqlDbType.Float).Value = days;
            command.ExecuteNonQuery();
        }

        internal static Employee GetEmployeeAndLeaveDetails(out List<Users.LeaveRequest> leaveRequests)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM leave_request WHERE (empID = @empid);");
            command.Parameters.Add("@empid", SqlDbType.UniqueIdentifier).Value = CurrentUser.Employee.EmpID;
            command.Connection = _connection;
            SqlDataReader reader = command.ExecuteReader();
            Employee employee = new Employee();
            List<Users.LeaveRequest> leaves = new List<Users.LeaveRequest>();
            while (reader.Read())
            {
                leaves.Add(new Users.LeaveRequest() { leavetype = reader.GetInt32(2), Status = reader["Status"].ToString(), fromdate = reader["fromdate"].ToString(), todate = reader["todate"].ToString() });
            }
            reader.Close();
            if (leaves.Count>0)
            {
                leaveRequests = leaves;
            }
            else
            {
                leaveRequests = null;
            }
         
            command.CommandText = "SELECT TotalLeaves,LeavesTaken FROM empDetails WHERE empID = @empid";
            //command.Parameters.AddWithValue("@empid", CurrentUser.Employee.EmpID);
            reader = command.ExecuteReader();
            if (reader.Read())
           {
                employee.TotalLeaves = (byte)reader["TotalLeaves"];
                //var temp = reader["LeavesTaken"];
                //if (temp.ToString() == null)
                //    employee.LeavesTaken = 0;
                //else
                //var temp = reader["LeavesTaken"];
                employee.LeavesTaken = Convert.ToDouble(reader["LeavesTaken"]);
            }
            reader.Close();
            return employee;
        }

        internal static void UpdateLoginTable(Employee employee)
        {
            //string conn = " ";
            //conn = ConfigurationManager.ConnectionStrings["conn"].ToString();
            //SqlConnection connection = new SqlConnection(conn);
            //connection.Open();
            SqlCommand cmd = new SqlCommand("login1", _connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlParameter empID = cmd.Parameters.Add("@empID", SqlDbType.UniqueIdentifier);
            empID.Value = employee.EmpID;
            
            SqlParameter username = cmd.Parameters.Add("@username", SqlDbType.VarChar);
            username.Value = employee.Username;
            SqlParameter password = cmd.Parameters.Add("@password", SqlDbType.VarChar);
            password.Value = employee.Password;
            SqlParameter usertype = cmd.Parameters.Add("@usertype", SqlDbType.VarChar);
            usertype.Value = employee.Usertype;
            SqlParameter email = cmd.Parameters.Add("@Email", SqlDbType.VarChar);
            email.Value = employee.Email;
          


            cmd.ExecuteNonQuery();

            //connection.Close();
        }
        internal static string LeaveReq(Users.LeaveRequest leaveRequest)
        {
            //string conn;
            //conn = ConfigurationManager.ConnectionStrings["conn"].ToString();
            //SqlConnection connection = new SqlConnection(conn);
            //connection.Open();
            SqlCommand cmd = new SqlCommand("request", _connection);

            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter leaveID = cmd.Parameters.Add("@leaveID", SqlDbType.UniqueIdentifier);
            leaveID.Value = leaveRequest.leaveID;
            SqlParameter empID = cmd.Parameters.Add("@empID", SqlDbType.UniqueIdentifier);
            empID.Value = leaveRequest.empID;

            SqlParameter leavetype = cmd.Parameters.Add("@leave_type", SqlDbType.Int);
            leavetype.Value = leaveRequest.leavetype;

            SqlParameter daypart = cmd.Parameters.Add("@DayPart", SqlDbType.Int);
            daypart.Value = leaveRequest.DayPart; 

            SqlParameter Category = cmd.Parameters.Add("@Category", SqlDbType.VarChar);
            Category.Value = leaveRequest.Category;

            SqlParameter CategoryID = cmd.Parameters.Add("@CategoryID", SqlDbType.TinyInt);
            CategoryID.Value =leaveRequest.CategoryID;
           

            SqlParameter reason = cmd.Parameters.Add("@Reason", SqlDbType.VarChar);
            reason.Value = leaveRequest.Reason;
            SqlParameter fromdate = cmd.Parameters.Add("@fromdate", SqlDbType.DateTime); 
            fromdate.Value = leaveRequest.fromdate;
            SqlParameter todate = cmd.Parameters.Add("@todate", SqlDbType.DateTime);
            todate.Value = leaveRequest.todate;
            SqlParameter status = cmd.Parameters.Add("@Status", SqlDbType.VarChar);
            status.Value = leaveRequest.Status;
            

            cmd.ExecuteNonQuery();
            //connection.Close();
            return Convert.ToString(leaveRequest);
            
           

        }

        public static Employee GetCurrentUser(string username)
        {
            SqlCommand getCurrentUser = new SqlCommand("Select empID,username,password,usertype from Login_Details where username = @uname", _connection);
            getCurrentUser.Parameters.AddWithValue("@uname", username);

            SqlDataReader reader = getCurrentUser.ExecuteReader();
            if (reader.Read())
            {
                Employee employee = new Employee().SetValues((Guid)reader["empID"], (string)reader["username"], (string)reader["password"], (string)reader["usertype"]);
                reader.Close();
                return employee;
            }
            else
            {
                reader.Close();
                return null;
            }
        }
        //}public static string LeaveStatus()
        //{
        //    SqlCommand cmd=new SqlCommand
        //}

        public static DataTable GetEmployeeDataTable()
        {
            SqlConnection con = GetConnector();
            SqlCommand cmd = new SqlCommand("emp_Detail", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empID", CurrentUser.Employee.EmpID.ToString());
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }


        public static SqlConnection GetConnector()
        {
            return _connection;
        }

        //internal static string setStatus( )
        //{
        //    SqlCommand setStatus = new SqlCommand("Insert into leave_status(empID,Name,Status) values(empid=@empID,Name=@Name,Status=@Status)");
        //    setStatus.ExecuteNonQuery();
            
        //}
        //internal static void LeaveBalance()
        //{
        //    LeaveBalance = DataBaseManager.GetCurrentUser.TotalLeaves;
        //}





    }
}