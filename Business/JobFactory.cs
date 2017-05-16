using DataAccessLayer;
using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class JobFactory
    {
        DALFacade DBF = new DALFacade();

        public void CreateJobToDb(string name, Customer customer, string description, DateTime deadline, 
            string priceType, double price, int position)
        {
            bool _priceType;

            if (priceType == "Fast pris")
            {
                _priceType = true;
            }
            else
            {
                _priceType = false;
            }
            Job newJob = new Job(name, description, deadline, _priceType, price, position);
            newJob.Customer = customer;
            
            AddToJobDb(newJob);
        }
        
        private void AddToJobRepo(Job job)
        {
            JobRepository.Instance.SaveJob(job);
        }

        private void AddToJobDb(Job job)
        {
            DBF.SaveJobToDb(job);
        }

        internal void GetJobsFromDAL()
        {
            List<Job> jobData = DBF.GetJobsFromDb();

            foreach (Job job in jobData)
            {
                job.Customer = CustomerRepository.Instance.FindCustomerByPhone(job.CustomerPhone);
                AddToJobRepo(job);
            }
        }
    }
}
