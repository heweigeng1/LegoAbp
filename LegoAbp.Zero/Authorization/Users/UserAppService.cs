using Abp.Domain.Repositories;
using LegoAbp.Paged;
using LegoAbp.Zero.Authorization.Users.Domain;
using LegoAbp.Zero.Authorization.Users.Dto;
using Microsoft.AspNetCore.Authorization;
using System;

namespace LegoAbp.Zero.Authorization.Users
{

    public class UserAppService: AsyncLegoAbpCrudAppService<User,UserDto,long,SearchUserInput,CreateUserInput,UserDto>,IUserAppService
    {
        private readonly IRepository<User, long> _repository;
        public UserAppService(IRepository<User, long> repository) : base(repository)
        {
            _repository = repository;
        }
        public string Test()
        {
            return "hi app";
        }
    }
}
