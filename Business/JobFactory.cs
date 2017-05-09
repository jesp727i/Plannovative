﻿using DataAccessLayer;
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

        public void CreateJobToDb(string name, Customer customer, string description, DateTime deadline, string priceType, double price, int position)
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
            Job newJob = new Job(name, customer, description, deadline, _priceType, price, position);
            
            AddToJobDb(newJob);
            AddToJobRepo(newJob);
        }

        public void CreateJobFromDb(string name, string customerPhone, string description, string deadline, bool priceType, string price, int position)
        {
            Customer customer = CustomerRepository.Instance.FindCustomerByPhone(customerPhone);
            Job newJob = new Job(name, customer, description, Convert.ToDateTime(deadline), priceType, double.Parse(price), position);
            
            AddToJobRepo(newJob);
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
                CreateJobFromDb(job.Name, job.Phone, job.Description, job.DeadlineString, job.PriceType, job.PriceString, job.Position);
            }
        }
    }
}
