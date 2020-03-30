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
    public partial class Schedule : Form
    {
        public Schedule()
        {
            InitializeComponent();
            dataGridView1.DataSource = new schedule().getAllScheduledetails();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                Trainer pro = new Trainer().findTrainerById(textBox2.Text);
                if (pro != null)
                {
                    textBox3.Text = pro._Date;
                    textBox4.Text = pro._Trainername ;
                    textBox5.Text = pro._Name;
                    textBox6.Text = pro._Time;

                }
                else
                {
                    MessageBox.Show("Incorrect Schedule ID");

                }
            }
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (new schedule(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, txtTrastutes.Text).registerSchedule())
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                txtTrastutes.Text = "";
                MessageBox.Show("Save successfully");

            }
            else
            {
                MessageBox.Show("Error!!!!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (new schedule(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, txtTrastutes.Text).Updateschedule())
            {
                MessageBox.Show(" updated successfully ");
            }
            else
            {
                MessageBox.Show("Error Encounted ");

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            txtTrastutes.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (new schedule(textBox1.Text).deleteschedule())
            {
                MessageBox.Show(textBox1.Text + "has been deleted");
            }
            else
            {
                MessageBox.Show("Error Encounted ");
            }
        }
    }
}
