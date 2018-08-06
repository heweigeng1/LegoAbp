using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace LegoAbp.Zero.Authorization.Users.Domain
{
    //public class AbpUserManager : UserManager<User>
    public class AbpUserManager
    {
        private readonly IRepository<User, Guid> _repository;
        public AbpUserManager(IRepository<User, Guid> repository)
        {
            _repository = repository;
        }
    }
}
