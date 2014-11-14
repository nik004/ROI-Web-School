namespace Crm.Admin.Models
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using Domain;

	[MetadataType(typeof(Domain.Metadata.User))]
	public class NewUserModel : IUser
	{
		private readonly NewPasswordModel _password = new NewPasswordModel();

		public string CancelUrl { get; set; }

		public int Id
		{
			get { return 0; }
			set { throw new NotSupportedException(); }
		}

		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Login { get; set; }

		public NewPasswordModel Password
		{
			get { return _password; }
		}

        public void Save()
		{
			ServiceFactory.Resolve<IUserService>().Create(this, Password);
		}
	}
}