using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Crm.Data.Entities;

namespace Crm.Data.Clients
{
    public static class ContactSrvice
    {
        internal static void Add(ContactsViewModel ContactsModel)
        {
            using (var context = CrmContextFactory.Get())
            {
                
                foreach ( var NewContact in ContactsModel.GetAll())
                {
                    Contact NewContactDB = new Contact
                        {
                            ClientId = ContactsModel.GetClientId(),
                            PhoneNr = NewContact.PhoneNr,
                            PhoneType = NewContact.PhoneType,
                        };
                    context.Contacts.Add(NewContactDB);
                }
                
                context.SaveChanges();
            }
        }
    }
}
