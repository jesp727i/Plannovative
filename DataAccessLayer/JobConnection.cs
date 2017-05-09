using Business;
using DomainLayer;
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
        internal List<Job> jobList = new List<Job>();
        
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
        public void SetVariables( string jobName, string customerPhone, string jobDescription, DateTime jobDeadline, bool jobPriceType, double jobPrice )
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
                    jobList.Clear();
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("GetJob", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            bool myBool = (bool)reader["JobPriceType"];

                            Job newJob = new Job(reader["JobName"].ToString(),
                                reader["CustomerPhone"].ToString(),
                                reader["JobDescription"].ToString(),
                                reader["JobDeadline"].ToString(),
                                myBool,
                                reader["JobPrice"].ToString(),
                                (int)reader["Postion"],
                                (int)reader["JobId"]);


                            WorkTime newWorkTime = new WorkTime(
                                (TimeSpan)reader["StartTime"],
                                (TimeSpan)reader["EndTime"],
                                (DateTime)reader["WorkDate"],
                                (int)reader["JobId"]);




                            newJob.WorkTimeList.Add(newWorkTime);
                  
                            jobList.Add(newJob);
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
        public void SaveJob(Job job)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("spSaveJob", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@JobName", job.Name));
                    cmd.Parameters.Add(new SqlParameter("@CustomerPhone", job.Customer.Phone));
                    cmd.Parameters.Add(new SqlParameter("@JobDescription", job.Description));
                    cmd.Parameters.Add(new SqlParameter("@JobDeadline", job.Deadline));
                    cmd.Parameters.Add(new SqlParameter("@JobPriceType", job.PriceType));
                    cmd.Parameters.Add(new SqlParameter("@JobPrice", job.Price));
                    cmd.Parameters.Add(new SqlParameter("@Position", job.Position));
                    cmd.Parameters.Add(new SqlParameter("@TimeUsed", job.TimeUsed));

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
        public void InsertTimeAndDate(WorkTime workTime)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("spInsertTimeAndDate", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@StartTime",workTime.StartTime));
                    cmd.Parameters.Add(new SqlParameter("@EndTime",workTime.EndTime ));
                    cmd.Parameters.Add(new SqlParameter("@WorkDate",workTime.WorkDate ));
                    cmd.Parameters.Add(new SqlParameter("@JobId", workTime.JobId));
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    exceptionString = "Der er sket en fejl: " + e.ToString();
                    exception = false;
                    SuccesMethod(exception);
                }
            }
        }
        public void UpdateJob(Job job)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd2 = new SqlCommand("spUpdateJob", connection);
                    cmd2.CommandType = CommandType.StoredProcedure;

                    cmd2.Parameters.Add(new SqlParameter("@JobName", job.Name));
                    cmd2.Parameters.Add(new SqlParameter("@JobDescription", job.Description));
                    cmd2.Parameters.Add(new SqlParameter("@JobDeadline", job.DeadlineString));
                    cmd2.Parameters.Add(new SqlParameter("@JobPriceType", job.PriceType));
                    cmd2.Parameters.Add(new SqlParameter("@JobPrice", job.Price));
                    cmd2.Parameters.Add(new SqlParameter("@JobID", job.JobID));

                    cmd2.ExecuteNonQuery();
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
