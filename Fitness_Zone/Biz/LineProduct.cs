using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Fitness_Zone.Biz
{
    class LineProduct
    {
        private Equipment product;

        public Equipment _product
        {
            get { return product; }
            set { product = value; }
        }

        private double Quantity;

        public double _Quantity
        {
            get { return Quantity; }
            set { Quantity = value; }
        }

        private double total;

        public double _total
        {
            get { return total; }
            set { total = value; }
        }

        public LineProduct() { }
        public LineProduct(Equipment p, double qua, double tot)
        {
            this.product = p;
            this.Quantity = qua;
            this.total = tot;
        }
    }
}