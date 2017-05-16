using DataAccessLayer;
using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BusinessFacade
    {
        DALFacade DALF = new DALFacade();
        JobFactory jobFac = new JobFactory();
        CustomerFactory customerFac = new CustomerFactory();

        public BusinessFacade()
        {
            
        }
        
        #region Singleton
        private static volatile BusinessFacade instance;
        private static object synchronizationRoot = new Object();

        public static BusinessFacade Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (synchronizationRoot)
                    {
                        if (instance == null)
                        {
                            instance = new BusinessFacade();
                        }
                    }
                }
                return instance;
            }
        }
        #endregion

        public Job LatestJob()
        {
            return JobRepository.Instance.GetLatestJob();
        }

        public Customer GetCustomerByName(string customerName)
        {
            List<Customer> searchList = CustomerRepository.Instance.GetList();
            return searchList.Find(r => r.Name == customerName);
        }

        public void SaveJob(string name, string _customer, string description, DateTime deadline, string priceType, double price, int position)
        {
            Customer customer = GetCustomerByName(_customer);
            jobFac.CreateJobToDb(name, customer, description, deadline, priceType, price, position);
        }

        public void SaveCustomer(string name, string email, string phone, string address, string zip, string city, string cvr)
        {
            customerFac.CreateCustomerToDb(name, email, phone, address, zip, city, cvr);
            
        }

        public void UpdateCustomer(string name, string email, string phone, string address, string zip, string city, string cvr)
        {
            DALF.UpdateCustomerInDb(name, email, phone,address, zip, city, cvr);
        }

        public void UpdateJob(int id, string name, string customerPhone, string description, DateTime deadline, string priceType, double price)
        {
            DALFacade DALF = new DALFacade();
            Job job = JobRepository.Instance.UpdateRepJob(id, name, customerPhone, description, deadline, priceType, price);
            DALF.UpdateJobInDb(job);
        }

        public List<Job> GetJobList()
        {
            //List<Job> currentList = new List<Job>();
            List<Job> currentList = JobRepository.Instance.GetList();

            return currentList;
        }
        public void LoadJobToRepo()
        {
            JobRepository.Instance.ClearRepo();
            jobFac.GetJobsFromDAL();
            CalculateTimeUsedOnJobs();
            
        }
        internal void CalculateTimeUsedOnJobs()
        {
            foreach (Job job in JobRepository.Instance.GetList())
            {
                job.TimeUsed = JobLogic.CalculateTimeUsed(job.WorkTimeList);
            }
        }
        internal void CalculateTimeUsedOnAJob(Job job)
        {
            job.TimeUsed = JobLogic.CalculateTimeUsed(job.WorkTimeList);
        }

        public List<string> GetCustomerNames()
        {

            List<string> custNames = new List<string>();
            foreach (Customer cust in CustomerRepository.Instance.GetList())
            {
                custNames.Add(cust.Name);
            }
            return custNames;
        }
        public void LoadCustomersToRepo()
        {
            CustomerRepository.Instance.ClearRepo();
            customerFac.GetCustomersFromDAL();
        }
        public Job GetJobByName(string jobName)
        {
            Job job;
            job = JobRepository.Instance.GetList().Find(e => e.Name == jobName);
            return job;
        }
        public void SaveTimeAndDate(TimeSpan startTime, TimeSpan endTime, DateTime date, Job job)
        {
            WorkTime workTime = jobFac.CreateWorkTimeForJob(startTime, endTime, date, job.JobID);
            DALF.InsertTimeAndDateInDb(workTime);
            job.WorkTimeList.Add(workTime);
            CalculateTimeUsedOnAJob(job);
            
        }
    }
}
