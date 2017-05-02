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

        internal void GetCustomersFromDAL()
        {
            List<string[]> customerData = DBF.GetCustomersFromDb();

            foreach (string[] item in customerData)
            {
                CreateCustomer(item[0],item[1], item[2], item[3], item[4], item[5], item[6]);
            }
        }

        private void AddToCustomerDb()
        {
            DBF.SaveCustomerToDb(currentCustomer);
        }

    }
}

