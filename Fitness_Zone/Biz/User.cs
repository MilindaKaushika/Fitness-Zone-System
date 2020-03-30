using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Fitness_Zone.DAL;

namespace Fitness_Zone.Biz
{
    class User
    {
        private string userID;
        public string _userID
        {
            get { return userID; }
            set { userID = value; }
        }

        private string UserName;
        public string _UserName
        {
            get { return UserName; }
            set { UserName = value; }
        }

        private string Password;
        public string _Password
        {
            get { return Password; }
            set { Password = value; }
        }
        private string email;
        public string _email
        {
            get { return email; }
            set { email = value; }
        }
        private string type;
        public string _Type
        {
            get { return type; }
            set { type = value; }
        }
        public User() { }
        public User(string username, string password)
        {
            //this.UserID = UserID;
            this.UserName = username;
            this.Password = password;
         
        }
        public User(String UserID, string username, string password, string Email, string type)
        {
            //this.UserID = UserID;
            this.userID = UserID;
            this.UserName = username;
            this.Password = password;
            this.email = Email;
            this.type = type;
        
        }

        public User login(string username, string password)
        {
            User usr = null;
            string quary = "exec users '" + username + "','" + password + "'";
            SqlDataReader reader = new SystemDAL().executeQueryS(quary);
            if (reader.Read())
            {
                usr = new User(
                    reader[0].ToString(), reader[1].ToString());


            }
            reader.Close();
            return usr;

        }
        public bool addUsers()
        {
            string quary = "exec Addusers'" + this._userID + "','" + this._UserName + "','" + this._Password + "','" + this._email + "','" + this._Type + "'";
            bool result = new SystemDAL().executeNonQueryS(quary);
            return result;
        }
        public List<User> getAllusers()
        {
            List<User> usera = new List<User>();

            string quary = "exec searchAllusers";
            SqlDataReader reader = new SystemDAL().executeQueryS(quary);
            while (reader.Read())
            {

                usera.Add(new User(

                      reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString()));

            }
            reader.Close();
            return usera;
        }
    }
}