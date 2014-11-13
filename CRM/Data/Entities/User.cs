namespace Crm.Data.Entities
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Diagnostics;
	using Domain;

	[ComplexType, MetadataType(typeof(Domain.Metadata.PasswordHash))]
	public class Password : IPasswordHash
	{
		private byte[] _hash;

		[Column("Hash")]
		public byte[] Hash
		{
			get { return _hash; }
			set
			{
				Debug.Assert(value == null || value.Length == 20);
				_hash = value;
			}
		}
	}

	[Table("Users"), MetadataType(typeof(Domain.Metadata.User))]
    public class User : IUser
    {
		private Password _password = new Password();

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

		[Index(IsUnique = true)]
        public string Login { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

		public Password Password
		{
			get { return _password; }
			set { _password = value; }
		}
    }
}