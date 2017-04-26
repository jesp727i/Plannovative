using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class Customer
    {
        public string Name;
        public string Email;
        public int Phone;
        public string Address;
        public int Zip;
        public string City;
        public int Cvr;


        public Customer( string name, string email, int phone, string address, int zip, string city, int cvr)
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
