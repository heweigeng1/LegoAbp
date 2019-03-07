using System;

namespace LegoAbp.Auditing.Domain
{
    public interface ILegoCreationTime
    {
        /// <summary>
        /// Creation time of this entity.
        /// </summary>
        DateTime CreationTime { get; set; }
    }
}
