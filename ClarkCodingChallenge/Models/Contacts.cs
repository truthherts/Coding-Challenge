using System.Collections.Generic;

namespace ClarkCodingChallenge.Models
{
    public class Contacts
    {
        private static List<Contact> contacts;

        static Contacts()
        {
            contacts = new List<Contact>();
        }
        public static void AddPerson(Contact c)
        {
            contacts.Add(c);
        }
        public static List<Contact> GetContacts()
        {
            return contacts;
        }
    }
}
