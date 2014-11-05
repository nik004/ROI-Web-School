namespace Crm.Admin.Models
{
	using Domain;

	public class NewUserModel : IUser
	{
		int IUser.Id { get { return 0; } }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Login { get; set; }
		public string Password { get; set; }

		public void Save()
		{
			ServiceFactory.Resolve<IUserService>().Create(this, Password);
		}
	}
}