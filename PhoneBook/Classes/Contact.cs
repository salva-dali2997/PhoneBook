using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Classes
{
    class Contact
    {
        public string ContactId { get; } = Guid.NewGuid().ToString();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; } = "";
        public string DateOfBirth { get; set; } = "";
        public string FullName
        {
            get
            {
                return $"{this.LastName}, {this.FirstName}";
            }
        }
        public Address Address { get; set; } = new Address();

        /// <summary>
        /// Constructs a Contact object with a first name,
        /// last name, and phone number parameter.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="phoneNumber"></param>
        public Contact(string firstName, string lastName, string phoneNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            PhoneNumber = phoneNumber;  //or use .this   |   is optional
        }



    }
}
