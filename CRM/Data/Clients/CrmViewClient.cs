using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crm.Data.Entities;

namespace Crm.Data
{
    public class CrmViewClient
    {
        
        public Client Client;
        
        public Operation LastOperation;

        public DateTime? CallTime;

        public int Age;

        public CrmViewClient(Client _client)
        {
            Client = _client;
            LastOperation = _client.Operations.LastOrDefault();
            GetAge();
            if ((HasLastOparetion()))
            {
                CallTime = LastOperation.Callback;
            }
        }
        
        public void  GetAge() 
        {
            var years = (DateTime.Now - Client.DateOfBirth).TotalDays / 365;
            Age = (int)(years);
        }

        public bool HasLastOparetion()
        {
            return (!(LastOperation == null)) ? (true) : (false);

        }
        public string GetTypeLastOperation()
        {

            return (HasLastOparetion()) ? (LastOperation.Type.ToString()) : ("---");
            
        }

     


    }
}
