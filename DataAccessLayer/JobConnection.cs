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
        #region Variables

        bool exception = true;
        string exceptionString;
        private static string connectionString = "Server=ealdb1.eal.local; Database= ejl48_db; User= ejl48_usr; Password=Baz1nga48;";
        string jobName;
        string customerPhone;
        string jobDescription;
        string jobDeadline;
        bool   jobPriceType;
        double jobPrice;

        #endregion

        private string SuccesMethod(bool exception)
        {
            if (exception)
            {
                exceptionString = "Opgaven er gemt i databasen";
            }
            
            return exceptionString;
        }

        public void SetVariables(string jobName, string customerPhone, string jobDescription, DateTime jobDeadline, bool jobPriceType, double jobPrice )
        {
            this.jobName = jobName;
            this.customerPhone = customerPhone;
            this.jobDescription = jobDescription;
            this.jobDeadline = jobDeadline.ToString();
            this.jobPriceType = jobPriceType;
            this.jobPrice = jobPrice;
        }

        public void GetJobs()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("GetJob", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string jobName = reader["JobName"].ToString();
                            string customerPhone = reader["CustomerPhone"].ToString();
                            string jobDescription = reader["JobDescription"].ToString();
                            string jobDeadLine = reader["jobDeadLine"].ToString();
                            bool jobPriceType = Convert.ToBoolean(reader["jobPriceType"]);
                            double jobPrice = Convert.ToDouble(reader["jobPrice"]);
                        }
                    }
                }

                catch(SqlException e)
                {
                    exceptionString = "Der er sket en fejl: " + e.ToString();
                    exception = false;
                    SuccesMethod(exception);
                }
            }
        }
        public void SaveJob()
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
                    exceptionString = "Der er sket en fejl: " + e.ToString();
                    exception = false;
                    SuccesMethod(exception);
                }
            }
        } 
    }
}
