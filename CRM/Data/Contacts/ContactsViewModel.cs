using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crm.Data.Entities;

namespace Crm.Data
{
    public class ContactsViewModel : IContactsModel
    {
        IEnumerable<Contact> Contacts { get; set; }

        int ClientIdForContacts { get; set; }
        
        public ContactsViewModel(int ClientId)
        {
            ClientIdForContacts = ClientId;
            using (var context = CrmContextFactory.Get())
            {
                Contacts = context.Contacts.Where(c => c.ClientId == ClientId).ToList(); 
            }
        }

        public ContactsViewModel()
        {
            Contacts = new List<Contact>();
        }

        public IEnumerable<Contact> GetAll()
        {
            return (Contacts);
        }

        public int GetClientId()
        {
            return (ClientIdForContacts);
        }

        public void Add(AddContact NewContact)
        { 
                
        }

        public void Delete(Contact Contact)
        { }

        public void Edit(Contact Contact)
        { }

    }
}
