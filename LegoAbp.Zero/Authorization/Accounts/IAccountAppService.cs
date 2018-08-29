using Abp.Domain.Services;
using LegoAbp.Zero.Authorization.Accounts.Dto;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace LegoAbp.Zero.Authorization.Accounts
{
    public interface IAccountAppService : IDomainService
    {
        /// <summary>
        /// 手机注册
        /// </summary>
        Task<IdentityResult> RegisterByPhone(PhoneNumberRegisterInput input);
        /// <summary>
        /// 登录
        /// </summary>
        Task<SignInResult> Login(PhoneNumberLoginInput input);
        /// <summary>
        /// 注销
        /// </summary>
        string Logout();
    }
}
