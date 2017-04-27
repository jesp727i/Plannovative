using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class Customer
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string Cvr { get; set; } 


        public Customer( string name, string email, string phone, string address, string zip, string city, string cvr)
        {
            Name = name;
            Email = email;
            Phone = phone;
            Address = address;
            Zip = zip;
            City = city;
            Cvr = cvr;
        }
    }
}
