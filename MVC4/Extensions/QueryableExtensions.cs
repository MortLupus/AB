using System.Diagnostics.Contracts;
using System.Linq;

namespace MVC4.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Paging<T>(this IQueryable<T> query, int currentPage, int defaultPage, int pageSize)
        {
            Contract.Requires(query != null);
            Contract.Requires(currentPage > 0);
            Contract.Requires(defaultPage > 0);
            Contract.Requires(pageSize > 0);
            return query
                .Skip((currentPage - defaultPage) * pageSize)
                .Take(pageSize);
        }

    }
}