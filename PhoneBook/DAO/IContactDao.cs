using System;
using System.Collections.Generic;
using System.Text;
using PhoneBook.Classes;

namespace PhoneBook.DAO
{
    public interface IContactDao
    {
        Contact GetContact(int contactId);

        IList<Contact> GetAllContacts();

        void UpdateContact(Contact updatedContact);
    }
}
