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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();

            panel2.Visible = false;
            btnexit.Visible = false;
            guna2Button2.Visible = false;
            guna2Button3.Visible = false;

          
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (guna2CircleProgressBar1.Value < 100)
            {
                guna2CircleProgressBar1.Value += 1;

                label3.Text = guna2CircleProgressBar1.Value.ToString() + "%";
            }
            else
            {
                timer1.Stop();
                panel1.Visible = false;
                panel2.Visible = true;

                btnexit.Visible = true;
                guna2Button2.Visible = true;
                guna2Button3.Visible = true;


            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("welcome");
            var newf = new Form2();

            this.Hide();
            newf.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
