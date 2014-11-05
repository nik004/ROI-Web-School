namespace Crm.Data.Entities
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("Users")]
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, StringLength(64, MinimumLength = 1)]
        public string FirstName { get; set; }

        [Required, StringLength(128, MinimumLength = 1)]
        public string LastName { get; set; }

        [Required, StringLength(64, MinimumLength = 1)]
        public string Login { get; set; }

        [StringLength(16)]
        public string Password { get; set; }
    }
}
