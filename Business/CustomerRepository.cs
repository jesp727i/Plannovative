using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace Business
{
    public class CustomerRepository
    {
      static List<Customer> customerList;

        #region Singleton
        private static volatile CustomerRepository instance;
        private static object synchronizationRoot = new Object();

        public static CustomerRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (synchronizationRoot)
                    {
                        if (instance == null)
                        {
                            instance = new CustomerRepository();
                            //instance.CustomerList = new List<Customer>();
                        }
                    }
                }
                return instance;
            }
        }
        #endregion



        public CustomerRepository()
        {
            customerList = new List<Customer>();   
        }

        public void SaveCustomer(Customer newCustomer)
        {
            customerList.Add(newCustomer);       
        }

        public List<Customer> GetList()
        {
            return customerList;
        }
    }
}

