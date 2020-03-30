using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fitness_Zone.DAL;
using System.Data.SqlClient;

namespace Fitness_Zone.Biz
{
    class schedule 
    {
        private string scheduleID;
        public string _ScheduleID
        {
            get { return scheduleID; }
            set { scheduleID = value; }
        }
        private string trainnerID;
        public string _TrainnerID
        {
            get { return trainnerID; }
            set { trainnerID = value; }
        }
                    
        private string date;
        public string _Date
        {
            get { return date; }
            set { date = value; }
        }
        private string trainername;
        public string _Trainername
        {
            get { return trainername; }
            set { trainername = value; }
        }
        private string name;
        public string _Name
        {
            get { return name; }
            set { name = value; }
        }
        private string time;
        private string p;
        public string _Time
        {
            get { return time; }
            set { time = value; }
        }
        private string schedulstatus;
        public string _Schedulstatus
        {
            get { return schedulstatus; }
            set { schedulstatus = value; }
        }
        public schedule() { }

        public schedule(string id, string trainnerID, string date, string trainername, string  fname, string time, string schedulstatus)
                    
        {
            this.scheduleID = id;
            this.trainnerID = trainnerID;
            this.date = date;
            this.trainername = trainername;
            this.name = fname;
            this.time = time;
            this.schedulstatus = schedulstatus;
        }
        public schedule(string p)
        {
            // TODO: Complete member initialization
            this.p = p;
        }
        public bool registerSchedule()
        {
            // TODO: Insert Schedule details
            string quary = "exec AddSchedule '" + this._ScheduleID + "','" + this._TrainnerID + "','" + this._Date + "','" + this._Trainername + "','" + this._Name + "','" + this._Time + "','" + this._Schedulstatus + "'";

            bool result = new SystemDAL().executeNonQueryS(quary);
            return result;
        }

        public List<schedule> getAllScheduledetails()
        {
            // TODO: Get All Schedule details
            List<schedule> schedules = new List<schedule>();
            string quary = "exec searchAllSchedule";
            SqlDataReader reader = new SystemDAL().executeQueryS(quary);

            // for many records go with while loop
            while (reader.Read())
            {
                schedules.Add(new schedule(
                    reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(),
                   reader[4].ToString(), reader[5].ToString(), reader[6].ToString()));
            }
            reader.Close();
            return schedules;
        }
        public bool Updateschedule()
        {
            // TODO: Get All Update schedule details
            string quary = "exec updateSchedule'" + this._ScheduleID + "','" + this._TrainnerID + "','" + this._Date + "','" + this._Trainername + "','" + this._Name + "','" + this._Time + "','" + this._Schedulstatus + "'";    
            bool result = new SystemDAL().executeNonQueryS(quary);
            return result;
        }
        public bool deleteschedule()
        {
            // TODO: Get All Delete schedule details
            string quary = "exec Deleteschedule '" + this._ScheduleID + "'";
            bool result = new SystemDAL().executeNonQueryS(quary);
            return result;

        }
        public schedule findscheduleById(string Id)
        {
            // TODO: Get Search schedule details by Id

            schedule pro = null;
            string quary = "exec searchschedulebyId '" + Id + "'";
            SqlDataReader reader = new SystemDAL().executeQueryS(quary);
            if (reader.Read())
            {
                pro = new schedule(
                     reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(),reader[6].ToString());

            }
            reader.Close();
            return pro;
        }
    }
}
