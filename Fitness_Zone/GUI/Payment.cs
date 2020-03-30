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
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
            dataGridView2.DataSource = new Paymentbalance().getAllPaymentsbalance();
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView3.DataSource = new MemPayments().getAllPayments();
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.DataSource = new MemPayments().getAllPayments();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView4.DataSource = new Paymentbalance().getAllPaymentsbalance();
            dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        public void clearText()
        {
            txtPayNo.Text = "";
            dtpdue.Focus();
            textBox1.Text = "";
            txtAmo.Text = "";
            txtmemId.Text = "";
            txtmename.Text = "";
            textpaymentno.Text = "";
            textname.Text = "";
            textfullpayment.Text = "";
        
        }
        private void button12_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            member pro = new member().findmemberById(txtmemId.Text);
            if (pro != null)
            {
                txtmename.Text = pro.FirstName;

            }
            else
            {
                MessageBox.Show("No such Item");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new MemPayments().getAllPayments();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (new MemPayments(txtPayNo.Text, dtpdue.Text, dtppaid.Text, textBox1.Text, Convert.ToDouble(txtAmo.Text), txtmemId.Text, txtmename.Text).addNewPayments())
            {
                MessageBox.Show("Save successfully");
            }
            else
            {
                MessageBox.Show("Error!!!!");
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                MemPayments pro = new MemPayments().getAllPaymentsId(textpaymentno.Text);
                if (pro != null)
                {
         
                    textpaymentno.Text = pro._PaymentID;
                    textname.Text = pro._Fn;
                    textfullpayment.Text = pro._Total.ToString();

                }
                else
                {
                    MessageBox.Show("Incorrect Payments ID");
                    textpaymentno.Clear();
               
                }
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                try
                {
                    double up = Convert.ToDouble(textfullpayment.Text);
                    double qua = Convert.ToDouble(textpayed.Text);
                    double tot = up - qua;
                    label15.Text = tot.ToString();
                 
                }
                catch
                {
                    clearText();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (new Paymentbalance(textBalance.Text, textpaymentno.Text, textname.Text, 
                feesmode.Text,dateTimePicker1.Text, Convert.ToDouble(textfullpayment.Text), Convert.ToDouble(textpayed.Text), Convert.ToDouble(label15.Text)).createPaymentbalance())
            {
                textBalance.Text = "";
                textpaymentno.Text = "";
                textname.Text = "";
                textfullpayment.Text = "";
                feesmode.Text = "";
                textpayed.Text = "";
                label15.Text = "";
                MessageBox.Show("Save successfully");
            }
            else
            {
                MessageBox.Show("Error!!!!");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = (dataGridView1.CurrentRow.Cells[0].FormattedValue.ToString());
            MemPayments pro = new MemPayments().getAllPaymentsId(id);
            if (pro != null)
            {
                textpaymentno.Text = pro._PaymentID;
                textname.Text = pro._Fn;
                textfullpayment.Text = pro._Total.ToString();
            }
            else
            {
                MessageBox.Show("No Such Item");
            }
                
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (new MemPayments(txtPayNo.Text, dtpdue.Text, dtppaid.Text, textBox1.Text, Convert.ToDouble(txtAmo.Text), txtmemId.Text, txtmename.Text).updatePayment())
            {
                MessageBox.Show(txtPayNo.Text + " updated successfully ");
            }
            else
            {
                MessageBox.Show("Error Encounted ");

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int A = 0, B = 0;
            for(A =0;A <dataGridView2.Rows.Count;++A)
            {
                B += Convert.ToInt32(dataGridView2.Rows[A].Cells[6].Value);
            }
            label21.Text = B.ToString();
        }

       

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
       
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int A = 0, B = 0;
            for (A = 0; A < dataGridView4.Rows.Count; ++A)
            {
                B += Convert.ToInt32(dataGridView4.Rows[A].Cells[6].Value);
            }
            label23.Text = B.ToString();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                dataGridView4.DataSource = new Paymentbalance().getAllPaymentdate(comboBox1.Text);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            dataGridView4.DataSource = new Paymentbalance().getAllPaymentsbalance();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = new Paymentbalance().getAllPaymentsbalance();
            dataGridView3.DataSource = new MemPayments().getAllPayments();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                dataGridView2.DataSource = new Paymentbalance().getAllPaymentID(textBox2.Text);
            }
        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
            string id = (dataGridView2.CurrentRow.Cells[0].FormattedValue.ToString());
            Paymentbalance pro = new Paymentbalance().findAPaymentbalanceById(id);
            if (pro != null)
            {
                textBalance.Text = pro._BalcID;
                textpaymentno.Text = pro._PaymentID;
                textname.Text = pro._Fn;
                textfullpayment.Text = pro._Total.ToString();
                feesmode.Text = pro._Feesmode;
                textpayed.Text = pro._Paid.ToString();
                label15.Text = pro._Balance.ToString();
            }
            else
            {
                MessageBox.Show("No Such Item");
            }
                
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (new Paymentbalance(textBalance.Text, textpaymentno.Text, textname.Text,
                feesmode.Text, dateTimePicker1.Text, Convert.ToDouble(textfullpayment.Text), Convert.ToDouble(textpayed.Text), Convert.ToDouble(label15.Text)).updatePaymentbalance())
            {
                textBalance.Text = "";
                textpaymentno.Text = "";
                textname.Text = "";
                textfullpayment.Text = "";
                feesmode.Text = "";
                textpayed.Text = "";
                label15.Text = "";
                MessageBox.Show(textBalance.Text + " updated successfully ");
            }
            else
            {
                MessageBox.Show("Error Encounted ");

            }
        }
    }
}