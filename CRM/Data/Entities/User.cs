namespace Crm.Data.Entities
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Diagnostics;

	[Table("Users")]
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(64)]
        public string FirstName { get; set; }

        [StringLength(128)]
        public string LastName { get; set; }

        [Required, StringLength(64)]
        public string Login { get; set; }

		[MinLength(20), MaxLength(20)]
		public byte[] Hash
		{
			get { return _password; }
			set
			{
				Debug.Assert(value == null || value.Length == 20);
				_password = value;
			}
		}

		private byte[] _password;
    }
}