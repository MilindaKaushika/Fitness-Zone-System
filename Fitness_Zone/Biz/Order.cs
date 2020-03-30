using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Fitness_Zone.DAL;

namespace Fitness_Zone.Biz
{
    class Order
    {
        private string OrderId;

        public string _OrderId
        {
            get { return OrderId; }
            set { OrderId = value; }
        }


        private string OrderDate;

        public string _OrderDate
        {
            get { return OrderDate; }
            set { OrderDate = value; }
        }

        private double Amount;

        public double _Amount
        {
            get { return Amount; }
            set { Amount = value; }
        }
        private List<LineProduct> Products;

        public List<LineProduct> _Products
        {
            get { return Products; }
            set { Products = value; }
        }



        public Order() { }

        public Order(string oid, string odate, double amount)
        {
            this.OrderId = oid;
            this.OrderDate = odate;
            this.Amount = amount;
        }

        public Order(string oid, string odate)
        {
            this.OrderId = oid;
            this.OrderDate = odate;
            this.Amount = 0.0;
        }

        public Order(string oid, string odate, double amount, List<LineProduct> ps)
        {
            this.OrderId = oid;
            this.OrderDate = odate;
            this.Amount = amount;
            this.Products = ps;
        }

        public Order(string oid, double amount)
        {
            this.OrderId = oid;

            this.Amount = amount;
        }
        public Order(string oid, List<LineProduct> ps, double amount)
        {
            this.OrderId = oid;
            this.Products = ps;
            this.Amount = amount;
        }
        public bool createNewOrder()
        {
            string quary = "insert into OrderTb values('" + this.OrderId + "','" + this.OrderDate + "'," + this.Amount + ")";
            bool result = new SystemDAL().executeNonQueryS(quary);
            return result;
        }
        public bool UpdateOrder()
        {
            string quary = "update OrderTb set Amount=" + this.Amount + " where orderId= '" + this.OrderId + "'";
            bool result = new SystemDAL().executeNonQueryS(quary);
            return result;
        }
        public bool deleteorder()
        {
            string quary = "exec deleteOrder '" + this._OrderId + "'";
            bool result = new SystemDAL().executeNonQueryS(quary);
            return result;

        }

        public double addToOrder(LineProduct line, string oid)
        {
            double amount = 0.0;
            String quary = "insert into LineProductTb values('" + oid + "','" + line._product.EquipID + "'," + line._Quantity + "," + line._total + ")";
            bool result = new SystemDAL().executeNonQueryS(quary);
            if (result)
            {
                string getTotalAmount = "select sum(Total) from LineProductTb where orderId='" + oid + "'";
                SqlDataReader reader = new SystemDAL().executeQueryS(getTotalAmount);
                if (reader.Read())
                {
                    amount = Convert.ToDouble(reader[0]);
                }
                reader.Close();

            }
            return amount;

        }
        public List<Order> addToList(string id)
        {
            List<Order> odr = new List<Order>();

            string quary = "exec AddProductTb'" + id + "'";
            SqlDataReader reader = new SystemDAL().executeQueryS(quary);
            while (reader.Read())
            {
                odr.Add(new Order(
                    reader[0].ToString(), reader[1].ToString(), Convert.ToDouble(reader[2].ToString())));

            }
            reader.Close();
            return odr;


        }
        public List<Order> getAllProducts()
        {
            List<Order> Order = new List<Order>();

            string quary = "exec searchAllOrders";
            SqlDataReader reader = new SystemDAL().executeQueryS(quary);
            while (reader.Read())
            {

                Order.Add(new Order(

                    reader[0].ToString(), reader[1].ToString(),
                    Convert.ToDouble(reader[2].ToString())));
            }
            reader.Close();
            return Order;


        }
    }
}
