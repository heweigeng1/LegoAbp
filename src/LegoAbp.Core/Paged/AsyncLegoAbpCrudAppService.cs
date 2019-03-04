using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace LegoAbp.Paged
{
    public class AsyncLegoAbpCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput> : AsyncCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput>
        where TEntity : class, IEntity<TPrimaryKey>
        where TEntityDto : IEntityDto<TPrimaryKey>
        where TUpdateInput : IEntityDto<TPrimaryKey>
    {
        public AsyncLegoAbpCrudAppService(IRepository<TEntity, TPrimaryKey> repository) : base(repository)
        {
        }
        public  async Task<AntdPagedResultDto<TEntityDto>> Paging(TGetAllInput input)
        {
            //检查权限
            CheckGetAllPermission();

            var paged = input as IPageAndFilteredInput<TEntity>;

            //搜索过滤
            var query = CreateFilteredQuery(input);
            query = paged.Filtered(query);

            var totalCount = await AsyncQueryableExecuter.CountAsync(query);
            //排序
            query = query.OrderBy(paged.Pagination.Sorter, paged.Pagination.SortDirection);
            //分页
            query = query.Paging(paged.Pagination.Current, paged.Pagination.PageSize);

            var entities = await AsyncQueryableExecuter.ToListAsync(query);
            return new AntdPagedResultDto<TEntityDto>(
               entities.Select(MapToEntityDto).ToList(),
               paged.Pagination.Current,
               paged.Pagination.PageSize,
               totalCount
            );
        }
    }
}
