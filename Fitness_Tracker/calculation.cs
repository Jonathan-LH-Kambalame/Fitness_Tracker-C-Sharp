using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.OleDb;
using System.Windows.Media.Media3D;

namespace Fitness_Tracker
{
    //This class calculates the calories burned and keeping them into database
    internal class calculation
    {
        //Connection string
        OleDbConnection cone = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\slamba.accdb");

        //Data declaration
        public double metvalue;
        public double weight;
        public double distance;
        public DateTime dates;
        public double answer;
        public int userids;
        public string name;
        public string works;
        public string comment;
        public string check;
        public double anstring;
        public double timetkn;


        //Calculation formulas encapsulations to find calories burned by user that returns double
        public double calories()
        {
            return Math.Round(metvalue * weight * distance);
        }

        public double cal()
        {
            return Math.Round(metvalue * weight * timetkn);
        }

        public double jumping()
        {
            if (check == "Jumping jacks")
            {
                anstring = (weight * timetkn * 900) / 60;
            }
            else if(check == "Jumping rope")
            {
                anstring = (weight * timetkn * 845) / 60;
            }
            else if(check == "Rope skipping")
            {
                anstring = (weight * timetkn * 881) / 60;
            }
            else
            {
                anstring = (weight * timetkn * 635) / 60;
            }
            return anstring;
        }

        //Keeping Calories burned encapsulation
        public void keep()
        {
            try
            {
                name = Form2.me;

               cone.Open();

                //Selecting userid from the acounts's table

                string iq = "SELECT userID FROM acounts WHERE username = @usernm OR @usernm IS NULL";

                using (OleDbCommand icmd = new OleDbCommand(iq, cone))
                {
                    if (string.IsNullOrEmpty(name))
                    {
                        icmd.Parameters.AddWithValue("@usernm", DBNull.Value);
                    }
                    else
                    {
                        icmd.Parameters.AddWithValue ("@usernm", name);
                    }

                    userids = Convert.ToInt32(icmd.ExecuteScalar());

                    //Inserting into database

                    string insrt = "INSERT INTO saved(userID, activity, calburned, dates, comments)VALUES(@usid, @worknm, @burn, @dt, @com)";

                    using (OleDbCommand cmd = new OleDbCommand(insrt, cone))
                    {
                        cmd.Parameters.AddWithValue("@usid", userids);
                        cmd.Parameters.AddWithValue("@worknm", works);
                        cmd.Parameters.AddWithValue("@burn", answer);
                        cmd.Parameters.AddWithValue("@dt", dates);
                        cmd.Parameters.AddWithValue("@com", comment);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Saved Successfully");

                    }
                }
                cone.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " save failed");
            }


                        }
            }
 }
