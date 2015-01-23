using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crm.Data.Entities;
using Crm.Data.Calls;

namespace Crm.Data
{
    public class CallsModelView
    {
        public Client Client { get; set; }

        List<Contact> Contacts { get; set; }

        List<Operation> Operations { get; set; }

        public NewOperationModel NewOperation { get; set; }

        public CallsModelView(int ClientId)
        {
            using (var contex = CrmContextFactory.Get())
            {
                var Client = contex.Clients.Where(t => t.Id == ClientId).FirstOrDefault();
                if (Client == null) throw new ArgumentNullException("Client");
                Contacts = contex.Contacts.Where(c => c.ClientId == ClientId).ToList();
                Operations = contex.Operations.Where(c => c.ClientId == ClientId).ToList();

            }
        }

        public int GetAge() 
        {
            var years = (DateTime.Now - Client.DateOfBirth).TotalDays / 365;
            return (int)(years);
        }

        public IEnumerable<Operation> GetAllOperions()
        {
            return (Operations);
        }
    }
}
