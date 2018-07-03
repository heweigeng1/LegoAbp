using Abp.Application.Services;
using Abp.Domain.Repositories;
using LegoAbp.Users.Dto;
using LegoAbp.Zero.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegoAbp.Users
{
    public class UserAppService : AsyncCrudAppService<User,UserDto,Guid>, IUserAppService
    {
        public IRepository<User, Guid> _repository;
        public UserAppService(IRepository<User, Guid> repository):base(repository)
        {
            _repository = repository;
        }
        public void Test1()
        {

        }
    }
}
