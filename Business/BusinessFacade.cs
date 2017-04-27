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
        JobRepository jobRepo = new JobRepository();
        CustomerFactory customerFac = new CustomerFactory();
        CustomerRepository customerRepo = new CustomerRepository();

        public void SaveJobToRepo(string name, Customer jobCustomer, string description, DateTime deadline, bool priceType, double price)
        {
            jobFac.CreateJob(name, jobCustomer, description, deadline, priceType, price);
            jobFac.AddToJobRepo();
        }

        public void SaveCustomerToRepo(string name, string email, int phone, string address, int zip, string city, int cvr)
        {
            customerFac.CreateCustomer(name, email, phone, address, zip, city, cvr);
            customerFac.AddToCumstomerRepo();
            
        }

        public List<Job> GetJobListFromRepo()
        {
            List<Job> currentList = new List<Job>();
            currentList = jobRepo.GetInstance().GetList();

            return currentList;
        }

        public List<Customer> GetCustomerListFromRepo()
        {
            List<Customer> currentList = new List<Customer>();
            currentList = customerRepo.GetInstance().GetList();

            return currentList;
        }
    }
}
