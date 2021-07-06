using System;

namespace StoreModels
{
    public class ContactInformation
    {
        #region Properties
        public Guid Id { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public Guid AddressId
        {
            get
            {
                return Address != null
                    ? Address.Id
                    : Guid.Empty;

            }
        }
        public Address Address { get; set; }
        public DateTime LastUpdate { get; set; }
        #endregion

        #region Constructors
        public ContactInformation()
        {

        }
        public ContactInformation(string phoneNumber, string emailAddress, Address address)
        {
            PhoneNumber = phoneNumber;
            EmailAddress = emailAddress;
            Address = address;
        }
        #endregion

        #region Methods


        #region Overrides

        public override bool Equals(Object obj)
        {
            return obj is ContactInformation && this == (ContactInformation)obj;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
        /// <summary>
        /// Compares Two ContactInformations for Equality
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>True if ContactInformations Have Same Name and Category</returns>
        public static bool operator ==(ContactInformation x, ContactInformation y)
        {
            return x?.Id == y?.Id;
        }

        public static bool operator !=(ContactInformation x, ContactInformation y)
        {
            return !(x == y);
        }
        #endregion


        #endregion

    }


}