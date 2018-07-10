using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LegoAbp.Paged
{
    public static class PageResultExtension
    {
        public static AntdPagedResultDto<T> ToPageResult<T>(this IEnumerable<T> source, int pageIndex, int pageSize)
        {
            return new AntdPagedResultDto<T>(source, pageIndex, pageSize, source.Count());
        }
        public static AntdPagedResultDto<T> ToPageResult<T>(this IQueryable<T> linq, int pageIndex, int pageSize)
        {
            return new AntdPagedResultDto<T>(linq, pageIndex, pageSize);
        }
        public static AntdPagedResultDto<T> ToPageResult<T>(this IQueryable<T> query, PageRequest request)
        {
            return new AntdPagedResultDto<T>(query.OrderBy(request.Sorter, request.SortDirection), request.Current, request.PageSize);
        }
        public static IQueryable<T> Paging<T>(this IQueryable<T> query, int pageIndex, int pageSize)
        {
            return query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }
    }
}
