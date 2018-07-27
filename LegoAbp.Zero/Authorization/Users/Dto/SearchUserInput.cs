using LegoAbp.Paged;
using LegoAbp.Zero.Authorization.Users.Domain;
using System.Linq;

namespace LegoAbp.Zero.Authorization.Users.Dto
{
    public class SearchUserInput : IPageAndFilteredInput<User>
    {
        public string UserName { get; set; }
        public string PhoneNum { get; set; }
        public PageRequest Pagination { get ; set; }

        public IQueryable<User> Filtered(IQueryable<User> query)
        {
            if (!string.IsNullOrEmpty(UserName))
            {
                query = query.Where(c => c.UserName.Contains(UserName));
            }
            if (!string.IsNullOrEmpty(PhoneNum))
            {
                query = query.Where(c => c.PhoneNumber.Contains(PhoneNum));
            }
            return query;
        }
    }
}
