﻿using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BusinessFacade
    {
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

        JobFactory jobFac = new JobFactory();
        //JobRepository jobRepo = new JobRepository();
        CustomerFactory customerFac = new CustomerFactory();
        //CustomerRepository customerRepo = new CustomerRepository();

        public void SaveJob(string name, Customer customer, string description, DateTime deadline, bool priceType, double price)
        {
            jobFac.CreateJob(name, customer, description, deadline, priceType, price);
        }

        public void SaveCustomer(string name, string email, string phone, string address, string zip, string city, string cvr)
        {
            customerFac.CreateCustomer(name, email, phone, address, zip, city, cvr);
            
        }

        public List<Job> GetJobList()
        {
            List<Job> currentList = new List<Job>();
            currentList = JobRepository.Instance.GetList();

            return currentList;
        }

        public List<Customer> GetCustomerList()
        {
            List<Customer> currentList = new List<Customer>();
            currentList = CustomerRepository.Instance.GetList();

            return currentList;
        }
    }
}
