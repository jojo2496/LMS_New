using LMS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LMS.Users
{
    public static class CurrentUser
    {
        public static Employee Employee { get; set; }

        internal static void SetDetails(DataTable employeeData)
        {
            string[] columnNames = {"Name","Gender","JoiningDate","MobileNo","Email","Address","DateOfBirth","TotalLeaves","username","password","usertype","LeavesTaken"};
            DataRow row = employeeData.Rows[0];
            int i = 0;
            Employee.Name = row.Field<string>(columnNames[i++]);
            Employee.Gender = row.Field<byte>(columnNames[i++]);
            Employee.JoiningDate = row.Field<DateTime>(columnNames[i++]).ToString();
            Employee.MobileNo = row.Field<string>(columnNames[i++]);
            Employee.Email = row.Field<string>(columnNames[i++]);
            Employee.Address = row.Field<string>(columnNames[i++]);
            Employee.DateOfBirth = row.Field<DateTime>(columnNames[i++]).ToString();
            Employee.TotalLeaves = row.Field<byte>(columnNames[i++]);
            Employee.Username = row.Field<string>(columnNames[i++]);
            Employee.Password = row.Field<string>(columnNames[i++]);
            Employee.Usertype = row.Field<string>(columnNames[i++]);
            Employee.LeavesTaken = row.Field<double>(columnNames[i++]);
        }
    }
}