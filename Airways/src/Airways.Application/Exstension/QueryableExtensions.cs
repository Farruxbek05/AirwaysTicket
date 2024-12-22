using Airways.Application.Models;
using Airways.Core.Common;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Airways.Application.Exstension
{
    public static class QueryableExtensions
    {
        public static async Task<PagedResult<T>> ToPagedResultAsync<T>(this IQueryable<T> query, Option options) where T : BaseEntity
        {
            if (options.PageNumber < 1)
                options.PageNumber = 1;

            if (options.PageSize < 1)
                options.PageSize = 10;

            var totalCount = await query.CountAsync();

            var items = await query
               .Skip((options.PageNumber - 1) * options.PageSize)
               .Take(options.PageSize)
               .ToListAsync();

            return new PagedResult<T>
            {
                Items = items,
                TotalCount = totalCount,
                PageSize = options.PageSize,
                PageNumber = options.PageNumber
            };
        }

        public static async Task<PagedResult<TEntityDTO>> ToPagedResultAsync<TEntity, TEntityDTO>(
            this IQueryable<TEntity> query,
            Option options,
            IMapper mapper) where TEntity : BaseEntity
        {
            if (options.PageNumber < 1)
                options.PageNumber = 1;

            if (options.PageSize < 1)
                options.PageSize = 10;

            var totalCount = await query.CountAsync();

            var items = await query
               .Skip((options.PageNumber - 1) * options.PageSize)
               .Take(options.PageSize)
               .ProjectTo<TEntityDTO>(mapper.ConfigurationProvider)
               .ToListAsync();

            return new PagedResult<TEntityDTO>
            {
                Items = items,
                TotalCount = totalCount,
                PageSize = options.PageSize,
                PageNumber = options.PageNumber
            };
        }
    }
}
