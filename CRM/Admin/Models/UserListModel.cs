namespace Crm.Admin.Models
{
	using System.Collections.Generic;
	using System.Linq;
	using Domain;

	public class UserListModel
	{
		public IEnumerable<UserModel> Users { get; private set; }

		public UserListModel()
		{
			Users = ServiceFactory.Resolve<IUserService>().GetAll().Select(user => new UserModel(user));
		}
	}
}