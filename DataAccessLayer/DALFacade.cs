﻿using Business;
using DomainLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DALFacade
    {
        JobConnection jobConnection = new JobConnection();
        CustomerConnection customerConnection = new CustomerConnection();       
        
        public void SaveJobToDb(Job job)
        {
            jobConnection.SaveJob(job);
        }
        public void SaveCustomerToDb(Customer customer)
        {
            customerConnection.spSaveCustomer(customer);
        }
        public List<Customer> GetCustomersFromDb()
        {
            customerConnection.spGetCustomer();
            return customerConnection.customerList;
        }
        public List<Job> GetJobsFromDb()
        {
            jobConnection.spGetJobs();
            return jobConnection.jobList;
        }
        public void UpdateCustomerInDb(string name, string email, string phone, string address, string zip, string city, string cvr)
        {
            customerConnection.SetVariables(name, email, phone, address, zip, city, cvr);
            customerConnection.spUpdateCustomer();
        }

        public void UpdateJobInDb(Job job)
        {
            jobConnection.UpdateJob(job);
        }
        public void InsertTimeAndDateInDb(WorkTime workTime)
        {
            jobConnection.InsertTimeAndDate(workTime);
        }
        public void UpdatePotsionOnJobInDB(Job job)
        {
            jobConnection.UpdatePotsionOnJob(job);
        }

    }
}
