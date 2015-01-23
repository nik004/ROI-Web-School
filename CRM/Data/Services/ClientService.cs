using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crm.Data.Entities;

namespace Crm.Data
{
    public static class ClientService
    {
        public static Client Create(Client NewClient)
        {
            using (var context = CrmContextFactory.Get())
            {
               Client NewClientDB = new Client
                    {
                        FirstName = NewClient.FirstName,
                        LastName = NewClient.LastName,
                        DateOfBirth = NewClient.DateOfBirth,
                                               
                    };
                context.Clients.Add(NewClientDB);
                context.SaveChanges();
                return NewClientDB;
            }
        }

        public static void Save(Client SaveClient)
        {
            if (SaveClient == null) throw new ArgumentNullException("Client");
            if (SaveClient.Id <= 0) throw new ArgumentException("Client Id must be a positive integer.", "Client");
            using (var context = CrmContextFactory.Get())
            {
                var _client = context.Clients.Find(SaveClient.Id);
                if (_client == null) throw new ArgumentException("Trying to save non-existent client.", "Client");

                _client.FirstName = SaveClient.FirstName;
                _client.LastName = SaveClient.LastName;
                _client.DateOfBirth = SaveClient.DateOfBirth;

                context.SaveChanges();
            }
        }

    }
}
