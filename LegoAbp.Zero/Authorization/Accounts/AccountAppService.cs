
using Abp.Domain.Repositories;
using LegoAbp.Zero.Authorization.Users.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegoAbp.Zero.Authorization.Accounts
{
    public class AccountAppService : IAccountAppService
    {
        protected IRepository<User, Guid> _userRepository;
        public AccountAppService(IRepository<User, Guid> userRepository)
        {
            _userRepository = userRepository;
        }
        public void Login()
        {
            throw new NotImplementedException();
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }

        public void Register()
        {
            throw new NotImplementedException();
        }
    }
}
