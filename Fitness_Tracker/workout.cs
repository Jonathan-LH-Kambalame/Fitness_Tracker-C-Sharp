using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows;
using System.Linq.Expressions;

namespace Fitness_Tracker
{
    //This user deals with the user's activity of the choice
    internal class workout
    {

        //Connection String
        OleDbConnection mycon = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\slamba.accdb");

        //Declaring Datatypes to be used in this class
        public int userid;
        public string name;
        public string work;
        public double metv;
        public int round;
        public double weigt;
        public double times;
        public double distant;
        public DateTime dates;


        //Saving records for the user
        public void worksv()
        {
           try
            {
                name = Form2.me;
                mycon.Open();

                //Getting userID for the user in the acounts's table

                string idfind = "Select userID from acounts where username = @usname or @usname is null";

                using (OleDbCommand cmd = new OleDbCommand(idfind, mycon))
                {
                    if (string.IsNullOrEmpty(name))
                    {
                        cmd.Parameters.AddWithValue("@usname", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@usname", name);
                    }

                    userid = Convert.ToInt32(cmd.ExecuteScalar());

                    //Inserting the records into the workouts table

                    string insertq = "INSERT INTO workout (userID, workname, met, rounds, weightkgs, timehrs, distancekm, workdate) VALUES (@usid, @worknm, @mev, @roun, @weit, @tym, @dist, @wdate)";

                    using (OleDbCommand com = new OleDbCommand(insertq, mycon))
                    {
                        com.Parameters.AddWithValue("@usid", userid);
                        com.Parameters.AddWithValue("@worknm", work);
                        com.Parameters.AddWithValue("@mev", metv);
                        com.Parameters.AddWithValue("@roun", round);
                        com.Parameters.AddWithValue("@weit", weigt);
                        com.Parameters.AddWithValue("@tym", times);
                        com.Parameters.AddWithValue("@dist", distant);
                        com.Parameters.AddWithValue("@wdate", dates);

                        com.ExecuteNonQuery();
                    }


                    MessageBox.Show("Record saved.....");
                    mycon.Close();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "failed");
            }
        }
    }
}
