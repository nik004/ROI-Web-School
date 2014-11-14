namespace Crm.Admin.Models
{
	using System.ComponentModel.DataAnnotations;
	using Domain;

	[MetadataType(typeof(Domain.Metadata.UserLogin))]
	public class UserCredentialsModel : IUserLogin
	{
		public string Login { get; set; }
		public string Password { get; set; }
	}
}