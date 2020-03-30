namespace Fitness_Zone.GUI
{
    partial class Report_Attendance
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.aattendanceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gymDataSet = new Fitness_Zone.GymDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.aattendanceTableAdapter = new Fitness_Zone.GymDataSetTableAdapters.AattendanceTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.aattendanceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gymDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // aattendanceBindingSource
            // 
            this.aattendanceBindingSource.DataMember = "Aattendance";
            this.aattendanceBindingSource.DataSource = this.gymDataSet;
            // 
            // gymDataSet
            // 
            this.gymDataSet.DataSetName = "GymDataSet";
            this.gymDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "stu_attendance";
            reportDataSource1.Value = this.aattendanceBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Fitness_Zone.GUI.Reports.Attendance.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(982, 557);
            this.reportViewer1.TabIndex = 0;
            // 
            // aattendanceTableAdapter
            // 
            this.aattendanceTableAdapter.ClearBeforeFill = true;
            // 
            // Report_Attendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 557);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Report_Attendance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report_Attendance";
            this.Load += new System.EventHandler(this.Report_Attendance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.aattendanceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gymDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private GymDataSet gymDataSet;
        private System.Windows.Forms.BindingSource aattendanceBindingSource;
        private GymDataSetTableAdapters.AattendanceTableAdapter aattendanceTableAdapter;
    }
}