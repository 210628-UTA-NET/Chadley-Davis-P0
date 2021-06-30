using System;

namespace StoreModels
{
    public class Address
    {
        public string AddressLine1 { get; private set; }
        public string AddressLine2 { get; private set; }
        public string City { get; private set; }
        public string Province { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }
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
                + Country + ", " + ZipCode;
        }

        
        public override bool Equals(Object obj)
        {
            return obj is Address && this == (Address)obj;
        }

        public override int GetHashCode()
        {
            return (this.ToString()).GetHashCode();
        }
        /// <summary>
        /// Compares Two Addresses for Equality
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>True if Addresses Have Same Name and Category</returns>
        public static bool operator ==(Address x, Address y)
        {
            return x.AddressLine1 == y.AddressLine1 
                && x.AddressLine2 == y.AddressLine2 
                && x.City == y.City
                && x.Province == y.Province
                && x.Country == y.Country
                && x.ZipCode == y.ZipCode;
        }

        public static bool operator !=(Address x, Address y)
        {
            return !(x == y);
        }
    }

}