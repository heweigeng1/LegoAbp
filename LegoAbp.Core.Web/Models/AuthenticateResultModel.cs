using LegoAbp.Zero.Authorization.Users.Dto;

namespace LegoAbp.Core.Web.Models
{
    public class AuthenticateResultModel
    {
        public string AccessToken { get; set; }

        public string EncryptedAccessToken { get; set; }
        public int ExpireInSeconds { get; set; }
        public long UserId { get; set; }
        //public StoreDto Store { get; set; }
        public UserDto User { get; set; }
        public string[] Roles { get; set; }
    }
}
