using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

using PhoneBook.Classes;

namespace PhoneBook
{
    class Program
    {
        static void Main(string[] args)
        {

            //Create a Dictionary that will store your contacts
            Dictionary<string, Contact> contactListDictionary =
                new Dictionary<string, Contact>();


            //File path for json file
            string contactsJSON = @"C:\Users\Student\git\PhoneBook\PhoneBook\Contacts.json";

            //If the file doesn't exist, create the file
            if (!File.Exists(contactsJSON))
            {
                var myContactFile = File.Create(contactsJSON);
                myContactFile.Close();
            }
            //If it does exist
            else
            {
                //populate a dictionary with the current
                //state of the json file
                contactListDictionary = PopulateContactsDictionary(contactsJSON);
            }


            //Call the main menu method which prints a number selection
            //menu to choose between a few options.
            //1. Create a Contact
            //2. Edit a contact
            //3. Display a contact
            //q. Quit
            int userSelection = MainMenu();
            while (true)
            {
                //User selected "Create a Contact"
                if (userSelection == 1)
                {
                    //ask the user for contact information
                    Contact contact = Program.PromptForContact();

                    //add the contact to the current contact list dictionary
                    contactListDictionary.Add(contact.ContactId, contact);

                    //print success message, and then clear the console
                    Console.WriteLine("Contact successfully added, press any button to continue:");
                    Console.ReadLine();
                    Console.Clear();

                }
                //User selected "Edit a Contact"
                else if (userSelection == 2)
                {
                    //Enter the contact list method
                    PromptForContactEdit(contactListDictionary);

                    //Clear the console
                    Console.Clear();
                }
                //User selected "Display a Contact"
                else if (userSelection == 3)
                {
                    //print the contacts to the console
                    //from the contact list dictionary
                    PrintContactsToConsole(contactListDictionary);

                    //hold screen to see contacts, press button to continue
                    Console.WriteLine("Press any button to continue:");
                    Console.ReadLine();

                    //Clear the console
                    Console.Clear();
                }
                else if(userSelection == 0)
                {
                    //write it to json file
                    File.WriteAllText(contactsJSON, JsonConvert.SerializeObject
                        (contactListDictionary, Formatting.Indented));
                    
                    Console.WriteLine("Thanks! Have a Day.");
                    break;
                }
                userSelection = MainMenu();
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
            //populate dictionary using streamreader and serializer
            using (StreamReader file = new StreamReader(contactsJSON))
            {
                JsonSerializer serializer = new JsonSerializer();
                Dictionary<string, Contact> contactsDictionary = (Dictionary<string, Contact>)serializer.Deserialize(file, typeof(Dictionary<string, Contact>));

                //If the dictionary is null return a new initialized Dictionary
                if(contactsDictionary == null)
                {
                    return new Dictionary<string, Contact>();
                }

                //otherwise return the populated dictionary
                return contactsDictionary;
            }
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
            Console.WriteLine("[1] Create a Contact");
            Console.WriteLine("[2] Edit a Contact");
            Console.WriteLine("[3] Display Contacts");
            Console.WriteLine("[q] to quit");
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
                Console.WriteLine($"[1]: {contactToEdit.FirstName}");
                Console.WriteLine($"[2]: {contactToEdit.LastName}");
                Console.WriteLine($"[3]: {contactToEdit.PhoneNumber}");
                Console.WriteLine($"[4]: {contactToEdit.Email}");
                Console.WriteLine($"[5]: {contactToEdit.DateOfBirth}");
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

        /// <summary>
        /// If the user selects a 3 in the main menu,
        /// the contents of the json file is printed 
        /// to the console in a readable format
        /// </summary>
        /// <param name="contactsJSON"></param>
        public static void PrintContactsToConsole(Dictionary<string, Contact> contactListDictionary)
        {
            Console.Clear();
            foreach (KeyValuePair<string, Contact> kvp in contactListDictionary)
            {
                Console.WriteLine($"Name: {kvp.Value.FullName}");
                Console.WriteLine($"Phone Number: {kvp.Value.PhoneNumber}");
                Console.WriteLine($"Email: {kvp.Value.Email}");
                Console.WriteLine($"DOB: {kvp.Value.DateOfBirth}");
                Console.WriteLine($"Address: {kvp.Value.Address.AddressToString()}");
                Console.WriteLine();
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
