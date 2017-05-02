using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class Customer
    {
        
        //De er public for at de kan tilgåes fra alle lag.
        //Alt er blevet lavet som strings, da ingen af informationerne skal bruges til beregninger
        //Det er nemmere at arbejde med en string, da der ellers skal foregå en masse Parse i forbindelse med visning i view.

        public string Name { get; set; }        
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string CVR { get; set; } 

        public Customer(string name, string email, string phone, string address, string zip, string city, string cvr)
        {
            Name = name;
            Email = email;
            Phone = phone;
            Address = address;
            Zip = zip;
            City = city;
            CVR = cvr;
        }
    }
}
