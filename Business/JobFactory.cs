using DataAccessLayer;
using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class JobFactory
    {
        Job currentJob;
        DALFacade DBF = new DALFacade();

        public void CreateJob(string name, Customer customer, string description, DateTime deadline, bool priceType, double price)
        {
            Job newJob = new Job(name, customer, description, deadline, priceType, price);
            currentJob = newJob;
            AddToJobDatabase();
            //AddToJobRepo();
        }

        private void AddToJobRepo()
        {
            JobRepository.Instance.SaveJob(currentJob);
        }
        private void AddToJobDatabase()
        {
            DBF.SaveJobToDb(currentJob);
        }    
    }
}
