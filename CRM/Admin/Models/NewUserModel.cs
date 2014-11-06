namespace Crm.Admin.Models
{
	using Domain;
    using System.ComponentModel.DataAnnotations;

	public class NewUserModel : IUser
	{
		int IUser.Id { get { return 0; } }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Login { get; set; }

		[DataType(DataType.Password)]
        [Display(Name="Enter")]
        public string Password1 { get; set; }

        [DataType(DataType.Password)]
        [Display(Name="Confirm")]
        public string Password2 { get; set; }

        public void Save()
		{
			ServiceFactory.Resolve<IUserService>().Create(this, Password1);
		}
	}
}