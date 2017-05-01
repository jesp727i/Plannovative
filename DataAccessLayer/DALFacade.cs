using Business;
using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DALFacade
    {
        public void SaveJobToDb(Job job)
        {
            JobConnection newConnection = new JobConnection();
            newConnection.SetVariables(job.Name, job.Customer.Phone, job.Description, job.Deadline, job.PriceType, job.Price);
            newConnection.SaveJob();
        }
    }
}
