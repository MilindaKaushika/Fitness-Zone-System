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
using System.Data.SqlClient;

namespace Fitness_Zone.GUI
{
    public partial class Mainpage : Form
    {
        public Mainpage()
        {
            InitializeComponent();
            gbUG.Enabled = true;
            gbPG.Enabled = false;
            dtpOrder.Value = DateTime.Today;
            disable();
            dgvProduct.DataSource = new Equipment().getAllEquipment();
            dgvProduct.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrderDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dadEquipment.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrderDetails.DataSource = new Order().getAllProducts();
            dgvOrderDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            proGridView3.DataSource = new Order().getAllProducts();
            proGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            dadEquipment.DataSource = new Equipment().getAllEquipment();
            dadEquipment.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataAttendace.DataSource = new Attendance().getAllattendancedetails();
            dataAttendace.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            dgvannualRecord.DataSource = new member().getAllmemberdetails();
            dgvannualRecord.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            dgvmemberRecord.DataSource = new ViewAnnual().getAllannualdetails();
            dgvmemberRecord.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvsixmonth.DataSource = new Viewsix_month().getAllsix_monthdetails();
            dgvsixmonth.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        public void enable()
        {
            txtProductId.Enabled = true;
            txtQuantity.Enabled = true;
            txtTotal.Enabled = true;
        }
        public void disable()
        {
            txtProductId.Enabled = false;
            txtProductName.Enabled = false;
            txtQuantity.Enabled = false;
            txtTotal.Enabled = false;
            txtUnitPrice.Enabled = false;
            textBox3.Enabled = false;
            textBox2.Enabled = false;
            textBox5.Enabled = false;
        }
        public void clearText()
        {
            txtProductId.Text = "";
            txtProductId.Focus();
            txtProductName.Text = "";
            txtQuantity.Text = "";
            txtTotal.Text = "";
            txtUnitPrice.Text = "";
            dgvProduct.DataSource = new Equipment().getAllEquipment();
        }
        
        
        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
        }

       

        private void button3_Click(object sender, EventArgs e)
        {
            user frm = new user();
            frm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel1.Visible = true;
            panel3.Visible = true;
            panel4.Visible = false;
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }

      
        private void button13_Click(object sender, EventArgs e)
        {
            dgvmemberRecord.DataSource = new member().getAllmemberdetails();

        }

     
        private void button20_Click(object sender, EventArgs e)
        {

            
        }

        private void button16_Click(object sender, EventArgs e)
        {
         
        }

       

        private void rdoUG_CheckedChanged_1(object sender, EventArgs e)
        {
            gbUG.Enabled = true;
            gbPG.Enabled = false;
        }

        private void rdoPG_CheckedChanged_1(object sender, EventArgs e)
        {
            gbUG.Enabled = false;
            gbPG.Enabled = true;
        }

      

        private void button17_Click(object sender, EventArgs e)
        {
            member stuObj = null;
            bool result = false;
            string gen = null;
            if (rdoMale.Checked) { gen = "Male"; } else if (rdoFemale.Checked) { gen = "Female"; }

            if (rdoUG.Checked)
            {
                stuObj = new Annual(txtSid.Text, txtFname.Text, txtLname.Text, dtpDateOfBirth.Text,
                    Convert.ToInt32(txtAge.Text), txtTele.Text, txtAddress.Text, gen, name.Text,
                        Convert.ToInt32(txtduration.Text), comboBox1.Text, txtstatus.Text);
            }
            else if (rdoPG.Checked)
            {
                stuObj = new six_month(txtSid.Text, txtFname.Text, txtLname.Text, dtpDateOfBirth.Text,
                    Convert.ToInt32(txtAge.Text), txtTele.Text, txtAddress.Text, gen, txtsix.Text,
                        Convert.ToInt32(txtsixdu.Text), comboBox2.Text, txtsixsta.Text);
            }
            result = stuObj.updatemembers();
            if (result)
            {
                MessageBox.Show(txtSid.Text + " has been updated");
            }
            else
            {
                MessageBox.Show("Error Encountered");
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            dgvannualRecord.DataSource = new member().getAllmemberdetails();
            dgvmemberRecord.DataSource = new ViewAnnual().getAllannualdetails();
            dgvsixmonth.DataSource = new Viewsix_month().getAllsix_monthdetails();

        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                member stuObj = null;
                bool result = false;
                string gen = null;
                if (rdoMale.Checked) { gen = "Male"; } else if (rdoFemale.Checked) { gen = "Female"; }

                if (rdoUG.Checked)
                {
                    stuObj = new Annual(txtSid.Text, txtFname.Text, txtLname.Text, dtpDateOfBirth.Text,
                        Convert.ToInt32(txtAge.Text), txtTele.Text, txtAddress.Text, gen, name.Text,
                        Convert.ToInt32(txtduration.Text), comboBox1.Text, txtstatus.Text);
                }
                else if (rdoPG.Checked)
                {
                    stuObj = new six_month(txtSid.Text, txtFname.Text, txtLname.Text, dtpDateOfBirth.Text,
                        Convert.ToInt32(txtAge.Text), txtTele.Text, txtAddress.Text, gen, txtsix.Text,
                        Convert.ToInt32(txtsixdu.Text), comboBox2.Text, txtsixsta.Text);
                }
                result = stuObj.register();
                if (result)
                {
                    MessageBox.Show("Member has been successfully entered");
                }
                else
                {
                    MessageBox.Show("Insert Failed Try again...");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      

   
        private void button2_Click(object sender, EventArgs e)
        {
            Trainerdetails frm = new Trainerdetails();
            frm.ShowDialog();
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Payment frm = new Payment();
            frm.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvmemberRecord_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = (dgvmemberRecord.CurrentRow.Cells[0].FormattedValue.ToString());
            member pro = new member().findmemberById(id);
            if (pro != null)
            {
                txtSid.Text = pro.MemberID;
                txtFname.Text = pro.FirstName;
                txtLname.Text = pro.LastName;
                txtTele.Text = pro.TelephoneNo;
                txtAge.Text = pro.Age.ToString();
                txtAddress.Text = pro.Address;
            }
            else
            {
                MessageBox.Show("No Such Item");
            }
                
                
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = true;
            panel4.Visible = false;
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            if (new Equipment(textProId.Text, txtPronam.Text, Convert.ToDouble(txtpri.Text)).addNewEquipments())
            {
                MessageBox.Show("New product updated successfully ");
            }
            else
            {
                MessageBox.Show("Error Encounted ");
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {

        
        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if ((!(txtOrderId.Enabled)) & txtOrderId.Text != "" & (txtProductId.Enabled))
            //{
            //    string id = (dgvProduct.CurrentRow.Cells[0].FormattedValue.ToString());
            //    Equipment pro = new Equipment().findAProductById(id);
            //    if (pro != null)
            //    {
            //        txtProductId.Text = pro._productId;
            //        txtProductName.Text = pro._productName;
            //        txtUnitPrice.Text = pro._price.ToString();
            //    }
            //}
        }

        private void dtpOrder_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool result = new Order(txtOrderId.Text, dtpOrder.Text).createNewOrder();
            if (result)
            {
                enable();
                txtProductId.Focus();
            }
        }

        private void txtProductId_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                try
                {
                    double up = Convert.ToDouble(txtUnitPrice.Text);
                    double qua = Convert.ToDouble(txtQuantity.Text);
                    double tot = up * qua;
                    txtTotal.Text = tot.ToString();
                    lbbTotal.Text = tot.ToString();
                    txtTotal.Focus();
                }
                catch
                {
                    clearText();
                }
            }
        }

        private void txtTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                double amt = 0.0;
                LineProduct line = new LineProduct(new Equipment(txtProductId.Text), Convert.ToDouble(txtQuantity.Text), Convert.ToDouble(txtTotal.Text));

                Order o = new Order(txtOrderId.Text, amt = new Order().addToOrder(line, txtOrderId.Text));
                clearText();
                o.UpdateOrder();
                lbbTotal.Text = amt.ToString();

                if (txtOrderId.Text != "")
                {
                    dgvOrderDetails.DataSource = new Order().addToList(txtOrderId.Text);
                }

            }
        }

