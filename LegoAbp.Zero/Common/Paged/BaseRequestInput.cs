using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegoAbp.Zero.Common.Paged
{
    public class BaseRequestInput : IPagedAndSortedResultRequest
    {
        public int SkipCount { get; set; }
        public int MaxResultCount { get; set; }
        public string Sorting { get; set; }
    }
}
