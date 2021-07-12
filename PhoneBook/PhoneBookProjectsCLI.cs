using PhoneBook.DAO;
using System;
using System.Collections.Generic;
using System.Text;
using PhoneBook.Classes;

namespace PhoneBook
{
    public class PhoneBookProjectsCLI
    {
        private readonly IContactDao contactDao;

        public PhoneBookProjectsCLI(IContactDao contactDao)
        {
            this.contactDao = contactDao;
        }

        public void Run()
        {
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

                    //print success message, and then clear the console
                    Console.WriteLine("Contact successfully added, press any button to continue:");
                    Console.ReadLine();
                    Console.Clear();

                }
                //User selected "Edit a Contact"
                else if (userSelection == 2)
                {
                    //Enter the contact list method

                    //Clear the console
                    Console.Clear();
                }
                //User selected "Display all Contacts"
                else if (userSelection == 3)
                {
                    //print the contacts to the console
                    //from the contact list dictionary

                    //hold screen to see contacts, press button to continue
                    Console.WriteLine("Press any button to continue:");
                    Console.ReadLine();

                    //Clear the console
                    Console.Clear();
                }
                else if (userSelection == 0)
                {

                    Console.WriteLine("Thanks! Have a Day.");
                    break;
                }
                userSelection = MainMenu();
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
            Console.WriteLine("[3] Display a Contact");
            Console.WriteLine("[4] Display all Contacts");
            Console.WriteLine("[5] Delete a Contact");
            Console.WriteLine("[q] to quit");
            Console.Write("Select a number to continue:");

            //ensure user input is valid. which at this point is
            //1, 2, 3, 4, 5 or 'q'
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
                    if (entry != 1 && entry != 2 && entry != 3 && entry != 4 && entry != 5)
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
        /// If the user selects a 3 in the main menu,
        /// the contents of the json file is printed 
        /// to the console in a readable format
        /// </summary>
        /// <param name="contactsJSON"></param>
        public static void PrintContactsToConsole()
        {
                Console.Clear();
                Console.WriteLine($"Name:");
                Console.WriteLine($"Phone Number:");
                Console.WriteLine($"Email:");
                Console.WriteLine($"DOB:");
                Console.WriteLine($"Address:");
                Console.WriteLine();
        }
    }
}
