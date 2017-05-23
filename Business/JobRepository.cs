﻿using DataAccessLayer;
using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class JobRepository
    {
        static List<Job> jobList;
        #region Singleton
        private static volatile JobRepository instance;
        private static object synchronizationRoot = new Object();
       
        public static JobRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (synchronizationRoot)
                    {
                        if (instance == null)
                        {
                            instance = new JobRepository();

                        }
                    }
                }

                return instance;
            }
        }
        #endregion
        public JobRepository()
        {
            jobList = new List<Job>();
        }

        public void SaveJob(Job newJob)
        {
            jobList.Add(newJob);
        }
        public void ClearRepo()
        {
            jobList.Clear();
        }

        public List<Job> GetList()
        {
            return jobList;
        }
        public Job GetLatestJob()
        {
            return jobList[jobList.Count - 1];
        }

        internal Job GetJobByID(int id)
        {
            return jobList.Find(n => n.JobID == id);
        }

        internal Job UpdateRepJob(int id, string name, Customer customer, string description, DateTime deadline, string priceType, double price)
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
            Job job = GetJobByID(id);
            job.CustomerPhone = customer.Phone;
            job.Customer = customer;
            job.Name = name;
            job.Description = description;
            job.Deadline = deadline;
            job.PriceType = _priceType;
            job.Price = price;
            return job;
        }
        internal void SortJobsByDeadline()
        {
            jobList = jobList.OrderBy(x => x.Deadline).ToList();
        }
        public List<Job> GetJobForCustomer(Customer cust)
        {
            List<Job> CustomerJobList = jobList.FindAll(x => x.Customer == cust).ToList().OrderBy(x=> x.Deadline).ToList();
            return CustomerJobList;
        }
    }
}
