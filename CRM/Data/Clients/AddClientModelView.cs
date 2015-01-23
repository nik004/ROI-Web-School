using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Crm;

namespace Crm.Data
{
    public class AddClientModelView
    {
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }
        
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public PhoneNrType TypePhone { get; set; }

        public ContactsViewModel Contacs { get; set; }

        public enum PhoneNrType
        {
            Other, Mobile, Home, Work
        }

        public void Save()
        {            
        }
    }
}



    
    
    
