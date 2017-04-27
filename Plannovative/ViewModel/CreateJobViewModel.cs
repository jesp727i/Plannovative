using Business;
using DomainLayer;
using System;
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
                BF.SaveCustomerToRepo("hanne" + i, "email", 66666666, "adresse 1", 4444, "by", i);
            }
            
        }
            
             
        internal void NewJob(string name, string Customer)
        {

        }

        internal IEnumerable GetCostumerList()
        {
            return BF.GetCustomerListFromRepo();

        }
    }
}
