using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crm.Data.Entities;

namespace Crm.Data
{
    public interface IContactsModel
    {
        IEnumerable<Contact> GetAll();

        //void Add(Contact NewContact);

        void Delete(Contact Contact);

        void Edit(Contact Contact);

    }
}
