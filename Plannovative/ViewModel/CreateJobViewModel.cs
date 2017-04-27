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
    class CreateJobViewModel
    {
        BusinessFacade BF;
        public CreateJobViewModel()
        {
            BF = new BusinessFacade();

            for (int i = 0; i<=4; i++)
            {
                BF.SaveCustomerToRepo("hanne" + i, "email", "66666666", "adresse 1", "4444", "by", "i");
            }

            
        }
            
             
        internal bool NewJob(string name, string customer, string description, string deadline, string priceType, string price)
        {


            return true;
        }

        internal IEnumerable GetCostumerList()
        {
            List<String> customerNames = new List<string>();
            foreach (Customer Cust in BF.GetCustomerListFromRepo())
            {
                customerNames.Add(Cust.Name);
            }
            return customerNames;

        }
    }
}
