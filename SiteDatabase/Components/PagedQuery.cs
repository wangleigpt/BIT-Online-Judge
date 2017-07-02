namespace BITOJ.Data.Components
{
    using System;
    using System.Linq;

    /// <summary>
    /// 提供分页查询支持。
    /// </summary>
    public static class PagedQuery
    {
        /// <summary>
        /// 查询指定页上的所有元素。
        /// </summary>
        /// <typeparam name="T">元素对象类型。</typeparam>
        /// <param name="source">可查询的数据源对象。</param>
        /// <param name="page">要查询的页。该数据应该从 1 开始编码。</param>
        /// <param name="elementsPerPage">每一页上的元素数量。</param>
        /// <returns>一个可查询数据源对象，通过该对象可查询到数据源中指定页上的所有数据对象。</returns>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="ArgumentOutOfRangeException"/>
        public static IQueryable<T> Page<T>(this IQueryable<T> source, int page, int elementsPerPage)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (page <= 0)
                throw new ArgumentOutOfRangeException(nameof(page));
            if (elementsPerPage <= 0)
                throw new ArgumentOutOfRangeException(nameof(elementsPerPage));

            int skip = (page - 1) * elementsPerPage;      // 计算应该跳过的元素数量
            return source.Skip(skip).Take(elementsPerPage);
        }
    }
}
