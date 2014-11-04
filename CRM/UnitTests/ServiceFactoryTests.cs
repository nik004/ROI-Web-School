using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Crm;
using Crm.Domain;

namespace UnitTests
{
    [TestClass]
    public class ServiceFactoryTests
    {
        [TestMethod]
        public void Resolve()
        {
            var userService = ServiceFactory.Resolve<IUserService>();
            Assert.IsNotNull(userService);
        }

        private class ExpectedException : Exception { }

        private interface IService
        {
            void RaiseExpectedException();
        }

        private class Service : IService
        {
            public void RaiseExpectedException()
            {
                throw new ExpectedException();
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ExpectedException))]
        public void Register()
        {
            ServiceFactory.Register<IService>(new ServiceFactory.Singleton<Service>());
            var service = ServiceFactory.Resolve<IService>();
            Assert.IsNotNull(service);
            service.RaiseExpectedException();
        }

        private class UserService : IUserService
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

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Override()
        {
            ServiceFactory.Override<IUserService>(new ServiceFactory.PerResolve<UserService>());
            var service = ServiceFactory.Resolve<IUserService>();
            Assert.IsNotNull(service);
            service.CreateUser(null);
        }
    }
}
