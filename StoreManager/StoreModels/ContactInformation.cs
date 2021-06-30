using System;

namespace StoreModels
{
    public class ContactInformation
    {
        public string PhoneNumber { get; private set; }
        public string EmailAddress { get; private set; }
        public Address Address { get; private set; }
        public ContactInformation(string phoneNumber, string emailAddress, Address address)
        {
            PhoneNumber = phoneNumber;
            EmailAddress = emailAddress;
            Address = address;
        }
        
        public override bool Equals(Object obj)
        {
            return obj is ContactInformation && this == (ContactInformation)obj;
        }

        public override int GetHashCode()
        {
            return (PhoneNumber + EmailAddress).GetHashCode() ^ Address.GetHashCode();
        }
        /// <summary>
        /// Compares Two ContactInformations for Equality
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>True if ContactInformations Have Same Name and Category</returns>
        public static bool operator ==(ContactInformation x, ContactInformation y)
        {
            return x.PhoneNumber == y.PhoneNumber && x.EmailAddress == y.EmailAddress && x.Address == y.Address;
        }

        public static bool operator !=(ContactInformation x, ContactInformation y)
        {
            return !(x == y);
        }
    }
    

}