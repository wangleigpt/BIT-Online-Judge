namespace BITOJ.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 表示主题目库题目实体。
    /// </summary>
    public sealed class ProblemEntity
    {
        /// <summary>
        /// 获取或设置题目实体的 ID。该字段不应在外部代码中被修改。
        /// </summary>
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// 获取或设置题目的标题。
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 获取或设置题目作者的用户名。
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// 获取或设置题目的来源。
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// 获取或设置题目的总提交数目。
        /// </summary>
        public int TotalSubmissions { get; set; }

        /// <summary>
        /// 获取或设置题目的 AC 提交数目。
        /// </summary>
        public int AcceptedSubmissions { get; set; }

        /// <summary>
        /// 获取或设置题目的配置目录。
        /// </summary>
        public string ProblemDirectory { get; set; }

        /// <summary>
        /// 初始化 ProblemEntity 类的新实例。
        /// </summary>
        public ProblemEntity()
        {
            Id = 0;
            Title = string.Empty;
            TotalSubmissions = 0;
            AcceptedSubmissions = 0;
            ProblemDirectory = string.Empty;
        }
    }
}
