using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fitness_Zone.Biz;


namespace Fitness_Zone.GUI
{
    public partial class user : Form
    {
        public user()
        {
            InitializeComponent();
            dataGridView1.DataSource = new User().getAllusers();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (new User(textBox1.Text, textBox2.Text, comboBox1.Text, textBox3.Text, textBox4.Text).addUsers())
            {
                textBox1.Text = "";
                textBox2.Text = "";
                comboBox1.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";

                MessageBox.Show("Save successfully");

            }
            else
            {
                MessageBox.Show("Error!!!!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}