using System;
using System.Collections.Generic;
using System.Runtime.Loader;
using System.Text;

namespace PhoneBook.Classes
{
    public class Address
    {
        public string StreetName { get; set; }
        public string AddressNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }


        /// <summary>
        /// Constructs an address object with at least a 
        /// Street Name and an Address Number
        /// </summary>
        /// <param name="streetName"></param>
        /// <param name="addressNumber"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="zipCode"></param>
        public Address(string streetName = null, string addressNumber = null, string city = null, string state = null, string zipCode = null)
        {
            this.StreetName = streetName;
            this.AddressNumber = addressNumber;
            this.City = city;
            this.State = state;
            this.ZipCode = zipCode;
        }

        /*
        public Address(string streetName, string addressNumber) : this(streetName, addressNumber, "unknown", "Ohio", "")
        {

        }
        */

        public string AddressToString()
        {
            string addressToString = $"{this.AddressNumber} {this.StreetName}";
            if (this.City != null)
            {
                addressToString += $"\n         {this.City}";
            }
            if (this.State != null)
            {
                addressToString += $", {this.State}";
            }
            if (this.City != null)
            {
                addressToString += $" {this.ZipCode}";
            }
            return addressToString;
        }
    }
}
