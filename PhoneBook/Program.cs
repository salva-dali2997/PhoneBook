using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using PhoneBook.Classes;
using PhoneBook.DAO;

namespace PhoneBook
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            string connectionString = configuration.GetConnectionString("PhoneBookProjects");

            IContactDao contactDao = new ContactSqlDao(connectionString);

            PhoneBookProjectsCLI application = new PhoneBookProjectsCLI(contactDao);
            application.Run();
        }



        /// <summary>
        /// If the user selects 1 in the main menu,
        /// they are prompted to enter the required
        /// parameters for the Contact constructor which are;
        /// first name, last name, and phone number.
        /// </summary>
        /// <returns></returns>
        public static Contact PromptForContact()
        {
            Console.Write("Please enter First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("\nPlease enter Last Name: ");
            string lastName = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Please enter Phone Number: ");
            string phoneNumber = Console.ReadLine();
            Contact contact = new Contact(firstName, lastName, phoneNumber);
            return contact;
        }
        /// <summary>
        /// If the user selects 2 in the main menu,
        /// they are prompted to choose a contact to edit.
        /// </summary>
        /// <returns></returns>
        public static void PromptForContactEdit(Dictionary<string, Contact> contactListDictionary)
        {
            while (true)
            {
                Console.WriteLine("Which contact would you like to edit?\n" +
                "Search by number selection: ");
                Dictionary<int, Contact> contactToEditDictionary =
                    new Dictionary<int, Contact>();
                int i = 1;
                foreach (KeyValuePair<string, Contact> kvp in contactListDictionary)
                {
                    contactToEditDictionary.Add(i, kvp.Value);
                    Console.WriteLine($"[{i.ToString()}] : {kvp.Value.FullName}");
                    i++;
                }
                string userInput = Console.ReadLine();
                while (true)
                {
                    try
                    {
                        int userInputAsInt = int.Parse(userInput);
                        if (userInputAsInt <= i && userInputAsInt >= 1)
                        {
                            EditContact(contactToEditDictionary[userInputAsInt]);
                            break;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Please enter a valid input");
                    }
                    break;
                }

                break;
            }
        }

        /// <summary>
        /// If the user selects a 2 in the main menu,
        /// they are prompted to find the contact they
        /// wish to edit, and then asked which property
        /// in the given Contact object that they want to edit.
        /// </summary>
        public static void EditContact(Contact contactToEdit)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Which value would you like to edit?:");
                Console.WriteLine($"[1]: {contactToEdit.First_Name}");
                Console.WriteLine($"[2]: {contactToEdit.Last_Name}");
                Console.WriteLine($"[3]: {contactToEdit.Phone_Number}");
                Console.WriteLine($"[4]: {contactToEdit.Email}");
                Console.WriteLine($"[5]: {contactToEdit.Date_Of_Birth}");
                string userInput = Console.ReadLine();
                try
                {
                    int userInputAsInt = int.Parse(userInput);
                    break;
                }
                catch
                {
                    Console.WriteLine("Please enter a valid input");
                }
            }
        }
    }
}
