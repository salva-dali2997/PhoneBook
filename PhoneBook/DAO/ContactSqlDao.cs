using System;
using System.Collections.Generic;
using System.Text;
using PhoneBook.Classes;
using System.Data.SqlClient;

namespace PhoneBook.DAO
{
    public class ContactSqlDao: IContactDao
    {
        private readonly string connectionString;

        public ContactSqlDao(string connString)
        {
            connectionString = connString;
        }

        public Contact GetContact(int contactId)
        {
            Contact contact = null;
            string sqlQuery = "SELECT first_name, last_name,  " +
                "FROM contact " +
                "WHERE contact_id = @contact_id;";
        }

        public IList<Contact> GetAllContacts()
        {

        }

        public void UpdateContact(Contact updatedContact)
        {

        }
    }
}
