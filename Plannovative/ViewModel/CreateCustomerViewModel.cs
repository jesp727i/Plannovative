using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plannovative.ViewModel
{
    class CreateCustomerViewModel
    {
        BusinessFacade BF;
        public CreateCustomerViewModel()
        {
            BF = new BusinessFacade();
          
        }

        internal void NewCustomer(string Name, string Email, string Phone, string Address, string Zip, string City, string Cvr)
        {
           
        }
    }

}
