using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.Runtime.Security;
using LegoAbp.Core.Web.Models;
using LegoAbp.Zero.Authorization.Users.Domain;
using LegoAbp.Zero.Tenants.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using LegoAbp.Core.Web.JwtBearer;
using Abp.MultiTenancy;
using LegoAbp.Zero.Authorization.Accounts;
using LegoAbp.Zero.Authorization;
using LegoAbp.Zero.Authorization.Users.Dto;

namespace LegoAbp.Core.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    public class TokenAuthController : LegoAbpControllerBase
    {
        private readonly TokenAuthConfiguration _configuration;
        private readonly ITenantCache _tenantCache;
        private readonly LogInManager _logInManager;
        private readonly AbpLoginResultTypeHelper _abpLoginResultTypeHelper;
        private readonly LegoAbpUserManager _userManager;

        public TokenAuthController(TokenAuthConfiguration configuration, ITenantCache tenantCache, LogInManager logInManager, AbpLoginResultTypeHelper abpLoginResultTypeHelper, LegoAbpUserManager userManager)
        {
            _configuration = configuration;
            _tenantCache = tenantCache;
            _logInManager = logInManager;
            _abpLoginResultTypeHelper = abpLoginResultTypeHelper;
            _userManager = userManager;
        }
        [HttpPost]
        public async Task<AuthenticateResultModel> Authenticate([FromBody] AuthenticateModel model)
        {
            var loginResult = await GetLoginResultAsync(
                model.UserNameOrEmailAddress,
                model.Password,
                GetTenancyNameOrNull()
            );
            var accessToken = CreateAccessToken(CreateJwtClaims(loginResult.Identity));
            return new AuthenticateResultModel
            {
                AccessToken = accessToken,
                EncryptedAccessToken = GetEncrpyedAccessToken(accessToken),
                ExpireInSeconds = (int)_configuration.Expiration.TotalSeconds,
                UserId = loginResult.User.Id,
                User = AutoMapper.Mapper.Map<UserDto>(loginResult.User),
                Roles = _userManager.GetUserRoles(loginResult.User.Id, null).ToArray()
            };
        }

        private string GetTenancyNameOrNull()
        {
            if (!AbpSession.TenantId.HasValue)
            {
                return null;
            }

            return _tenantCache.GetOrNull(AbpSession.TenantId.Value)?.TenancyName;
        }

        private async Task<AbpLoginResult<Tenant, User>> GetLoginResultAsync(string usernameOrEmailAddress, string password, string tenancyName)
        {
            var loginResult = await _logInManager.LoginAsync(usernameOrEmailAddress, password, tenancyName);

            switch (loginResult.Result)
            {
                case AbpLoginResultType.Success:
                    return loginResult;
                default:
                    throw _abpLoginResultTypeHelper.CreateExceptionForFailedLoginAttempt(loginResult.Result, usernameOrEmailAddress, tenancyName);
            }
        }

        private string CreateAccessToken(IEnumerable<Claim> claims, TimeSpan? expiration = null)
        {
            var now = DateTime.UtcNow;

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _configuration.Issuer,
                audience: _configuration.Audience,
                claims: claims,
                notBefore: now,
                expires: now.Add(expiration ?? _configuration.Expiration),
                signingCredentials: _configuration.SigningCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }

        private static List<Claim> CreateJwtClaims(ClaimsIdentity identity)
        {
            var claims = identity.Claims.ToList();
            var nameIdClaim = claims.First(c => c.Type == ClaimTypes.NameIdentifier);

            // Specifically add the jti (random nonce), iat (issued timestamp), and sub (subject/user) claims.
            claims.AddRange(new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, nameIdClaim.Value),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.Now.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64)
            });

            return claims;
        }

        private string GetEncrpyedAccessToken(string accessToken)
        {
            return SimpleStringCipher.Instance.Encrypt(accessToken, LegoAbpConsts.DefaultPassPhrase);
        }
    }
}
