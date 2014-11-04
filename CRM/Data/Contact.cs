using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crm.Data
{
    public enum PhoneNrType : byte
    {
        Other, Mobile, Home, Work
    }

    [Table("Contacts")]
    public class Contact
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int ClientId { get; set; }

        PhoneNrType Type { get; set; }

        [Required, StringLength(32, MinimumLength = 1)]
        public string PhoneNr { get; set; }

        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }
    }
}
