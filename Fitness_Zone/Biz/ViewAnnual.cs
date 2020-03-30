using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fitness_Zone.DAL;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Fitness_Zone.Biz
{
    class ViewAnnual
    {
        private string _currentMember;
        public string CurrentMember
        {
            get { return _currentMember; }
            set { _currentMember = value; }
        }

        private int _duration;
        public int Duration
        {
            get { return _duration; }
            set { _duration = value; }
        }
        private string _fees;
        public string Fees
        {
            get { return _fees; }
            set { _fees = value; }
        }

        private string _status;
        private string p;
        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public ViewAnnual() { }
        public ViewAnnual(string cid,string name, int duration, string fee,
            string status)
           
        {
            this._currentMember = name;
            this._duration = duration;
            this._fees = fee;
            this._status = status;
        }

        public ViewAnnual(string p)
        {
            // TODO: Complete member initialization
            this.p = p;
        }

       
        public List<ViewAnnual> getAllannualdetails()
        {
            List<ViewAnnual> Annual = new List<ViewAnnual>();
            string quary = "exec searchAllAnnual";
            SqlDataReader reader = new SystemDAL().executeQueryS(quary);

             //for many records go with while loop
            while (reader.Read())
            {
                Annual.Add(new ViewAnnual(
                    reader[0].ToString(), reader[1].ToString(), Convert.ToInt32(reader[2]), reader[3].ToString(), reader[4].ToString()));

            }
            reader.Close();
            return Annual;
        }
       

    }
}
