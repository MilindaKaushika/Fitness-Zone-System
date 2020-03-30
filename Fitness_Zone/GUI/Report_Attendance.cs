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
    public partial class Report_Attendance : Form
    {
        public Report_Attendance()
        {
            InitializeComponent();
        }

        private void Report_Attendance_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'gymDataSet.Aattendance' table. You can move, or remove it, as needed.
            this.aattendanceTableAdapter.Fill(this.gymDataSet.Aattendance);

            this.reportViewer1.RefreshReport();
        }
    }
}
