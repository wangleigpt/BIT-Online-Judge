﻿namespace BITOJ.Core.Data.Queries
{
    /// <summary>
    /// 为 BITOJ 主题目库的数据查询提供参数。
    /// </summary>
    public sealed class ProblemArchieveQueryParameter
    {
        /// <summary>
        /// 获取或设置要查询的题目标题。
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否通过题目标题进行查询。
        /// </summary>
        public bool QueryByTitle { get; set; }

        /// <summary>
        /// 获取或设置要查询的题目源。
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否通过题目源进行查询。
        /// </summary>
        public bool QueryBySource { get; set; }

        /// <summary>
        /// 获取或设置要查询的题目作者。
        /// </summary>
        public string Author { get; set; }
        
        /// <summary>
        /// 获取或设置一个值，该值指示是否通过题目作者进行查询。
        /// </summary>
        public bool QueryByAuthor { get; set; }

        /// <summary>
        /// 获取或设置分页查询参数。
        /// </summary>
        public PagedQueryParameters Page { get; set; }

        /// <summary>
        /// 创建 ProblemArchieveQueryParameter 类的新实例。
        /// </summary>
        public ProblemArchieveQueryParameter()
        {
            Title = string.Empty;
            Source = string.Empty;
            Author = string.Empty;
            QueryByTitle = false;
            QueryBySource = false;
            QueryByAuthor = false;
            Page = new PagedQueryParameters(1, int.MaxValue);
        }
    }
}
