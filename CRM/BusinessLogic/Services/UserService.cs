namespace Crm.Services
{
	using System;
	using System.Data.Entity;
	using System.Linq;
	using Data;
	using Data.Entities;
	using Domain;

	using System.Collections.Generic;

	[Service(ServiceOption.Singleton)]
    internal class UserService : IUserService
    {
        public void Create(IUser user, string password)
        {
	        using (var context = CrmContextFactory.Current.CreateContext())
	        {
		        context.Users.Add(
			        new User
			        {
				        FirstName = user.FirstName,
				        LastName = user.LastName,
				        Login = user.Login,
				        Password = password
			        }
			    );

				context.SaveChanges();
	        }
        }

        public IUser Read(int id)
        {
	        using (var context = CrmContextFactory.Current.CreateContext())
	        {
		        try
		        {
			        return
				        context.Users.AsNoTracking()
					    .Where(user => user.Id == id)
					    .Select(
						    user => new DomainUser
						    {
							    Id = user.Id,
							    FirstName = user.FirstName,
							    LastName = user.LastName,
							    Login = user.Login
						    }
					    )
					    .First();
		        }
		        catch (InvalidOperationException ex)
		        {
			        throw new ArgumentException("User not found.", "id", ex);
		        }
	        }
        }

        public void Update(IUser user)
        {
			if (user == null) throw new ArgumentNullException("user");
			if (user.Id <= 0) throw new ArgumentException("User Id must be a positive integer.", "user");
	        using (var context = CrmContextFactory.Current.CreateContext())
	        {
		        var dbUser = context.Users.Find(user.Id);
		        if (dbUser == null) throw new ArgumentException("Trying to update non-existent user.", "user");

		        dbUser.FirstName = user.FirstName;
		        dbUser.LastName = user.LastName;
		        dbUser.Login = user.Login;

				context.SaveChanges();
	        }
        }

		public void Delete(int id)
		{
			if (id <= 0) throw new ArgumentException("User Id must be a positive integer.", "id");
			using (var context = CrmContextFactory.Current.CreateContext())
			{
				var dbUser = context.Users.Find(id);
				if (dbUser == null) return;
				context.Users.Remove(dbUser);
				context.SaveChanges();
			}
		}

		public void SetPassword(int id, string password)
		{
			using (var context = CrmContextFactory.Current.CreateContext())
			{
				var dbUser = context.Users.Find(id);
				if (dbUser == null) throw new ArgumentException("User not found.", "id");
				dbUser.Password = password;
				context.SaveChanges();
			}
		}

		public IEnumerable<IUser> GetAll()
	    {
		    using (var context = CrmContextFactory.Current.CreateContext())
		    {
			    return
					context.Users.AsNoTracking()
					.Select(
						user => new DomainUser
						{
							Id = user.Id,
							FirstName = user.FirstName,
							LastName = user.LastName,
							Login = user.Login
						}
					)
					.ToList();
		    }
	    }

		private class DomainUser : IUser
		{
			public int Id { get; set; }
			public string FirstName { get; set; }
			public string LastName { get; set; }
			public string Login { get; set; }
		}
    }
}
