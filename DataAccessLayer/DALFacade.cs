using Business;
using DomainLayer;
using System;
using System.Collections.Generic;
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
            customerConnection.SetVariables(customer.Name, customer.Email, customer.Phone, customer.Address, customer.Zip, customer.City, customer.Cvr);
            customerConnection.spSaveCustomer();

        }



    }
}
