using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    class CustomerConnection
    {
        private static string connectionString =
         "Server=ealdb1.eal.local; Database= ejl48_db; User= ejl48_usr; Password=Baz1nga48;";

        string name;
        string email;
        string phone;
        string address;
        string zip;
        string city;
        string cvr;

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



        private void spSaveCustomer()
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
                catch (SqlException )
                {


                }
            }
        }

    }
}
