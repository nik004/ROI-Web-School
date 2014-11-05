namespace Crm.Data
{
	using System.Data.Entity;
	using Entities;

	public interface ICrmContext
	{
		IDbSet<User> Users { get; }
		IDbSet<Client> Clients { get; }
		IDbSet<Contact> Contacts { get; }
		IDbSet<Operation> Operations { get; }
	}
}