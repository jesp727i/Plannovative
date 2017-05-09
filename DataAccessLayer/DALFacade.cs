using Business;
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
            jobConnection.SetVariables(job.Name, job.Customer.Phone, job.Description, job.Deadline, job.PriceType, job.Price);
            jobConnection.SaveJob();
        }
        public void SaveCustomerToDb(Customer customer)
        {
            customerConnection.SetVariables(customer.Name, customer.Email, customer.Phone, customer.Address, customer.Zip, customer.City, customer.CVR);
            customerConnection.spSaveCustomer();
        }
        public List<Customer> GetCustomersFromDb()
        {
            customerConnection.spGetCustomer();
            return customerConnection.customerList;
        }
        public List<Job> GetJobsFromDb()
        {
            jobConnection.GetJobs();
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

    }
}
