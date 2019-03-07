using Abp.Domain.Entities;

namespace LegoAbp.Auditing.Domain
{
    public interface ILegoCreationAudited<TForeignKey>
    {
        TForeignKey CreatorUserId { get; set; }
    }
    public interface ILegoCreationAudited<TUser, TForeignKey> : ILegoCreationAudited<TForeignKey> where TUser : class
    {
        TUser CreatorUser { get; set; }
    }
}
