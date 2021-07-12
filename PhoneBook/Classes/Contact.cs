using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Classes
{
    class Contact
    {
        public string Contact_Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Phone_Number { get; set; }
        public string Email { get; set; } = "";
        public string Date_Of_Birth { get; set; } = "";
        public string FullName
        {
            get
            {
                return $"{this.Last_Name}, {this.First_Name}";
            }
        }
        public Address Address { get; set; } = new Address();

        /// <summary>
        /// Empty construcotr for Contact
        /// </summary>
        public Contact()
        {

        }
        /// <summary>
        /// Constructs a Contact object with a first name,
        /// last name, and phone number parameter.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="phoneNumber"></param>
        public Contact(string firstName, string lastName, string phoneNumber)
        {
            this.First_Name = firstName;
            this.Last_Name = lastName;
            Phone_Number = phoneNumber;  //or use .this   |   is optional
        }



    }
}
