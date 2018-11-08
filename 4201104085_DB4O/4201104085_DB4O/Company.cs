using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTerm2016
{
    [Serializable]
    public class Company
    {
        public string CompanyName { get; set; }
        public string HouseNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public Company(string compname, string housenumber,string street,string city)
        {
            CompanyName = compname;
            HouseNumber = housenumber;
            Street = street;
            City = city;
        }
        public override string ToString()
        {
            return CompanyName;
        }
    }
}
