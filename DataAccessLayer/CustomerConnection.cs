using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer;

namespace DataAccessLayer
{
    class CustomerConnection
    {
        #region Variabler

       
        private static string connectionString =
         "Server=ealdb1.eal.local; Database= ejl48_db; User= ejl48_usr; Password=Baz1nga48;";

        bool exception = true;
        string exceptionString;
        internal List<string[]> arrayList = new List<string[]>();

        internal SqlDataReader reader;

        string name;
        string email;
        string phone;
        string address;
        string zip;
        string city;
        string cvr;
        #endregion

        public void SetVariables(string name, string email, string phone, string address, string zip, string city, string cvr)
        {
            this.name = name;
            this.email = email;
            this.phone = phone;
            this.address = address;
            this.zip = zip;
            this.city = city;
            this.cvr = cvr;
            
        }

        private string SuccesMethod(bool exception)
        {

            if (exception)
            {
                exceptionString = "Kunden er gemt i databasen!";
            }

            return exceptionString;
        }
        internal void spSaveCustomer()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd1 = new SqlCommand("spSaveCustomer", connection);
                    cmd1.CommandType = CommandType.StoredProcedure;

                    cmd1.Parameters.Add(new SqlParameter("@CustomerName", name));
                    cmd1.Parameters.Add(new SqlParameter("@Email", email));
                    cmd1.Parameters.Add(new SqlParameter("@Phone", phone));
                    cmd1.Parameters.Add(new SqlParameter("@CustomerAddress", address));
                    cmd1.Parameters.Add(new SqlParameter("@Zip", zip));
                    cmd1.Parameters.Add(new SqlParameter("@City", city));
                    cmd1.Parameters.Add(new SqlParameter("@Cvr", cvr));
                    cmd1.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    exceptionString = "Der er sket en fejl: " + e.ToString();
                    exception = false;
                    SuccesMethod(exception);

                    
                }
            }
        }
        internal void spGetCustomer()
        {
            arrayList.Clear();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd2 = new SqlCommand("spGetCustomers", connection);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    reader = cmd2.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                          
                            string[] newArray = new string[7];
                            newArray[0] = reader["CustomerName"].ToString();
                            newArray[1] = reader["Email"].ToString();
                            newArray[2] = reader["Phone"].ToString();
                            newArray[3] = reader["CustomerAddress"].ToString();
                            newArray[4] = reader["Zip"].ToString();
                            newArray[5] = reader["City"].ToString();
                            newArray[6] = reader["CVR"].ToString();

                            arrayList.Add(newArray);
                        
                        }

                    }



                }
                catch (SqlException e)
                {
                    exceptionString = "Der er sket en fejl: " + e.ToString();
                    exception = false;
                    SuccesMethod(exception);


                }
            }   
       }
        internal void spUpdateCustomer()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd3 = new SqlCommand("spUpdateCustomer", connection);
                    cmd3.CommandType = CommandType.StoredProcedure;

                    cmd3.Parameters.Add(new SqlParameter("@CustomerName", name));
                    cmd3.Parameters.Add(new SqlParameter("@Email", email));
                    cmd3.Parameters.Add(new SqlParameter("@Phone", phone));
                    cmd3.Parameters.Add(new SqlParameter("@CustomerAddress", address));
                    cmd3.Parameters.Add(new SqlParameter("@Zip", zip));
                    cmd3.Parameters.Add(new SqlParameter("@City", city));
                    cmd3.Parameters.Add(new SqlParameter("@Cvr", cvr));
                    cmd3.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    exceptionString = "Der er sket en fejl: " + e.ToString();
                    exception = false;
                    SuccesMethod(exception);


                }
            }

        }

    }
}
