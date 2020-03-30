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
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Report_Member frm = new Report_Member();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Report_Payment frm = new Report_Payment();
            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Report_Attendance frm = new Report_Attendance();
            frm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Report_Trainer frm = new Report_Trainer();
            frm.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Report_Schedule frm = new Report_Schedule();
            frm.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Report_Equipment frm = new Report_Equipment();
            frm.ShowDialog();
        }
    }
}
