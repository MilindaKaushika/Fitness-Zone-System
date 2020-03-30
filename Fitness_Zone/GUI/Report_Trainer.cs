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
    public partial class Report_Trainer : Form
    {
        public Report_Trainer()
        {
            InitializeComponent();
        }

        private void Report_Trainer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'gymDataSet.Trainer' table. You can move, or remove it, as needed.
            this.trainerTableAdapter.Fill(this.gymDataSet.Trainer);

            this.reportViewer1.RefreshReport();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
