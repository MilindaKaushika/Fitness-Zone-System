using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fitness_Zone.DAL;
using System.Data.SqlClient;


namespace Fitness_Zone.Biz
{
    class Attendance
    {
        private string attendanceID;
        public string AttendanceID
        {
            get { return attendanceID; }
            set { attendanceID = value; }
        }
        private string scheduleID;
        public string ScheduleID
        {
            get { return scheduleID; }
            set { scheduleID = value; }
        }
       
        private string memberName;
        public string MemberName
        {
            get { return memberName; }
            set { memberName = value; }
        }

        private string trainer;
        public string Trainer
        {
            get { return trainer; }
            set { trainer = value; }
        }
        private string date;
        public string Date
        {
            get { return date; }
            set { date = value; }
        }
        private string time;
        public string Time
        {
            get { return time; }
            set { time = value; }
        }
             private string present;
        public string Present
        {
            get { return present; }
            set { present = value; }
        }
         public Attendance() { }

         public Attendance(string id)
        {
            this.attendanceID = id;
        }
        public Attendance(string id, string scheduleID, string memberName, string trainer, string date,string time, string present)
                    
        {
            this.attendanceID = id;
            this.scheduleID = scheduleID;
            this.memberName = memberName;
            this.trainer = trainer;
            this.date = date;
            this.time = time;
            this.present = present;
           
        }
        public bool addAttendance()
        {
            string quary = "exec AddAattendance '" + this.attendanceID + "','" + this.scheduleID + "','" + this.memberName + "','" + this.trainer + "','" + this.date + "','" + this.time + "','" + this.present + "'";
            bool result = new SystemDAL().executeNonQueryS(quary);
            return result;
        }
        public List<Attendance> getAllattendancedetails()
        {
            List<Attendance> attendance = new List<Attendance>();
            string quary = "exec searchAllAattendance";
            SqlDataReader reader = new SystemDAL().executeQueryS(quary);

            // for many records go with while loop
            while (reader.Read())
            {
                attendance.Add(new Attendance(
                    reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(),
                   reader[4].ToString(), reader[5].ToString(), reader[6].ToString()));
            }
            reader.Close();
            return attendance;
        }
        public bool deleteAttendance()
        {
            string quary = "exec DeleteAattendance '" + this.attendanceID + "'";
            bool result = new SystemDAL().executeNonQueryS(quary);
            return result;

        }
    }
}
