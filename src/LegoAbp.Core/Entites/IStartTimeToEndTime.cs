using System;

namespace LegoAbp.Entites
{
    public interface IStartTimeToEndTime
    {
        DateTime? StartTime { get; set; }
        DateTime? EndTime { get; set; }
    }
}
