namespace Crm.Domain
{
	public interface IUserLogin
	{
        string Login { get; }
	}

	public interface IUserPassword
	{
		string Password { get; }
	}

	public interface IUserPasswordHash
	{
		byte[] Hash { get; }
	}

	public interface IUser : IUserLogin
    {
		int Id { get; }
		string FirstName { get; }
		string LastName { get; }
    }
}