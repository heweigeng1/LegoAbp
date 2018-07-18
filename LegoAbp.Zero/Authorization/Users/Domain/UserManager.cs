using Abp.Domain.Repositories;
using System;

namespace LegoAbp.Zero.Authorization.Users.Domain
{
    public class UserManager
    {
        private readonly IRepository<User, Guid> _repository;
        public UserManager(IRepository<User, Guid> repository)
        {
            _repository = repository;
        }
    }
}
