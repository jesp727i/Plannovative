using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer;
using DataAccessLayer;

namespace Business
{
    public class CustomerFactory
    {
        Customer currentCustomer;
        DALFacade DBF = new DALFacade();
        public void CreateCustomer(string name, string email, string phone, string address, string zip, string city, string cvr)
        {
            Customer newCustomer = new Customer(name, email, phone, address, zip, city, cvr);
            currentCustomer = newCustomer;
            AddToCustomerRepo();
          //  AddToCustomerDb();
        }
            
        private void AddToCustomerRepo()
        {
            CustomerRepository.Instance.SaveCustomer(currentCustomer);
        }

        private void AddToCustomerDb()
        {
            DBF.SaveCustomerToDb(currentCustomer);
        }

    }
}

