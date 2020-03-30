using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Fitness_Zone.DAL;

namespace Fitness_Zone.Biz
{
    class member
    {
        private string _memberID;

        public string MemberID
        {
            get { return _memberID; }
            set { _memberID = value; }
        }

        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        private string _dateOfBirth;

        public string DateOfBirth
        {
            get { return _dateOfBirth; }
            set { _dateOfBirth = value; }
        }

        private int _age;

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        private string _telephoneNo;

        public string TelephoneNo
        {
            get { return _telephoneNo; }
            set { _telephoneNo = value; }
        }

        private string _address;

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        private string _gender;

        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }
     
        public member() { }
        public member(string memberID)
        {
            this._memberID = memberID;
        }
       
        public member(string cid, string fname, string lname, string dob, int age, string tp, string add, string gen)
        {
        
            this._memberID = cid;
            this._firstName = fname;
            this._lastName = lname;
            this._dateOfBirth = dob;
            this._age = age;
            this._telephoneNo = tp;
            this._address = add;
            this._gender = gen;
     

        }
        public virtual bool register()
        {
            return false;
        }
       
        public virtual bool updatemembers()
        {
            return false;
        }
        public  bool deletemembers()
        {
            string quary = "exec deletememberDetails '" + this.MemberID + "'";
            bool result = new SystemDAL().executeNonQueryS(quary);
            return result;
        }

        public List<member> getAllmemberdetails()
        {
            List<member> Memebers = new List<member>();
            string quary = "exec searchAllMemberDetails";
            SqlDataReader reader = new SystemDAL().executeQueryS(quary);

            // for many records go with while loop
            while (reader.Read())
            {
                Memebers.Add(new member(
                    reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), Convert.ToInt32(reader[4].ToString()), reader[5].ToString(), reader[6].ToString(), reader[7].ToString()));

            }
            reader.Close();
            return Memebers;
        }
        public member findmemberById(string Id)
        {

            member pro = null;
            string quary = "exec searchmemberbyId '" + Id + "'";
            SqlDataReader reader = new SystemDAL().executeQueryS(quary);
            if (reader.Read())
            {
                pro = new member(
                     reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), Convert.ToInt32(reader[4].ToString()), reader[5].ToString(), reader[6].ToString(), reader[7].ToString());

            }
            reader.Close();
            return pro;
        }
        public virtual member findMembers(string id)
        {
            return null;
        }

    }
}
