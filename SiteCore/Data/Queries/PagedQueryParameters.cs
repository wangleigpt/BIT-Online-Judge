namespace BITOJ.Core.Data.Queries
{
    /// <summary>
    /// 为基于页的数据实体对象查询提供参数。
    /// </summary>
    public sealed class PagedQueryParameters
    {
        /// <summary>
        /// 获取或设置要查询的数据页的编码。该编码从 1 开始。
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// 获取或设置查询的数据页中一页内元素的数量。
        /// </summary>
        public int EntriesPerPage { get; set; }

        /// <summary>
        /// 创建 PagedQueryParameters 类的新实例。
        /// </summary>
        /// <param name="page">要查询的数据页的编码。</param>
        /// <param name="entriesPerPage">查询的数据页中一页内元素的数量。</param>
        public PagedQueryParameters(int page, int entriesPerPage)
        {
            Page = page;
            EntriesPerPage = entriesPerPage;
        }
    }
}
