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
    public partial class Report_Member : Form
    {
        public Report_Member()
        {
            InitializeComponent();
        }

        private void Report_Member_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'gymDataSet.member' table. You can move, or remove it, as needed.
            this.memberTableAdapter.Fill(this.gymDataSet.member);
            // TODO: This line of code loads data into the 'gymDataSet.member' table. You can move, or remove it, as needed.
          

            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
