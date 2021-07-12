using System;
using System.Collections.Generic;
using System.Runtime.Loader;
using System.Text;

namespace PhoneBook.Classes
{
    public class Address
    {
        public string Street_Address_1 { get; set; }
        public string Street_Address_2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip_Code { get; set; }


        /// <summary>
        /// Constructs an address object with at least a 
        /// Street Name and an Address Number
        /// </summary>
        /// <param name="streetAddress1"></param>
        /// <param name="streetAddress2"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="zipCode"></param>
        public Address(string streetAddress1 = null, string streetAddress2 = null, string city = null, string state = null, string zipCode = null)
        {
            this.Street_Address_1 = streetAddress1;
            this.Street_Address_1 = streetAddress2;
            this.City = city;
            this.State = state;
            this.Zip_Code = zipCode;
        }
        
        public string AddressToString()
        {
            string addressToString = $"{this.Street_Address_1} {this.Street_Address_2}";
            if(this.City != null)
            {
                addressToString += $"\n         {this.City}";
            }
            if (this.State != null)
            {
                addressToString += $", {this.State}";
            }
            if (this.City != null)
            {
                addressToString += $" {this.Zip_Code}";
            }
            return addressToString;
        }
    }
}
