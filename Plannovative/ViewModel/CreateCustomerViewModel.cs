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


        public string Name { get; set; }
        public int MyProperty { get; set; }


        public CreateCustomerViewModel()
        {
            BF = new BusinessFacade();
          
        }

        internal void NewCustomer(string name, string Email, string phone, string address, string zip, string city, string cvr)
        {
           BF.SaveCustomer( name, Email, phone, address, zip, city, cvr);
            
            
        }
    }

}
