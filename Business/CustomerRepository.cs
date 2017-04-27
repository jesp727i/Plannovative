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
                        }
                    }
                }
                return instance;
            }
        }
        #endregion

        List<Customer> CustomerList;
        
        public CustomerRepository()
        {
            CustomerList = new List<Customer>();

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

