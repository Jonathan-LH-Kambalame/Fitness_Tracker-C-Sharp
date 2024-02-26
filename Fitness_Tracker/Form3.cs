using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Fitness_Tracker
{
    public partial class Form3 : Form
    {
        OleDbConnection conn =  new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\KAMBALAME\source\repos\Fitness_Tracker\Fitness_Tracker\bin\Debug\fitness_store.accdb");
        public Form3()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            var myform = new Form2();

            this.Hide();
            myform.Show();
        }

        private void btnreg_Click(object sender, EventArgs e)
        {
            try
            {
                string passw;
                passw = txtpass.Text;

                if (txtusern.Text == "" || txtpass.Text == "" || txtage.Text == "" || txtgender.Text == "" || txtweight.Text == "" || txtheight.Text == "")
                {
                    MessageBox.Show("Fields are empty, please insert", "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (passw.Length != 12 || !passw.Any(char.IsLower) || !passw.Any(char.IsUpper)) 
                {
                    MessageBox.Show("Password is not valid. Please ensure it is of length twelve (12) characters and contains at least one (1) lowercase and one (1) uppercase letter.", "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtpass.Focus();
                }
                else if (txtpass.Text == txtconfpass.Text)
                {
                    users us = new users();

                    us.name = txtusern.Text;
                    us.mypassword = txtpass.Text;
                    us.age = int.Parse(txtage.Text);
                    us.gender = txtgender.Text;
                    us.weight = Convert.ToDouble(txtweight.Text);
                    us.height = Convert.ToDouble(txtheight.Text);
                    us.register();

                    var newf = new Form2();

                    this.Hide();
                    newf.Show();
                }
                else
                {
                    MessageBox.Show("Insert the same password in both fields", "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtpass.Text = "";
                    txtconfpass.Text = "";
                    txtpass.Focus();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " Please insert Realnumbers");
            }
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
         Application.Exit();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            txtpass.UseSystemPasswordChar = true;
            txtconfpass.UseSystemPasswordChar = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked == true) 
            {
                txtpass.UseSystemPasswordChar = false;
                txtconfpass.UseSystemPasswordChar = false;
            }
            else
            {
                txtpass.UseSystemPasswordChar = true;
                txtconfpass.UseSystemPasswordChar = true;
            }
        }
    }
}
