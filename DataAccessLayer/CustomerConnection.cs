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
        internal List<Customer> customerList = new List<Customer>();

        internal SqlDataReader reader;

        string name;
        string email;
        string phone;
        string address;
        string zip;
        string city;
        string CVR;
        #endregion
        public void SetVariables(string name, string email, string phone, string address, string zip, string city, string cvr)
        {
            this.name = name;
            this.email = email;
            this.phone = phone;
            this.address = address;
            this.zip = zip;
            this.city = city;
            this.CVR = cvr;
            
        }
        private string SuccesMethod(bool exception)
        {

            if (exception)
            {
                exceptionString = "Kunden er gemt i databasen!";
            }

            return exceptionString;
        }
        internal void spSaveCustomer(Customer customer)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd1 = new SqlCommand("spSaveCustomer", connection);
                    cmd1.CommandType = CommandType.StoredProcedure;

                    cmd1.Parameters.Add(new SqlParameter("@CustomerName", customer.Name));
                    cmd1.Parameters.Add(new SqlParameter("@Email", customer.Email));
                    cmd1.Parameters.Add(new SqlParameter("@Phone", customer.Phone));
                    cmd1.Parameters.Add(new SqlParameter("@CustomerAddress", customer.Address));
                    cmd1.Parameters.Add(new SqlParameter("@Zip", customer.Zip));
                    cmd1.Parameters.Add(new SqlParameter("@City", customer.City));
                    cmd1.Parameters.Add(new SqlParameter("@Cvr", customer.CVR));
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
            customerList.Clear();
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
                            Customer newCustomer = new Customer(reader["CustomerName"].ToString(), 
                                reader["Email"].ToString(), 
                                reader["Phone"].ToString(),
                                reader["CustomerAddress"].ToString(),
                                reader["Zip"].ToString(),
                                reader["City"].ToString(),
                                reader["CVR"].ToString());

                            customerList.Add(newCustomer);
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
                    cmd3.Parameters.Add(new SqlParameter("@Cvr", CVR));
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
