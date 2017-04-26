using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    class JobFactory
    {

        Job currentJob;

        public void CreateJob(string name, Customer jobCustomer, string description, DateTime deadline, bool priceType, double price)
        {
            Job newJob = new Job(name, jobCustomer, description, deadline, priceType, price);
            currentJob = newJob;
        }

        public void AddToJobRepo()
        {
            JobRepository jobRepo = new JobRepository();
            //var instance = jobRepo.GetInstance();
            //instance.SaveJob(currentJob); ?? det samme som linien neden under?
            jobRepo.GetInstance().SaveJob(currentJob);
            
        }


        
    }
}
