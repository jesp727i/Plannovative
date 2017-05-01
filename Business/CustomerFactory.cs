using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class CustomerFactory
    {
        Customer currentCustomer;
        public void CreateCustomer(string name, string email, string phone, string address, string zip, string city, string cvr)
        {
            Customer newCustomer = new Customer(name, email, phone, address, zip, city, cvr);
            currentCustomer = newCustomer;
            AddToCustomerRepo();
        }
            
        private void AddToCustomerRepo()
        {
            CustomerRepository.Instance.SaveCustomer(currentCustomer);
        }

   }
}

