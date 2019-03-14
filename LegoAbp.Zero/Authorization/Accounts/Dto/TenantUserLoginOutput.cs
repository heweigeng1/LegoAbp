namespace LegoAbp.Zero.Authorization.Accounts.Dto
{
    public class TenantUserLoginOutput
    {
        public string AccessToken { get; set; }
        public int ExpireInSeconds { get; set; }
        public long UserId { get; set; }
        public string[] Roles { get; set; }

    }
}
