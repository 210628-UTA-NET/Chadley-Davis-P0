using System;

namespace StoreManager
{
    public class ContactInformation
    {
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public Address Address { get; set; }
        public ContactInformation()
        {
            
        }
    }

}