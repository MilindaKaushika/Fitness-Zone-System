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
    public partial class Report_Schedule : Form
    {
        public Report_Schedule()
        {
            InitializeComponent();
        }

        private void Report_Schedule_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'gymDataSet.Schedule' table. You can move, or remove it, as needed.
            this.scheduleTableAdapter.Fill(this.gymDataSet.Schedule);

            this.reportViewer1.RefreshReport();
        }
    }
}
