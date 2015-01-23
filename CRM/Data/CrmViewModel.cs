using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crm.Data.Entities;

namespace Crm.Data
{
    public class CrmViewModel
    {
        public List<CrmViewClient> ClientList;
        
        public CrmViewModel()
        {
            
            ClientList = GetClientList();
        }

        private List<CrmViewClient> GetClientList()
        {
            List<CrmViewClient> _list = new List<CrmViewClient>();

            using (var context = CrmContextFactory.Get())
            {
                var Clietns = context.Clients.ToList();               

                foreach (var client in Clietns)
                {
                    CrmViewClient tmpViewClientModel = new CrmViewClient(client);
                    
                    _list.Add(tmpViewClientModel);

                }
            }

            return (_list);
        }

        public IEnumerable<Operation> GetCurrentTasks()
        {
            List<Operation> TaskList = new List<Operation>();
            foreach (var client in ClientList)
            {
                if (client.HasLastOparetion())
                {
                    var Time = client.LastOperation.Callback;
                    if (!(Time == null) && (Time > DateTime.Now) && (Time <= DateTime.Now.AddHours(1)))
                    {
                        TaskList.Add(client.LastOperation);
                    }
                }
            }
            return TaskList;
        }

        public string GetRemainTime(Operation Oper)
        { 
            int RemainTime = (int)(((DateTime)Oper.Callback - DateTime.Now).TotalSeconds);
            return (RemainTime.ToString());
        }


    }
}
