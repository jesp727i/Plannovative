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
        #region Properties
        public string Name { get; set; }
        public Customer Customer { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public bool PriceType { get; set; }
        public double Price { get; set; }
        public string CustomerPhone { get; set; }
        public double TimeUsed { get; set; }
        public int JobID { get; set; }
        public int Position { get; set; }
        public List<WorkTime> WorkTimeList { get; set; }
        #endregion

        public Job(string name, string description, DateTime deadline, bool priceType, double price, int position)
        {
            this.Name = name;
            this.Description = description;
            this.Deadline = deadline;
            this.PriceType = priceType;
            this.Price = price;
            this.Position = position;
            WorkTimeList = new List<WorkTime>();
        }
    }
}
