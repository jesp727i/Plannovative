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
        public void spGetJobs()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    jobList.Clear();
                    connection.Open();
                    
                    SqlCommand cmdGetJobs = new SqlCommand("GetJobTest", connection);
                    cmdGetJobs.CommandType = CommandType.StoredProcedure;
                    SqlDataReader readerJob = cmdGetJobs.ExecuteReader();

                    if (readerJob.HasRows)
                    {
                        while (readerJob.Read())
                        {
                            Job newJob = new Job(readerJob["JobName"].ToString(),
                                readerJob["CustomerPhone"].ToString(),
                                readerJob["JobDescription"].ToString(),
                                (DateTime)readerJob["JobDeadline"],
                                (bool)readerJob["JobPriceType"],
                                (double)readerJob["JobPrice"],
                                (int)readerJob["Position"],
                                (int)readerJob["JobId"]);

                            
                            spGetWorkTime(newJob);
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
        public void spGetWorkTime(Job job)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmdGetWorktime = new SqlCommand("spGetWorkTimeByJobId", connection);
                    cmdGetWorktime.Parameters.Add(new SqlParameter("@JobId", job.JobID));
                    cmdGetWorktime.CommandType = CommandType.StoredProcedure;
                    SqlDataReader readerWorktime = cmdGetWorktime.ExecuteReader();

                    if (readerWorktime.HasRows)
                    {
                        while (readerWorktime.Read())
                        {
                            WorkTime newWorkTime = new WorkTime(
                                (TimeSpan)readerWorktime["StartTime"],
                                (TimeSpan)readerWorktime["EndTime"],
                                (DateTime)readerWorktime["WorkDate"],
                                (int)readerWorktime["JobId"]);

                            job.WorkTimeList.Add(newWorkTime);
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
        public void SaveJob(Job job)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("SaveJobTest", connection);
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
