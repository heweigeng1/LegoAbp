using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;

namespace LegoAbp.Entites
{
    public class LegoAbpEntityBase<TPrimaryKey> : Entity<TPrimaryKey>, IHasCreationTime, IHasModificationTime, ISoftDelete
    {
        public DateTime CreationTime { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
