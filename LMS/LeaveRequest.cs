using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LMS.Users;
using LMS;

namespace LMS.Users
{
    public class LeaveRequest
    {
        
        public Guid leaveID { get; set; }
        public Guid empID { get; set; }
        public string Name { get; set; }


        public int leavetype { get; set; }

        public int DayPart  { get; set; }
        public string Category  { get; set; }
        public int CategoryID { get; set; }
        public string Reason { get; set; }
        public string fromdate { get; set; }
        public string todate { get; set; }
        public string Status { get; set; }
        public int RemainingLeaves { get; set; }

        private readonly string[] dayPartValues = { "Pre-Lunch", "Post-Lunch", "Full Day" };


        internal LeaveRequest Setvalue(Guid guid,Guid guid1, int leavetype, string DayPart, string Category, int CategoryID, string Reason, string fromdate, string todate)
        {
            LeaveRequest leaveRequest = new LeaveRequest();
            leaveRequest.leaveID = guid;
            leaveRequest.empID = guid1;
            leaveRequest.leavetype = leavetype;

            leaveRequest.DayPart = GetDayPartValue(DayPart);

            leaveRequest.Category = Category;
            leaveRequest.CategoryID = CategoryID;
            leaveRequest.Reason = Reason;
            leaveRequest.fromdate = fromdate;
            leaveRequest.todate = todate;
           
            return leaveRequest;
        }

        public static void SetStatus(ref LeaveRequest leaveRequest, string statusValue)
        {
            leaveRequest.Status = statusValue;
        }

        private int GetDayPartValue(string DayPart)
        {
            int i = 0;
            while (i < dayPartValues.Length)
            {
                if (DayPart == dayPartValues[i])
                    break;
                i++;
            }
            return i;
        }
       
    
        //internal LeaveRequest SetStatus(Guid guid, string Name, string Status)
        //{
        //    LeaveRequest setStatus = new LeaveRequest();
        //    setStatus.empID = guid;
        //    setStatus.Name = Name;
        //    setStatus.Status = Status;
        //    return setStatus;
        //}

        
    }
        
}