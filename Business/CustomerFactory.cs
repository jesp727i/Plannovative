using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    class CustomerFactory
    {
        public void CreateCustomer(string name, string email, int phone, string address, int zip, string city, int cvr)
        {
            Customer newCustomer = new Customer(name, email, phone, address, zip, city, cvr);

            
        }
    }
}
