
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contact = Contacts.Maui.Models.Contact;

namespace Contacts.Maui.Models
{
    public static class ContactsRepository
    {
        public static List<Contact> _contacts = new List<Contact>()
    {
        new Contact{ID = 1, name="John Doe", email="johndoe@gmail.com"},
        new Contact{ID = 2, name="Jane Doe", email="janedoe@gmail.com"},
        new Contact{ID = 3, name="Prkahar Kard", email="kkard@gmail.com"},
    };
        public static List<Contact> GetContacts() { return _contacts; }

        public static Contact GetContactByID(int contactId) { 

            var contact = _contacts.FirstOrDefault(x => x.ID == contactId);
            if (contact != null)
            {
                return new Contact
                {
                    ID = contact.ID,
                    address = contact.address,
                    name = contact.name,
                    email = contact.email,
                    phone = contact.phone,

                };
            }
            { return null; }
        }

        public static void UpdateContact(int ContactId, Contact contact)
        {
            if (contact == null) return;

            var contactToUpdate = _contacts.FirstOrDefault(x => x.ID == ContactId);
            if (contactToUpdate != null)
            {
                contactToUpdate.name = contact.name; 
                contactToUpdate.email = contact.email;
                contactToUpdate.address = contact.address;
                contactToUpdate.phone = contact.phone;
            }
        }

        public static void AddContact( Contact contact)
        {   var maxId = _contacts.Max(x => x.ID);
            contact.ID = maxId+1;
            _contacts.Add(contact);
        }

        public static void DeleteContact( int ContactId)
        {
            var contact = _contacts.FirstOrDefault( x => x.ID == ContactId);
            if (contact != null)
            {
                _contacts.Remove(contact);
            }
            
        }
        public static List<Contact> SearchContacts(string filteringText)
        {
            var contacts = _contacts.Where(x=> !string.IsNullOrEmpty(x.name) && x.name.StartsWith(filteringText, StringComparison.OrdinalIgnoreCase))?.ToList();
            if (contacts.Count <= 0 || contacts == null)
            {
                var ncontacts = _contacts.Where(x => !string.IsNullOrEmpty(x.email) && x.email.StartsWith(filteringText, StringComparison.OrdinalIgnoreCase))?.ToList();
                if (ncontacts.Count <= 0 || ncontacts == null)
                {
                    var pcontacts = _contacts.Where(x => !string.IsNullOrEmpty(x.phone) && x.phone.StartsWith(filteringText, StringComparison.OrdinalIgnoreCase))?.ToList();
                    if (pcontacts.Count <= 0 || ncontacts == null)
                    {
                        var acontacts = _contacts.Where(x => !string.IsNullOrEmpty(x.address) && x.address.StartsWith(filteringText, StringComparison.OrdinalIgnoreCase))?.ToList();
                        if (acontacts.Count <= 0 || ncontacts == null)
                        {
                            return contacts;
                        }
                        return acontacts;
                    }
                    return pcontacts;
                }
                return ncontacts;
            }
            return contacts;
            
        }
    }
}
