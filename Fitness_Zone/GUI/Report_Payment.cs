using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fitness_Zone.GUI
{
    public partial class Report_Payment : Form
    {
        public Report_Payment()
        {
            InitializeComponent();
        }

        private void Report_Payment_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'gymDataSet.outstandingbalance' table. You can move, or remove it, as needed.
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.outstandingbalanceTableAdapter.Fill(this.gymDataSet.outstandingbalance,textBox1.Text.ToString());

            this.reportViewer1.RefreshReport();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
