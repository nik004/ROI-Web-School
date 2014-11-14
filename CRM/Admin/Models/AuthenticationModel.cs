namespace Crm.Admin.Models
{
	using System.ComponentModel.DataAnnotations;
	using Domain;

	[MetadataType(typeof(Domain.Metadata.UserLogin))]
	public class AuthenticationModel : IUserLogin
	{
		[StringLength(512)]
		public string ReturnUrl { get; set; }

		public string Login { get; set; }

		public string Password { get; set; }

		public bool Remember { get; set; }

		public UserModel Logon()
		{
			var user = ServiceFactory.Resolve<IUserService>().Authenticate(Login, Password);
			return user != null ? new UserModel(user) : null;
		}
	}
}