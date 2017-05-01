using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class JobConnection
    {
        private static string connectionString = "Server=ealdb1.eal.local; Database= ejl48_db; User= ejl48_usr; Password=Baz1nga48;";
        string jobName;
        string customerPhone;
        string jobDescription;
        string jobDeadline;
        bool   jobPriceType;
        double jobPrice;

        public void SetVariables(string jobName, string customerPhone, string jobDescription, string jobDeadline, bool jobPriceType, double jobPrice )
        {
            this.jobName = jobName;
            this.customerPhone = customerPhone;
            this.jobDescription = jobDescription;
            this.jobDeadline = jobDeadline;
            this.jobPriceType = jobPriceType;
            this.jobPrice = jobPrice;
        }
        private void SaveJob()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("spSaveJob", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@JobName", jobName));
                    cmd.Parameters.Add(new SqlParameter("@CustomerPhone", customerPhone));
                    cmd.Parameters.Add(new SqlParameter("@JobDescription", jobDescription));
                    cmd.Parameters.Add(new SqlParameter("@JobDeadline", jobDeadline));
                    cmd.Parameters.Add(new SqlParameter("@JobPriceType", jobPriceType));
                    cmd.Parameters.Add(new SqlParameter("@JobPrice", jobPrice));

                    cmd.ExecuteNonQuery();
                }
                catch(SqlException e)
                {

                }
            }
        }

          
    }

}
