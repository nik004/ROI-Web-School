namespace Crm.Domain
{
	public interface IUserLogin
	{
        string Login { get; }
	}

	public interface IPasswordHash
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