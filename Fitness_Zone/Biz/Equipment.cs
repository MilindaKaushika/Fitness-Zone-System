using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fitness_Zone.DAL;
using System.Data.SqlClient;

namespace Fitness_Zone.Biz
{
    class Equipment
    {
        private string _equipID;
        public string EquipID
        {
            get { return _equipID; }
            set { _equipID = value; }
        }

        private string _equipName;
        public string EquipName
        {
            get { return _equipName; }
            set { _equipName = value; }
        }
        private double _price;
        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }
        public Equipment() { }

        public Equipment(string id)
        {
            this._equipID = id;
        }
        public Equipment(string id, string equipName, double price)
        {
            this._equipID = id;
            this._equipName = equipName;
            this._price = price;
        }

        
        public bool addNewEquipments()
        {
            string quary = "exec AddEquipment '" + this._equipID + "','" + this._equipName + "'," + this._price;
            bool result = new SystemDAL().executeNonQueryS(quary);
            return result;
        }
        public List<Equipment> getAllEquipment()
        {
            List<Equipment> Equipment = new List<Equipment>();
            string quary = "exec searchAllEquipment";
            SqlDataReader reader = new SystemDAL().executeQueryS(quary);

            // for many records go with while loop
            while (reader.Read())
            {
                Equipment.Add(new Equipment(
                    reader[0].ToString(), reader[1].ToString(),
                    Convert.ToDouble(reader[2].ToString())));
            }
            reader.Close();
            return Equipment;
        }
        public Equipment findAEquipmentById(string Id)
        {

            Equipment pro = null;
            string quary = "exec searchEquipmentbyId '" + Id + "'";
            SqlDataReader reader = new SystemDAL().executeQueryS(quary);
            if (reader.Read())
            {
                pro = new Equipment(
                    reader[0].ToString(), reader[1].ToString(),
                    Convert.ToDouble(reader[2].ToString()));
            }
            reader.Close();
            return pro;
        }
      
      
    }
}
