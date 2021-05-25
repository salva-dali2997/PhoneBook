using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json;

using PhoneBook.Classes;

namespace PhoneBook
{
    class Program
    {
        static void Main(string[] args)
        {
            //contactsJSON stores the path of the .json file where
            //the contacts will be stored.
            string contactsJSON = @"C:\Users\Student\git\git_testproject\" +
                                  @"PhoneBook\PhoneBook\Contacts.json";

            //try to populate a dictionary with the current
            //state of the json file
            //catch will create a new dictionary to store
            //contacts and will create the file if need be
            Dictionary<string, Contact> contactListDictionary =
                new Dictionary<string, Contact>();
            try
            {
                if(contactListDictionary.Count != 0)
                {
                    contactListDictionary = PopulateContactsDictionary(contactsJSON);
                }
            }
            catch 
            {
                if (!File.Exists(contactsJSON))
                {
                    File.Create(contactsJSON);
                }
            }


            //Call the main menu method which prints a number selection
            //menu to choose between a few options.
            //1. Create a Contacyt
            //2. Edit a contact
            //3. Display a contact
            //q. Quit
            int userSelection = MainMenu();
            while (true)
            {
                if (userSelection == 1)
                {
                    //ask the user for contact information
                    Contact contact = Program.PromptForContact();

                    contactListDictionary.Add(contact.ContactId, contact);


                }
                else if(userSelection == 2)
                {

                }
                else if(userSelection == 3)
                {
                    PrintContactsToConsole(contactListDictionary);
                }
                else if(userSelection == 0)
                {
                    //write it to json file
                    //string jsonString = JsonSerializer.Serialize
                    //    <Dictionary<string, Contact>>(contactListDictionary);
                    string jsonString = JsonConvert.
                        SerializeObject(contactListDictionary, Formatting.Indented);

                    File.WriteAllText(contactsJSON, jsonString);
                    Console.WriteLine("Thanks! Have a Day.");
                    return;
                }
                userSelection = MainMenu();
            }

            /*
            foreach (KeyValuePair<string, Contact> entry in contacts)
            {
                Cntact currentContact = entry.Value;
                Console.WriteLine($"{entry.Value.FullName}");
            }
            */
        }


        /// <summary>
        /// Call the main menu method which prints a number selection 
        /// menu to choose between a few options.
        /// </summary>
        /// <returns>integer of menu selection</returns>
        static int MainMenu()
        {
            //print main menu
            Console.WriteLine("Main Menu: ");
            Console.WriteLine("1. Create a Contact");
            Console.WriteLine("2. Edit a Contact");
            Console.WriteLine("3. Display a Contact");
            Console.WriteLine("q: to quit");
            Console.Write("Select a number to continue:");

            //ensure user input is valid. which at this point is
            //1, 2, 3, or 'q'
            while (true)
            {
                try
                {
                    string userInput = Console.ReadLine();
                    if (userInput == "q")
                    {
                        return 0;
                    }
                    int entry = int.Parse(userInput);
                    if (entry != 1 && entry != 2 && entry != 3)
                    {
                        Console.WriteLine("Please enter an accepted selection");
                        continue;
                    }
                    return entry;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter an accepted selection");
                    continue;
                }
            }
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
        /// If the user selects a 2 in the main menu,
        /// they are prompted to find the contact they
        /// wish to edit, and then asked which property
        /// in the given Contact object that they want to edit.
        /// </summary>
        public static void EditContact()
        {

        }

        /// <summary>
        /// If the user selects a 3 in the main menu,
        /// the contents of the json file is printed 
        /// to the console in a readable format
        /// </summary>
        /// <param name="contactsJSON"></param>
        public static void PrintContactsToConsole(Dictionary<string, Contact> contactDictionary)
        {
            foreach (KeyValuePair<string, Contact> kvp in contactDictionary)
            {
                Console.WriteLine($"Name: {kvp.Value.FullName}");
                Console.WriteLine($"Phone Number: {kvp.Value.PhoneNumber}");
                Console.WriteLine($"Email: {kvp.Value.Email}");
                Console.WriteLine($"DOB: {kvp.Value.DateOfBirth}");
                Console.WriteLine($"Address: {kvp.Value.Address.AddressToString()}");
            }
        }

        /// <summary>
        /// Populate the json contacts file into a Dictionary 
        /// containing a string of unique Id Number
        /// and a Contact object
        /// </summary>
        /// <param name="contactsJSON"></param>
        /// <returns>a dictionary of string and contact</returns>
        public static Dictionary<string, Contact> PopulateContactsDictionary(string contactsJSON)
        {
            using(StreamReader r = new StreamReader(contactsJSON))
            {
                string json = r.ReadToEnd();
                Dictionary<string, Contact> contactsDictionary =
                    JsonConvert.DeserializeObject<Dictionary<string, Contact>>(json);
                return contactsDictionary;
            }
        }


        /// <summary>
        /// This method reads in information from a csv and 
        /// places them in a contact object. Which is then
        /// placed into a json object.
        /// </summary>
        public static void ReadContactFromCSV()
        {
            string fileToRead = @"C:\Users\Student\git\git_testproject\" +
                                    @"PhoneBook\PhoneBook\Contacts.txt";
            try
            {
                using (StreamReader sr = new StreamReader(fileToRead))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("File could not be read");
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Writes a specific contact to a CSV file
        /// </summary>
        /// <param name="contactToAppend"></param>
        public static void WriteContactToFile(Contact contactToAppend)
        {
            string newFilName = @"C:\Users\Student\git\git_testproject\
                                PhoneBook\PhoneBook\TextFiles\Contacts.txt";
            try
            {
                using (StreamWriter sr = new StreamWriter(newFilName, true))
                {
                    sr.WriteLine($"{contactToAppend.FullName},{contactToAppend.PhoneNumber},{contactToAppend.Email}," +
                        $"{contactToAppend.DateOfBirth}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("File could not be read");
                Console.WriteLine(e.Message);
            }
        }


    }
}
