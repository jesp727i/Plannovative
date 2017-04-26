using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Job
    {
        public string Name { get; set; }
        public Customer JobCustomer { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public bool PriceType { get; set; }
        public double Price { get; set; }


        public Job(string name, Customer jobCustomer, string description, DateTime deadline, bool priceType, double price)
        {

            this.Name = name;
            this.JobCustomer = jobCustomer;
            this.Description = description;
            this.Deadline = deadline;
            this.PriceType = priceType;
            this.Price = price;

        }








    }
}
