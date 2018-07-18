using Abp.Domain.Repositories;
using LegoAbp.Paged;
using LegoAbp.Zero.Authorization.Users.Domain;
using LegoAbp.Zero.Authorization.Users.Dto;
using Microsoft.AspNetCore.Authorization;
using System;

namespace LegoAbp.Zero.Authorization.Users
{

    public class UserAppService: AsyncLegoAbpCrudAppService<User,UserDto,Guid,SearchUserInput,CreateUser,UserDto>,IUserAppService
    {
        private readonly IRepository<User, Guid> _repository;
        public UserAppService(IRepository<User, Guid> repository) : base(repository)
        {
            _repository = repository;
        }
        public string Test()
        {
            return "hi app";
        }
    }
}
