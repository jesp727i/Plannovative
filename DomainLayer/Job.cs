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
        public string Phone { get; set; }
        public string DeadlineString { get; set; }
        public string PriceString { get; set; }
        public double TimeUsed { get; set; }
        public int JobID { get; set; }
        public int Position { get; set; }
        public List<WorkTime> WorkTimeList { get; set; }
        #endregion

        //konstruktor der skal bruges når et customer objekt er fundet ud fra det telefon nummer som kommer fra databasen.
        //Her bliver customer objektet linket til job objektet.

        public Job(string name, Customer customer, string description, DateTime deadline, bool priceType, 
            double price, int position, int jobId)
        {
            this.Name = name;
            this.Customer = customer;
            this.Description = description;
            this.Deadline = deadline;
            this.PriceType = priceType;
            this.Price = price;
            this.Position = position;
            this.JobID = jobId;
            WorkTimeList = new List<WorkTime>();
        }
        //Kontruktor der bruges når der bliver hentet information fra databasen. Inden at der er fundet et tilhørende customer
        //objekt ud fra telefon nummeret som, er det der linker Job og Customer sammen i databasen.
        public Job(string name, string customer, string description, DateTime deadline, bool priceType, double price, int position, int jobId)
        {
            this.Name = name;
            this.Phone = customer;
            this.Description = description;
            this.Deadline = deadline;
            this.PriceType = priceType;
            this.Price = price;
            this.Position = position;
            this.JobID = jobId;
            WorkTimeList = new List<WorkTime>();
        }

        //Konstruktor der skal bruges når der bliver oprettet et job ude i UI, og som skal hele vejen ned til DAL og,
        //Derfra gemmes i databasen.
        public Job(string name, Customer customer, string description, DateTime deadline, bool priceType, double price, int position)
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