        private void dtpOrder_ValueChanged(object sender, EventArgs e)
        {
            enable();
            txtProductId.Focus();
        }

        private void txtOrderId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                dtpOrder.Select();
                txtOrderId.Enabled = false;
            }
        }

        private void txtProductId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                txtQuantity.Focus();
                Equipment pro = new Equipment().findAEquipmentById(txtProductId.Text);
                if (pro != null)
                {
                    txtProductName.Text = pro.EquipName;
                    txtUnitPrice.Text = pro.Price.ToString();
                }
                else
                {
                    txtProductId.Clear();
                    txtProductId.Focus();
                }
            }
        }

        private void txtOrderId_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                schedule pro = new schedule().findscheduleById(textBox1.Text);
                if (pro != null)
                {
            
                    textBox3.Text = pro._Trainername;
                    textBox2.Text = pro._Name;
                    textBox5.Text = pro._Time;
                    disable();
                }
                else
                {
                    MessageBox.Show("Incorrect Schedule ID");

                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            if (textBox6.Text != "")
            {
                dadEquipment.DataSource = new Equipment().findAEquipmentById(textBox6.Text);
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            Schedule frm = new Schedule();
            frm.ShowDialog();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Trainer pro = new Trainer().createNewOrder();
            //if (pro != null)
            //{
            //    comboBox3.Text = pro.Trainer_Name;

            //}
            //else
            //{
            //    MessageBox.Show("No such Item");
            //}
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string gen = "";
            if (radioButton1.Checked)
            {
                gen = "Present";
            }

            else if (radioButton2.Checked)
            {
                gen = "Absent";

            }
            if (new Attendance(textBox4.Text, textBox1.Text, textBox2.Text, textBox3.Text, dateTimePicker1.Text, textBox5.Text, gen).addAttendance())
            {
                MessageBox.Show("Save successfully");
            }
            else
            {
                MessageBox.Show("Error!!!!");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            dataAttendace.DataSource = new Attendance().getAllattendancedetails();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Reports frm = new Reports();
            frm.ShowDialog();
        }

        private void button23_Click(object sender, EventArgs e)
        {
         
            if (new member(txtSid.Text).deletemembers())
            {
                MessageBox.Show(txtSid.Text + " has been deleted");
            }
            else
            {
                MessageBox.Show("Error Encountered");
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            txtSid.Text="";
                txtFname.Text="";
                    txtLname.Text="";
                        dtpDateOfBirth.Text="";
                       txtAge.Text="";
                           txtTele.Text="";
                           txtAddress.Text = "";
                        txtduration.Text ="";
                            comboBox1.Text="";
                                txtstatus.Text="";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (new Attendance(textBox4.Text).deleteAttendance())
            {
                MessageBox.Show(textBox4.Text + "has been deleted");
            }
            else
            {
                MessageBox.Show("Error Encounted ");
            }
        }
    }
}
 