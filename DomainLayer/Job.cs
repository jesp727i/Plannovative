using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Business
{
    public class Job
    {
        private Customer customer;
        public string Name { get; set; }
        public Customer Customer { get; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public bool PriceType { get; set; }
        public double Price { get; set; }

        public Job(string name, Customer customer, string description, DateTime deadline, bool priceType, double price)
        {
            this.Name = name;
            this.customer = customer;
            this.Description = description;
            this.Deadline = deadline;
            this.PriceType = priceType;
            this.Price = price;
        }
    }
}
