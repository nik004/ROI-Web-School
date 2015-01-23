using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Crm.Data.Entities;

namespace Crm.Data.Calls
{
    public class NewOperationModel
    {
        public DateTime Performed { get; set; }

        public OperationType Type { get; set; }

        public DateTime? Callback { get; set; }

        public decimal? Amount { get; set; }

        public string Comment { get; set; }

    }
}
