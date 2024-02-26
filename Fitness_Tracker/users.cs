using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fitness_Tracker
{
    //This class deals with registration, Login and Account Deletion
    internal class users
    {
        //connection string
        OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\slamba.accdb");

        //Datatypes declaration for all variables to be used in this class 
        public string name;
        public string mypassword;
        public int age;
        public string gender;
        public double weight;
        public double height;
        public string delname;


        //registration encapsulation
        public void register()
        {
            try
            {
                //Inserting data into the acounts table in the database
                conn.Open();
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "Insert into acounts(username, userPassword, userAge, userGender, userWeight, userHeight)values('" + name + "', '" + mypassword + "', '" + age + "', '" + gender + "','" + weight + "', '" + height + "')";
                MessageBox.Show("Registration successful!");
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " Registration Failed");
            }

        }

        //Login encapsulation which will a return as a boolean
        public bool login(string usern, string passw)
        {
            //declaration
            usern = name;
            passw = mypassword;


            //Selecting the username and password to compare with the one's that the user has enterred
            conn.Open();

            string logquery = "Select userID from acounts where username = @usernam AND userPassword = @userpass";

            using (OleDbCommand cmd = new OleDbCommand(logquery, conn))
            {
                cmd.Parameters.AddWithValue("@usernam", usern);
                cmd.Parameters.AddWithValue("@userpass", passw);
                cmd.ExecuteNonQuery();

                try
                {

                    //reading the data in the database
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            MessageBox.Show("Login successful!");
                            return true;

                        }
                        else
                        {
                            MessageBox.Show("Invalid account. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;

                        }
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + " Error");
                    return false;
                }
            }
        }


        //Deleting encapsulation 
        public void delete()
        {
            try
            {
                MessageBox.Show("Are you sure you want to delete?", "Account Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                delname = Form2.me; 

                conn.Open();


                //Selecting the to be deleted using the user ID

                string iq = "SELECT userID FROM acounts WHERE username = @usernm OR @usernm IS NULL";

                using (OleDbCommand icmd = new OleDbCommand(iq, conn))
                {
                    if (string.IsNullOrEmpty(delname))
                    {
                        icmd.Parameters.AddWithValue("@usernm", DBNull.Value);
                    }
                    else
                    {
                        icmd.Parameters.AddWithValue("@usernm", delname);
                    }

                    int userid = Convert.ToInt32(icmd.ExecuteScalar());

                    string delstr = "UPDATE acounts SET username = 'deleted' AND userPassword = 'deleted'    WHERE userID = @usid";

                    using (OleDbCommand cdm = new OleDbCommand(delstr, conn))
                    {
                        cdm.Parameters.AddWithValue("@usid", userid);
                        cdm.ExecuteNonQuery();

                        MessageBox.Show("Account Deleted Successfully");
                    }

                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " Delete failed");
            }
            
        }
    }
}
