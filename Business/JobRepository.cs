using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class JobRepository
    {
        List<Job> jobList;
        static JobRepository jobRepo = new JobRepository();
        public JobRepository()
        {
            jobList = new List<Job>();
        }

        public JobRepository GetInstance()
        {
            return jobRepo;
        }

        public void SaveJob(Job newJob)
        {
            this.jobList.Add(newJob);


        }





    }
}
