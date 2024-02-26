using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fitness_Tracker
{
    public partial class Form2 : Form
    {
        private int click = 0;
        public Form2()
        {
            InitializeComponent();
            InitializeUI();
        }

        private void InitializeUI()
        {
            Button guna2GradientButton1 = new Button();
            guna2GradientButton1.Click += guna2GradientButton1_Click;

            Controls.Add(guna2GradientButton1);

        }

        public static string me;

        private void label5_Click(object sender, EventArgs e)
        {
            var myform = new Form3();

            this.Hide();
            myform.Show();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            try
            {
                click++;

                if (click == 3)
                {
                    MessageBox.Show("It seems like you don't have an account, Please register now", "Login Detector", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    click = 0;
                }

                if (txtpass.Text == "" || txtuser.Text == "")
                {
                    MessageBox.Show("Fields are empty, please insert", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string usern = txtuser.Text;
                    string mypass = txtpass.Text;
                    me = txtuser.Text;
                    users us = new users();
                    us.name = usern;
                    us.mypassword = mypass;

                    bool complete = us.login(usern, mypass);

                    if (complete)
                    {
                        var newf = new Form4();

                        this.Hide();
                        newf.Show();
                    }
                    else
                    {
                        txtuser.Text = "";
                        txtpass.Text = "";

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " Failed to login", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
        }

        private void Form2_Load(object sender, EventArgs e)
        {
          
            txtpass.UseSystemPasswordChar = true;

           



        }

        private void txtpass_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void seepass_Click(object sender, EventArgs e)
        {

                
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true) 
            {
                txtpass.UseSystemPasswordChar = false;
            }
            else
            {
                txtpass.UseSystemPasswordChar = true;
            }
        }
    }
}
