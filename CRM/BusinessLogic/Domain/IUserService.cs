namespace Crm.Domain
{
    public interface IUserService
    {
        void CreateUser(IUser user);
        IUser GetUser(int userId);
        IUser UpdateUser(IUser user);
        void DeleteUser(int userId);
    }
}
