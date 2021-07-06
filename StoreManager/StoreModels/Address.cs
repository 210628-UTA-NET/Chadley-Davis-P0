using System;

namespace StoreModels
{
    public class Address
    {
        #region Properties
        public Guid Id { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public DateTime LastUpdate { get; set; }
        #endregion

        #region Constructors
        public Address()
        {

        }
        public Address(string addressLine1, string addressLine2, string city, string province, string country, string zipcode)
        {
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            City = city;
            Province = province;
            Country = country;
            ZipCode = zipcode;
        }
        #endregion

        #region Methods
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

        #region Overrides

        public override bool Equals(Object obj)
        {
            return obj is Address && this == (Address)obj;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
        /// <summary>
        /// Compares Two Addresses for Equality
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>True if Addresses Have Same Name and Category</returns>
        public static bool operator ==(Address x, Address y)
        {
            return x?.Id == y?.Id;
        }

        public static bool operator !=(Address x, Address y)
        {
            return !(x == y);
        }

        #endregion


        #endregion

    }

}