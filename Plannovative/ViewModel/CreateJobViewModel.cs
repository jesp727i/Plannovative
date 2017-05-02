using Business;
using DomainLayer;
using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterfaceLayer.View;
using System.Collections;

namespace UserInterfaceLayer.ViewModel
{
    class CreateJobViewModel : BindableBase
    {
        BusinessFacade BF;
        public CreateJobViewModel()
        {
            BF = new BusinessFacade();
            
        }   
             
        internal void NewJob(string name, string customer, string description, string deadline, string priceType, string price)
        {
            
        }

        internal IEnumerable GetCostumerList()   /// Hvorfor bruge IEnumerable??? :)
        {
            List<String> customerNames = new List<string>();
            foreach (Customer Cust in BF.GetCustomerList())
            {
                customerNames.Add(Cust.Name);
            }
            return customerNames;

        }
    }
}
