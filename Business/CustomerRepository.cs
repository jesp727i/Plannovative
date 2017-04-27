using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class CustomerRepository
    {
        List<Customer> CustomerList;
        static CustomerRepository CustomerRepo = new CustomerRepository();
        public CustomerRepository()
        {
            CustomerList = new List<Customer>();
        }

        public CustomerRepository GetInstance()
        {
            return CustomerRepo;
        }

        public void SaveCustomer(Customer newCustomer)
        {
            this.CustomerList.Add(newCustomer);
                
        }

        public List<Customer> GetList()
        {
            return CustomerList;
        }

        }
    }

