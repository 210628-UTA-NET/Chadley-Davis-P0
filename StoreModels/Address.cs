using System;

namespace StoreManager
{
    public class Address
    {
        string AddressLine1 { get; set; }
        string AddressLine2 { get; set; }
        string City { get; set; }
        string Province { get; set; }
        string Country { get; set; }
        string ZipCode { get; set; }
        public Address(string addressLine1, string addressLine2, string city, string province, string country, string zipcode)
        {
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            City = city;
            Province = province;
            Country = country;
            ZipCode = zipcode;
        }
        public override string ToString()
        {
            return AddressLine1 
                + Environment.NewLine
                + AddressLine2
                + Environment.NewLine
                + City + ", " + Province
                + Environment.NewLine
                + Country + ", " + ZipCode
                + Environment.NewLine;
        }
    }

}