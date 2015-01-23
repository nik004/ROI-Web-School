using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crm.Data.Entities;
using Crm.Data.Clients;

namespace Crm.Data
{
    public class ClientViewModel
    {
        public Client Client;

        public ContactsViewModel Contacts;

        public AddContact NewContact;

        public ClientViewModel(int Id)
        {
            using (var contex = CrmContextFactory.Get())
            {
                var _client = contex.Clients.Where(t => t.Id == Id).FirstOrDefault();
                if (_client == null) throw new ArgumentNullException("Client");
                Client = (Client) (_client);
                Contacts = new ContactsViewModel (Client.Id);

            }
        }

        public ClientViewModel() 
        {
            Client = new Client();
            Contacts = new ContactsViewModel();
        }

        public void Add()
        {
            ClientService.Create(this.Client);
            ContactSrvice.Add(this.Contacts);
        }

        public void Save()
        {
            ClientService.Save(this.Client);
        }
    }
}
