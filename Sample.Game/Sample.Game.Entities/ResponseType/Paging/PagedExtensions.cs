using System.Linq;

namespace Sample.Game.Entities.ResponseType.Paging
{
    public static class PagedExtensions
    {
        public static PagedList<TSource> ToPagedList<TSource>(this IQueryable<TSource> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize).ToList();
            return new PagedList<TSource>(items, count, pageNumber, pageSize);
        }
    }
}
