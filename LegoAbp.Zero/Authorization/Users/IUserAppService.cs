using Abp.Application.Services;
using LegoAbp.Zero.Authorization.Users.Dto;

namespace LegoAbp.Zero.Authorization.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, SearchUserInput, CreateUserInput, UserDto>
    {
    }
}
