using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Crm;
using Crm.Domain;

namespace UnitTests
{
	using System.Collections.Generic;

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
            public void Create(IUser user, string password)
            {
                throw new NotImplementedException();
            }

            public IUser Read(int id)
            {
                throw new NotImplementedException();
            }

            public void Update(IUser user)
            {
                throw new NotImplementedException();
            }

            public void Delete(int id)
            {
                throw new NotImplementedException();
            }

	        public void SetPassword(int id, string password)
	        {
		        throw new NotImplementedException();
	        }

	        public IUser Authenticate(string login, string password)
	        {
		        throw new NotImplementedException();
	        }

	        public IEnumerable<IUser> GetAll()
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
            service.Create(null, null);
        }
    }
}
