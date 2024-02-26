using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shell;
using System.Windows.Forms;

namespace Fitness_Tracker
{
    public partial class Form4 : Form
    {
        OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\slamba.accdb");
        public Form4()
        {
            InitializeComponent();
        }

       

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            
            panelsettings.Visible = false;
            panelhome.Visible = false;
            paneldelet.Visible = false;
            panelactive.Visible = true;

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            timer1.Start();
            lbldt.Text = DateTime.Now.ToLongTimeString();
            lbldat.Text = DateTime.Now.ToLongDateString();
            panelactive.Visible = false;
            panelsettings.Visible = false;
            paneldelet.Visible = false;

        }

        private void btnhome_Click(object sender, EventArgs e)
        {
            panelsettings.Visible = false;
            panelactive.Visible = false;
            paneldelet.Visible = false;
            panelhome.Visible = true;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbldt.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
            lbldat.Text = DateTime.Now.ToLongDateString();
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            var fm = new walk();

            this.Hide();
            fm.Show();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            var nf = new run();

            this.Hide();
            nf.Show();
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            var nf = new swim();

            this.Hide();
            nf.Show();
        }

        private void panelsettings_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            

            var nf = new Form2();

            this.Hide();
            nf.Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            panelsettings.Visible = true;
        }

        private void guna2Button4_Click_1(object sender, EventArgs e)
        {
            panelsettings.Visible = true;
        }

        private void guna2Button9_Click_1(object sender, EventArgs e)
        {
            var nf = new swim();

            this.Hide();
            nf.Show();
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            var nf = new dancing();

            this.Hide();
            nf.Show();
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
           var nf = new jump();

            this.Hide();
            nf.Show();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            var nf = new arts();

            this.Hide();
            nf.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            var nf = new status();

            this.Hide();
            nf.Show();
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnrmv_Click(object sender, EventArgs e)
        {

            panelhome.Visible = false;
            panelactive.Visible = false;
            paneldelet.Visible = true;
        }

        private void deletbtn_Click(object sender, EventArgs e)
        {
            
                users us = new users();
                us.delname = Form2.me;
                us.delete();

                var nf = new Form2();

                this.Hide();
                nf.Show();

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
    
            panelsettings.Visible = false;
            panelhome.Visible = false;
            paneldelet.Visible = false;
            panelactive.Visible = false;
         
        }
    }
}
