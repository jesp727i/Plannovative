using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data.SqlClient;

namespace Business
{
    public class CustomerFactory
    {
        
        DALFacade DBF = new DALFacade();
        public void CreateCustomerToDb(string name, string email, string phone, string address, string zip, string city, string cvr)
        {
            Customer newCustomer = new Customer(name, email, phone, address, zip, city, cvr);
            
            AddToCustomerDb(newCustomer);
        }
        public void CreateCustomerFromDb(string name, string email, string phone, string address, string zip, string city, string cvr)
        {
            Customer newCustomer = new Customer(name, email, phone, address, zip, city, cvr);
            
            AddToCustomerRepo(newCustomer);
        }

        private void AddToCustomerRepo(Customer customer)
        {
            CustomerRepository.Instance.SaveCustomer(customer);
        }

        internal void GetCustomersFromDAL()
        {
            List<Customer> customerData = DBF.GetCustomersFromDb();

            foreach (Customer cust in customerData)
            {
                AddToCustomerRepo(cust);
            }
        }

        private void AddToCustomerDb(Customer customer)
        {
            DBF.SaveCustomerToDb(customer);
        }


        
    }
}

