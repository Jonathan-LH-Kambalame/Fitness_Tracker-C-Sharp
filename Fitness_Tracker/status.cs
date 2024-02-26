using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace Fitness_Tracker
{
   
    public partial class status : Form
    {
        OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\slamba.accdb");
        public status()
        {
            InitializeComponent();
        }

        private void status_Load(object sender, EventArgs e)
        {

            
            timer1.Start();
            timer2.Start();
            lbldt.Text = DateTime.Now.ToLongTimeString();
            lbldat.Text = DateTime.Now.ToLongDateString();
            panelsettings.Visible = false;
            panelchart.Visible = false;
            panelover.Visible = false;

            try
            {
                string myname;
                myname = Form2.me;
                    conn.Open();

                    string qry = "Select userID from acounts where username = @usern or @usern is null";

                    using (OleDbCommand cd = new OleDbCommand(qry, conn))
                    {
                        if (string.IsNullOrEmpty(myname))
                        {
                            cd.Parameters.AddWithValue("@usern", DBNull.Value);
                        }
                        else
                        {
                            cd.Parameters.AddWithValue("@usern", myname);
                        }

                        int id = Convert.ToInt32(cd.ExecuteScalar());


                        OleDbCommand cmd = new OleDbCommand();
                        cmd.Connection = conn;
                        string query = "Select * from saved where userID = @usid ";
                        cmd.CommandText = query;
                        cmd.Parameters.AddWithValue("@usid", id);

                        OleDbDataReader read = cmd.ExecuteReader();
                        while (read.Read())
                        {
                            chart1.Series["calories burned"].Points.AddXY(read["activity"].ToString(), read["calburned"].ToString());
                        }
                    }
                    conn.Close();

                    
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "failed to load");
            }


        }

        public void display()
        {
            try
            {
                string nome = Form2.me;

                

                conn.Open();

                string userid = "SELECT userID FROM acounts WHERE username = @us OR @us IS NULL";

                using (OleDbCommand cd = new OleDbCommand(userid, conn))
                {
                    if (!string.IsNullOrEmpty(nome))
                    {
                        cd.Parameters.AddWithValue("@us", DBNull.Value);
                    }
                    else
                    {
                        cd.Parameters.AddWithValue("@us", nome);
                    }

                    int isd = Convert.ToInt32(cd.ExecuteScalar());


                    string vv = $"SELECT userID, dates, Sum(calburned) AS totalburned "
                        + $"FROM saved "
                        + $"WHERE userID = {isd} "
                        + $"GROUP BY userID, dates";

                    using (OleDbDataAdapter adp = new OleDbDataAdapter(vv, conn))
                    {
                        DataTable dt = new DataTable();
                        adp.Fill(dt);

                        chart2.DataSource = dt;

                        chart2.Series[0].XValueMember = "dates";
                        chart2.Series[0].YValueMembers = "totalburned";

                        chart2.Series[0].LegendText = "Calories";
                        chart2.Series[0].IsVisibleInLegend = true;

                        chart2.DataBind();
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " error");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbldt.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
            lbldat.Text = DateTime.Now.ToLongDateString();
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
                panelchart.Visible = true;
            }
        }

        private void btnhome_Click(object sender, EventArgs e)
        {
            var fm = new Form4();
            this.Hide();
            fm.Show();
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

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            panelsettings.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            display();
            panelchart.Visible = false;
            panelover.Visible = true;
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            
            panelchart.Visible = true;
            panelover.Visible = false;
        }
    }
}
