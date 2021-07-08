using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace StoreModels
{
    public class ContactInformation
    {
        #region Properties
        public Guid Id { get; set; } = Guid.NewGuid();
        public string PhoneNumber { get; set; } = "";
        public string EmailAddress { get; set; } = "";
        [NotMapped]
        public Guid AddressId
        {
            get
            {
                return Address != null
                    ? Address.Id
                    : Guid.Empty;

            }
            set
            {
                Address.Id = value;
            }
        }
        [JsonIgnore]
        [NotMapped]
        public virtual Address Address { get; set; } = new Address();
        public DateTime LastUpdate { get; set; } = DateTime.UtcNow;
        #endregion

        #region Constructors
        public ContactInformation()
        {

        }
        public ContactInformation(Guid id, string phoneNumber, string emailAddress, Address address)
        {
            Id = id;
            PhoneNumber = phoneNumber;
            EmailAddress = emailAddress;
            Address = address;
        }
        #endregion

        #region Methods


        #region Overrides

        public override string ToString()
        {
            return Address != null 
                    ? (Address.ToString() + Environment.NewLine) 
                    : ""
                + EmailAddress
                + Environment.NewLine
                + $"Phone: {PhoneNumber}";
        }

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