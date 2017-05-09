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
        public Customer Customer { get; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public bool PriceType { get; set; }
        public double Price { get; set; }
        public string Phone { get; set; }
        public string DeadlineString { get; set; }
        public string PriceString { get; set; }
        public double TimeUsed { get; set; }
        public int JobID { get; set; }
        public int Position { get; set; }
        public List<WorkTime> WorkTimeList { get; set; }
        #endregion

        public void AddToWorkTimeList(WorkTime workTime)
        {
            WorkTimeList.Add(workTime);
        }

        //Konstruktor der bruges når der hentes fra databasen
        public Job(string name, string customer, string description, string deadline,
            bool priceType, string price, int postion, int jobId)
        {
            this.Name = name;
            this.Phone = customer;
            this.Description = description;
            this.DeadlineString = deadline;
            this.PriceType = priceType;
            this.PriceString = price;
            this.Position = postion;
            this.JobID = jobId;
            this.WorkTimeList = new List<WorkTime>();
        }
        //konstruktor  der skal bruges når der ligges i databasen.
        public Job(string name, Customer customer, string description, DateTime deadline, bool priceType, 
            double price, int position)
        {
            this.Name = name;
            this.Customer = customer;
            this.Description = description;
            this.Deadline = deadline;
            this.PriceType = priceType;
            this.Price = price;
            this.Position = position;
            WorkTimeList = new List<WorkTime>();
        }
    }
}
