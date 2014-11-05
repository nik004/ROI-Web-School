namespace Crm.Admin.Models
{
	using System.Collections.Generic;
	using System.Linq;
	using Domain;

	public class UserListModel
	{
		public IEnumerable<UserModel> Users
		{
			get
			{
				return ServiceFactory.Resolve<IUserService>().GetAll().Select(user => new UserModel(user));
			}
		}

		public int? DeleteId { get; set; }

		public int? EditId { get; set; }
	}
}