using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Windows;
using System.Data.OleDb;

namespace Fitness_Tracker
{
    //This class keeps the user's goal
    internal class usergoal
    {
        OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\slamba.accdb");

        //Datatype Declaration
        public string goalname;
        public double gtarget;
        public string usname;

        //Inserting user's goal encapsulation
        public void setgoal()
        {
            try
            {
                usname = Form2.me;

                conn.Open();

                //Selecting userid from the acount's table
                string quer = "Select userID from acounts where username = @users OR @users IS Null";

                using (OleDbCommand cmd = new OleDbCommand(quer, conn))
                {
                    // Check if the username is null and set a default value if needed
                    if (string.IsNullOrEmpty(usname))
                    {
                        cmd.Parameters.AddWithValue("@Usern", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Usern", usname);
                    }

                    int userd = Convert.ToInt32(cmd.ExecuteScalar());

                    //Inserting user's goal into database

                    string insertQ = "INSERT INTO goals(userID, goal, goaltarget) VALUES (@UserID, @goalname, @target)";

                    using (OleDbCommand Command = new OleDbCommand(insertQ, conn))
                    {
                        Command.Parameters.AddWithValue("@UserID", userd);
                        Command.Parameters.AddWithValue("@goalname", goalname);
                        Command.Parameters.AddWithValue("@target", gtarget);
                        Command.ExecuteNonQuery();
                    }


                    MessageBox.Show("Goal inserted successfully!");
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " failed");
            }
        }
            

        }
    }

