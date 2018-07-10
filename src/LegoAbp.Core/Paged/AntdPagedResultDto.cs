using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LegoAbp.Paged
{
    public class AntdPagedResultDto
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }

        public bool HasPreviousPage => (PageIndex > 0);

        public bool HasNextPage => (PageIndex + 1 < TotalPages);
        
    }

    public class AntdPagedResultDto<T> : AntdPagedResultDto,IPagedResult<T>, IListResult<T>, IHasTotalCount
    {
        public IReadOnlyList<T> Items { get; set; }

        public AntdPagedResultDto(List<T> source, int pageIndex, int pageSize,int totalCount)
        {
            if (pageSize == 0)
            {
                return;
            }
            int total = totalCount;
            this.TotalCount = total;
            this.TotalPages = total / pageSize;

            if (total % pageSize > 0)
                TotalPages++;

            this.PageSize = pageSize;
            this.PageIndex = pageIndex;
            this.Items = source;
        }
        public AntdPagedResultDto(IQueryable<T> source, int pageIndex, int pageSize)
        {
            if (pageSize == 0)
            {
                return;
            }
            int total = source.Count();
            this.TotalCount = total;
            this.TotalPages = total / pageSize;

            if (total % pageSize > 0)
                TotalPages++;

            this.PageSize = pageSize;
            this.PageIndex = pageIndex;
            this.Items=source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }
        

        public AntdPagedResultDto(IEnumerable<T> source, int pageIndex, int pageSize, int totalCount)
        {
            if (pageSize == 0)
            {
                return;
            }
            TotalCount = totalCount;
            TotalPages = TotalCount / pageSize;

            if (TotalCount % pageSize > 0)
                TotalPages++;

            this.PageSize = pageSize;
            this.PageIndex = pageIndex;
            this.Items=source.Skip(pageIndex * pageSize - pageSize).Take(pageSize).ToList();
        }
    }
}
