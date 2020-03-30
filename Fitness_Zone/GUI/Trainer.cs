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
    public partial class Trainerdetails : Form
    {
        public Trainerdetails()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                member pro = new member().findmemberById(textBox1.Text);
                if (pro != null)
                {
                    textBox2.Text = pro.FirstName;

                }
                else
                {
                    MessageBox.Show("Incorrect Member ID");

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string gen = "";
            if (checkBox1.Checked)
            {
                gen = "Monday";
            }

            else if (checkBox2.Checked)
            {
                gen = "Thursday";

            }
            else if (checkBox3.Checked)
            {
                gen = "Wednesday";

            }
            else if (checkBox4.Checked)
            {
                gen = "Tuesday";

            }
            else if (checkBox5.Checked)
            {
                gen = "Friday";

            }
            else if (checkBox5.Checked)
            {
                gen = "Saturday";

            }
            else if (checkBox5.Checked)
            {
                gen = "Sunday";

            }

            if (new Trainer(textBox4.Text, gen, comboBox1.Text, textBox1.Text, textBox2.Text, textBox3.Text).registertrainer())
            {
                MessageBox.Show("Save successfully");
            }
            else
            {
                MessageBox.Show("Error!!!!");
            }
        }

        private void Trainerdetails_Load(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
