using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Fitness_Zone.Biz;

namespace Fitness_Zone.GUI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                User usr = new User().login(txtUserName.Text, txtpassword.Text);


                if (usr != null)
                {

                    Mainpage main = new Mainpage();
                    Hide();
                    main.ShowDialog();
                    Dispose();



                }
                else
                {
                    MessageBox.Show("Login Failed Try again...");
                }



                /* if (usr._Password == txtpassword.Text)
                 {
                     frmMain main = new frmMain();
                     this.Hide();
                     main.ShowDialog();
                     this.Dispose();
                 }
                 else
                 {
                     MessageBox.Show("Login Failed Try again...");
                 }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                txtpassword.Focus();
            }

        }

        private void txtpassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                btnLogin.PerformClick();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}

