using BlogMaster.Application.DTO.Pagination;
using BlogMaster.Domain;
using System.Linq.Expressions;

namespace BlogMaster.API.Extensions
{
    public static class IQueryablePagedResponseExtension
    {
        public static PagedResponse<TDto> ToPagedResponse<TEntity, TDto>(
            this IQueryable<TEntity> query,
            PagedSearch search,
            Expression<Func<TEntity, TDto>> conversion)
            where TDto : class
            where TEntity : BaseEntity
        {
            int itemsPerPage = (int)(search.PerPage > 0 ? search.PerPage : 15);
            int currentPage = (int)(search.Page > 0 ? search.Page : 1);

            int skip = (currentPage - 1) * itemsPerPage;

            return new PagedResponse<TDto>
            {
                TotalCount = query.Count(),
                CurrentPage = currentPage,
                PerPage = itemsPerPage,
                Data = query.Skip(skip)
                             .Take(itemsPerPage)
                             .Select(conversion)
                             .ToList()
            };
        }
    }
}
