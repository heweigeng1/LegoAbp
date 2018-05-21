using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegoAbp.Zero.Users.Domain
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
