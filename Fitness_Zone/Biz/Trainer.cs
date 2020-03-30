using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fitness_Zone.DAL;
using System.Data.SqlClient;

namespace Fitness_Zone.Biz
{
    class Trainer
    {
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
        private string cid;
        public string _Cid
        {
            get { return cid; }
            set { cid = value; }
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

        public Trainer() { }

        public Trainer(string id, string Date, string trainer, string cid, string fname, string time)
        {
            this.trainnerID = id;
            this.date = Date;
            this.trainername = trainer;
            this.cid = cid;
            this.name = fname;
            this.time = time;
        }
        Trainer(string p)
        {
            // TODO: Complete member initialization
            this.p = p;
        }
        public bool registertrainer()
        {
            string quary = "exec AddTrainer '" + this._TrainnerID + "','" + this._Date + "','" + this._Trainername + "','" + this.cid + "','" + this._Name + "','" + this._Time + "'";

            bool result = new SystemDAL().executeNonQueryS(quary);
            return result;
        }
        public Trainer findTrainerById(string Id)
        {

            Trainer pro = null;
            string quary = "exec searchtrainerbyId '" + Id + "'";
            SqlDataReader reader = new SystemDAL().executeQueryS(quary);
            if (reader.Read())
            {
                pro = new Trainer(
                     reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString());

            }
            reader.Close();
            return pro;
        }

    }
}
