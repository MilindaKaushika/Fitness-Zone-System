using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fitness_Zone.DAL;
using System.Data.SqlClient;

namespace Fitness_Zone.Biz
{
    class Paymentbalance
    {
        private string balcID;
        public string _BalcID
        {
            get { return balcID; }
            set { balcID = value; }
        }
        private string paymentID;
        public string _PaymentID
        {
            get { return paymentID; }
            set { paymentID = value; }
        }
        private string fn;
        public string _Fn
        {
            get { return fn; }
            set { fn = value; }
        }
        private string feesmode;
        public string _Feesmode
        {
            get { return feesmode; }
            set { feesmode = value; }
        }
        private string paidDate;
        public string _PaidDate
        {
            get { return paidDate; }
            set { paidDate = value; }
        }

        private double total;
        public double _Total
        {
            get { return total; }
            set { total = value; }
        }
        private double paid;
        public double _Paid
        {
            get { return paid; }
            set { paid = value; }
        }
        private double balance;
        public double _Balance
        {
            get { return balance; }
            set { balance = value; }
        }
            public Paymentbalance() { }

            public Paymentbalance(string id)
        {
            this.balcID = id;
        }

            public Paymentbalance(string id, string paymentID, string fname, string feesmode, string date, double total, double paid, double balance)
        {

            this._BalcID = id;
            this._PaymentID = paymentID;
            this._Fn = fname;
            this._Feesmode = feesmode;
            this._PaidDate = date;
            this._Total = total;
            this._Paid = paid;
            this._Balance = balance;
               
        }
        public bool createPaymentbalance()
        {
            string quary = "exec Addoutstandingbalance '" + this._BalcID + "','" + this._PaymentID + "','" + this._Fn + "','" + this._Feesmode + "','" + this._PaidDate + "','" + this._Total + "','" + this._Paid + "'," + this._Balance;
            bool result = new SystemDAL().executeNonQueryS(quary);
            return result;
        }
        public List<Paymentbalance> getAllPaymentsbalance()
        {
            List<Paymentbalance> paymentbalance = new List<Paymentbalance>();
            string quary = "exec searchAllpaymentbalance";
            SqlDataReader reader = new SystemDAL().executeQueryS(quary);

            // for many records go with while loop
            while (reader.Read())
            {
                paymentbalance.Add(new Paymentbalance(
                    reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(),
                    Convert.ToDouble(reader[5].ToString()), Convert.ToDouble(reader[6].ToString()), Convert.ToDouble(reader[7].ToString())));
            }
            reader.Close();
            return paymentbalance;
        }
        public List<Paymentbalance> getAllPaymentdate(string date)
        {
            List<Paymentbalance> Paymentdate = new List<Paymentbalance>();
            string quary = "exec searchpaymentbydate '" + date + "'";
            SqlDataReader reader = new SystemDAL().executeQueryS(quary);

            // for many records go with while loop
            while (reader.Read())
            {
                Paymentdate.Add(new Paymentbalance(
                   reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(),
                    Convert.ToDouble(reader[5].ToString()), Convert.ToDouble(reader[6].ToString()), Convert.ToDouble(reader[7].ToString())));
            }
            reader.Close();
            return Paymentdate;
        }
        public List<Paymentbalance> getAllPaymentID(string ID)
        {
            List<Paymentbalance> pro = new List<Paymentbalance>();
            string quary = "exec searchpaybalancebyID '" + ID + "'";
            SqlDataReader reader = new SystemDAL().executeQueryS(quary);

            // for many records go with while loop
            while (reader.Read())
            {
                pro.Add(new Paymentbalance(
                   reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(),
                    Convert.ToDouble(reader[5].ToString()), Convert.ToDouble(reader[6].ToString()), Convert.ToDouble(reader[7].ToString())));
            }
            reader.Close();
            return pro;
        }
        public Paymentbalance findAPaymentbalanceById(string Id)
        {

            Paymentbalance pro = null;
            string quary = "exec searchpaybalancebyID '" + Id + "'";
            SqlDataReader reader = new SystemDAL().executeQueryS(quary);
            if (reader.Read())
            {
                pro = new Paymentbalance(
                   reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(),
                    Convert.ToDouble(reader[5].ToString()), Convert.ToDouble(reader[6].ToString()), Convert.ToDouble(reader[7].ToString()));
            }
            reader.Close();
            return pro;
        }
        public bool updatePaymentbalance()
        {
            string quary = "exec updatepaymentsbalance '" + this._BalcID + "','" + this._PaymentID + "','" + this._Fn + "','" + this._Feesmode + "','" + this._PaidDate + "','" + this._Total + "','" + this._Paid + "'," + this._Balance;
            bool result = new SystemDAL().executeNonQueryS(quary);
            return result;

        }
    }
}
