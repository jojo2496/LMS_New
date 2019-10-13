using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LMS.Admin;

namespace LMS.Models
{
    public class Employee
    {
        public Guid EmpID { get; set; }
        public string Name { get; set; }
        public int Gender { get; set; }

        public string JoiningDate { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string DateOfBirth { get; set; }
        public int TotalLeaves { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Usertype { get; set; }
        public double LeavesTaken { get; internal set; }

        public Employee GetEmployee()
        {
            

            return null;

        }

        internal Employee SetValues(Guid guid, string Name, int Gender, string Joiningdate, string Mobileno, string Email, string Address, string Dob, int totalleaves, string username, string pass, string usertype)

        {
            
            Employee employee = new Employee();

            employee.EmpID = Guid.NewGuid();
            employee.Name = Name;
            employee.Gender = Gender ;
            employee.JoiningDate = Joiningdate;
            employee.MobileNo = Mobileno;
            employee.Email = Email;
            employee.Address = Address;
            employee.DateOfBirth = Dob;
            employee.TotalLeaves = totalleaves;
            employee.Username = username;
            employee.Password = pass;
            employee.Usertype = usertype;
            employee.LeavesTaken = 0;
            

            return employee;
                
        }

        internal Employee SetValues(Guid empID, string username, string password, string usertype)
        {
            Employee employee = new Employee();
            employee.EmpID = empID;
            employee.Username = username;
            employee.Password = password;
            employee.Usertype = usertype;
            return employee;
        }
    }
}