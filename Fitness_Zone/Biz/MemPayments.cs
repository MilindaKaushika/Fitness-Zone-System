using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fitness_Zone.DAL;
using System.Data.SqlClient;

namespace Fitness_Zone.Biz
{
    class MemPayments
    {
        private string paymentID;
        public string _PaymentID
        {
            get { return paymentID; }
            set { paymentID = value; }
        }
        private string dueDate;
        public string _DueDate
        {
            get { return dueDate; }
            set { dueDate = value; }
        }
        private string paidDate;
        public string _PaidDate
        {
            get { return paidDate; }
            set { paidDate = value; }
        }
        private string paymentStatus;
        public string _PaymentStatus
        {
            get { return paymentStatus; }
            set { paymentStatus = value; }
        }
        private double total;
        public double _Total
        {
            get { return total; }
            set { total = value; }
        }
        private string cid;
        public string _Cid
        {
            get { return cid; }
            set { cid = value; }
        }
        private string fn;
        public string _Fn
        {
            get { return fn; }
            set { fn = value; }
        }
        public MemPayments() { }

        public MemPayments(string id)
        {
            this.paymentID = id;
        }
        public MemPayments(string id, string dueDate, string paidDate, string paymentStatus, double total, string cid, string fn)
        {
            this.paymentID = id;
            this.dueDate = dueDate;
            this.paidDate = paidDate;
            this.paymentStatus = paymentStatus;
            this.total = total;
            this.cid = cid;
            this.fn = fn;
        }

        public bool addNewPayments()
        {
            string quary = "exec AddPayments'" + this.paymentID + "','" + this.dueDate + "','" + this.paidDate + "','" + this.paymentStatus + "'," + this.total + ",'" + this.cid + "','" + this.fn + "'";
            bool result = new SystemDAL().executeNonQueryS(quary);
            return result;
    
        }
        public List<MemPayments> getAllPayments()
        {
            List<MemPayments> Payment = new List<MemPayments>();
            string quary = "exec searchAllPayments";
            SqlDataReader reader = new SystemDAL().executeQueryS(quary);

            // for many records go with while loop
            while (reader.Read())
            {
                Payment.Add(new MemPayments(
                    reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(),
                    Convert.ToDouble(reader[4].ToString()),reader[5].ToString(),reader[6].ToString()));
            }
            reader.Close();
            return Payment;
        }
        public bool updatePayment()
        {
            string quary = "exec updatepayments '" + this.paymentID + "','" + this.dueDate + "','" + this.paidDate + "','" + this.paymentStatus + "'," + this.total + ",'" + this.cid + "','" + this.fn + "'";
            bool result = new SystemDAL().executeNonQueryS(quary);
            return result;

        }
        public MemPayments getAllPaymentsId(string Id)
        {
            MemPayments pro = null;
            string quary = "exec searchpaymentbyId '" + Id + "'";
            SqlDataReader reader = new SystemDAL().executeQueryS(quary);

            // for many records go with while loop
            if (reader.Read())
            {
                pro = new MemPayments(
                   reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(),
                    Convert.ToDouble(reader[4].ToString()), reader[5].ToString(), reader[6].ToString());
            }
            reader.Close();
            return pro;
        }
    }
}
