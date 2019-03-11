using Abp.Domain.Repositories;
using LegoAbp.Paged;
using LegoAbp.Zero.Authorization.Users.Domain;
using LegoAbp.Zero.Authorization.Users.Dto;

namespace LegoAbp.Zero.Authorization.Users
{

    public class UserAppService: AsyncLegoAbpCrudAppService<User,UserDto,long,SearchUserInput,CreateUserInput,UserDto>,IUserAppService
    {
        private readonly IRepository<User, long> _userRepository;
        public UserAppService(IRepository<User, long> userRepository) : base(userRepository)
        {
            _userRepository = userRepository;
        }
        public string Test()
        {
            return _userRepository.FirstOrDefault(1).UserName;
        }
    }
}
