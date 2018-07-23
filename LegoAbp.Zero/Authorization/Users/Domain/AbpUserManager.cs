using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace LegoAbp.Zero.Authorization.Users.Domain
{
    public class AbpUserManager : UserManager<User>
    {
        private readonly IRepository<User, Guid> _repository;
        public AbpUserManager(IRepository<User, Guid> repository)
        {
            _repository = repository;
        }
        public virtual async Task ValidatePhoneNum()
        {
            if (_repository.FirstOrDefault())
            {

            }
        }
        public void ValidateEmail()
        {

        }
        public void ValidateUserName()
        {

        }
    }
}
