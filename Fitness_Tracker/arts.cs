using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fitness_Tracker
{
    public partial class arts : Form
    {
        public arts()
        {
            InitializeComponent();
        }

        private void arts_Load(object sender, EventArgs e)
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbldt.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
            lbldat.Text = DateTime.Now.ToLongDateString();
        }

        private void panelload_click(object sender, EventArgs e)
        {
        }

        private void panelresult_click(object sender, EventArgs e)
        {
        }

        private void panelcheck_click(object sender, EventArgs e)
        {
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

        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit();//Exiting Application
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            panelsettings.Visible = true;
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
           DialogResult  logout = MessageBox.Show("Are you sure you want to log out?", "Logging Out", MessageBoxButtons.YesNo);

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

        private void btnhome_Click(object sender, EventArgs e)
        {
            var fm = new Form4();
            this.Hide();
            fm.Show();
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

        private void btnscalorie_Click(object sender, EventArgs e)
        {
            try
            {
                double ans;

                //Creating an object from calculation class
                calculation cb = new calculation();
                cb.metvalue = 10.0;
                cb.weight = Convert.ToDouble(txtwalkwei.Text);
                cb.distance = Convert.ToDouble(txtwalkdist.Text);
                cb.timetkn = Convert.ToDouble(txtwalktime.Text);
                cb.works = "Karate";
                cb.dates = DateTime.Parse(txtwalkdate.Text);
                cb.comment = txtcommen.Text;
                ans = cb.cal(); //calling calculation formula
                cb.answer = ans;
                cb.keep();//Saving Data


                lblfailed.Text = "";
                lblsucc.Text = "";
                btnrestar.Visible = true;
                btnscalorie.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " save failed");
            }
  
       
        }

        private void panelresult_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnnext_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtgoal.Text == "" || txtcaltarget.Text == "")
                {
                    MessageBox.Show("Insert on empty fields");
                }
                else
                {
                    //Creating an object from usergoal class
                    usergoal ug = new usergoal();
                    ug.goalname = txtgoal.Text;
                    ug.gtarget = Convert.ToDouble(txtcaltarget.Text);
                    ug.setgoal();//saving user's goal


                    panelcheck.Visible = true;
                    panelview.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Enter Number on your target");
            }
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
                    int laps;
                    double dstance;
                    double totaldistance;
                    dstance = Convert.ToDouble(txtwalkdist.Text);
                    laps = int.Parse(txtwalkstep.Text);
                    totaldistance = laps * dstance;
                    //Creating an object from workout class
                    workout wk = new workout();
                    wk.work = "Karate";
                    wk.metv = 10.0;
                    wk.round = laps;
                    wk.weigt = Convert.ToDouble(txtwalkwei.Text);
                    wk.times = Convert.ToDouble(txtwalktime.Text);
                    wk.distant = totaldistance;
                    wk.dates = DateTime.Parse(txtwalkdate.Text);
                    wk.worksv();

                    calculation cb = new calculation();
                    double ans;
                    cb.metvalue = 10.0;
                    cb.weight = Convert.ToDouble(txtwalkwei.Text);
                    cb.distance = Convert.ToDouble(txtwalkdist.Text);
                    cb.timetkn = Convert.ToDouble(txtwalktime.Text);
                    lbldate.Text = DateTime.Now.ToLongDateString(); ;
                    ans = cb.cal();

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

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}
