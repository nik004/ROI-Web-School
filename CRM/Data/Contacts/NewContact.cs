using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crm.Data
{
    public class AddContact
    {
        public enum PhoneNrType
        {
            Other, Mobile, Home, Work
        }
        
        public string PhoneNumber { get; set; }
        
        public PhoneNrType TypePhone { get; set; }
    }
}
