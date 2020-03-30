using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fitness_Zone.DAL;
using System.Threading.Tasks;

namespace Fitness_Zone.Biz
{
    class six_month : member 
    {
        private string _currentMember;
        public string CurrentMember
        {
            get { return _currentMember; }
            set { _currentMember = value; }
        }

        private int _yearsOfExperiance;
        public int YearsOfExperiance
        {
            get { return _yearsOfExperiance; }
            set { _yearsOfExperiance = value; }
        }
        private string _fees;
        public string Fees
        {
            get { return _fees; }
            set { _fees = value; }
        }

        private string _status;
        private string p;
        public string status
        {
            get { return _status; }
            set { _status = value; }
        }

        public six_month() { }
        public six_month(string cid, string fname, string lname, string dob,
            int age, string tp, string add, string gen, string name, int duration, string fee,
            string status)
            : base(cid, fname, lname, dob, age, tp, add, gen)
        {
            this._currentMember = name;
            this._yearsOfExperiance = duration;
            this._fees = fee;
            this._status = status;
        }

        public six_month(string p)
        {
            // TODO: Complete member initialization
            this.p = p;
        }

        public override bool register()
        {
            string quary = "exec registermonth '" + this.MemberID + "','" +
                this.FirstName + "','" + this.LastName + "','" + this.DateOfBirth + "'," + this.Age + ",'" + this.TelephoneNo + "','" + this.Address + "','" +
                this.Gender + "','" + this.CurrentMember + "'," + this.YearsOfExperiance + ",'" + this.Fees + "','" + this._status + "'";

            bool result = new SystemDAL().executeNonQueryS(quary);
            return result;
        }
        public override bool updatemembers()
        {
            string quary = "exec updatesixmonth'" + this.MemberID + "','" +
                   this.FirstName + "','" + this.LastName + "','" + this.DateOfBirth + "'," +
                   this.Age + ",'" + this.TelephoneNo + "','" + this.Address + "','" +
                   this.Gender + "','" + this.CurrentMember + "'," + this.YearsOfExperiance + ",'" +
                   this.Fees + "','" + this._status + "'";
            bool result = new SystemDAL().executeNonQueryS(quary);
            return result;
        }
        

        public override member findMembers(string id)
        {
            return null;
        }
    }
}
