using System;
using Crm.Domain;

namespace Crm.Services
{
    [Service(ServiceOption.PerResolve)]
    internal class UserService : IUserService
    {
        public void CreateUser(IUser user)
        {
            throw new NotImplementedException();
        }

        public IUser GetUser(int userId)
        {
            throw new NotImplementedException();
        }

        public IUser UpdateUser(IUser user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
