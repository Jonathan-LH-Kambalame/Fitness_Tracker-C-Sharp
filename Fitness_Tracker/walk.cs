﻿using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;

namespace Fitness_Tracker
{
    public partial class walk : Form
    {
        public walk()
        {
            InitializeComponent();
        }

        private void panelinst_Paint(object sender, PaintEventArgs e)
        {

        }

        private void walk_Load(object sender, EventArgs e)
        {
            timer1.Start();
            lbldt.Text = DateTime.Now.ToLongTimeString();
            lbldat.Text = DateTime.Now.ToLongDateString();
             panelcheck.Visible = false;
            panelresult.Visible = false;
            btnrestar.Visible = false;
            panelsettings.Visible = false;
            panelload.Visible = false;
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try 
            {
                if (txtwalkstep.Text == "" || txtwalkwei.Text == "" || txtwalkdist.Text == "" || txtwalktime.Text == "" || txtwalkdate.Text == "")
                {
                    MessageBox.Show("Insert on empty fields");
                }
                else
                {
                    workout wk = new workout();
                    wk.work = "Walking";
                    wk.metv = 3.0;
                    wk.round = int.Parse(txtwalkstep.Text);
                    wk.weigt = Convert.ToDouble(txtwalkwei.Text);
                    wk.times = Convert.ToDouble(txtwalktime.Text);
                    wk.distant = Convert.ToDouble(txtwalkdist.Text);
                    wk.dates = DateTime.Parse(txtwalkdate.Text);
                    wk.worksv();

                    calculation cb = new calculation();
                    double ans;
                    cb.metvalue = 3.0;
                    cb.weight = Convert.ToDouble(txtwalkwei.Text);
                    cb.distance = Convert.ToDouble(txtwalkdist.Text);
                    lbldate.Text = DateTime.Now.ToLongDateString(); ;
                    ans = cb.calories();
                 

                    lblanswer.Text = ans + " Calories";

                    double goal;
                    goal = Convert.ToDouble(txtcaltarget.Text);

                    if (ans >= goal)
                    {
                        lblsucc.Text = "Congratulation! You have reached your goal";
                    }
                    else
                    {
                        lblfailed.Text = "Sorry, you haven't reached your goal";
                    }

                    panelcheck.Visible = false;
                    panelload.Visible = true;
                    timer2.Start();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Enter Number on your numbering fields");
            }
           
        }

        private void btnnext_Click(object sender, EventArgs e)
        {
        }

        private void btnnext_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (txtgoal.Text == "" ||txtcaltarget.Text == "")
                {
                    MessageBox.Show("Insert on empty fields");
                }
                else
                {
                    usergoal ug = new usergoal();
                    ug.goalname = txtgoal.Text;
                    ug.gtarget = Convert.ToDouble(txtcaltarget.Text);
                    ug.setgoal();

                    
                    panelcheck.Visible = true;
                    panelview.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Enter Number on your target");
            }

        }

        private void panelresult_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            try
            {
               double ans;
                
                calculation cb = new calculation();
                cb.works = "Walking";
                cb.metvalue = 3.0;
                cb.weight = Convert.ToDouble(txtwalkwei.Text);
                cb.distance = Convert.ToDouble(txtwalkdist.Text);
                cb.dates = DateTime.Parse(txtwalkdate.Text);
                cb.comment = txtcommen.Text;
                ans = cb.calories();
                cb.answer = ans;
                cb.keep();

                lblfailed.Text = "";
                lblsucc.Text = "";
                btnrestar.Visible = true;
                btnscalorie.Visible = false;

            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message + " Save failed");
            }
        }

        private void btnrestar_Click(object sender, EventArgs e)
        {
            panelview.Visible = true;
            panelresult.Visible = false;

            txtcaltarget.Text = "";
            txtcommen.Text = "";
            txtgoal.Text = "";
            txtwalkdist.Text = "";
            txtwalkstep.Text = "";
            txtwalktime.Text = "";
            txtwalkwei.Text = "";
            

        }

        private void btnhome_Click(object sender, EventArgs e)
        {
            var fm = new Form4();
            this.Hide();
            fm.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbldt.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
            lbldat.Text = DateTime.Now.ToLongDateString();

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            panelsettings.Visible = true;
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            DialogResult logout = MessageBox.Show("Are you sure you want to log out?", "Logging Out", MessageBoxButtons.YesNo);

            if (logout == DialogResult.Yes)
            {
                var nf = new Form2();

                this.Hide();
                nf.Show();
            }
            else
            {
                MessageBox.Show("You can Continue Dear");
            }

        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            if (ProgressBar.Value < 50)
            {
                ProgressBar.Value += 1;
            }
            else
            {
                timer2.Stop();
                panelload.Visible = false;
                panelresult.Visible = true;
            }
        }
    }
}