using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LegoAbp.Paged
{
    public interface IPageAndFilteredInput<TEntity>
    {
        PageRequest Pagination { get; set; }
        IQueryable<TEntity> Filtered(IQueryable<TEntity> query);
    }
}
