namespace BITOJ.SubmissionHost.Components
{
    /// <summary>
    /// 为命令行选项处理器提供接口。
    /// </summary>
    internal interface IArgHandler
    {
        /// <summary>
        /// 检查当前的处理器是否接受给定的命令行选项输入。
        /// </summary>
        /// <param name="arg">待测试的命令行选项输入。</param>
        /// <returns>一个值，该值指示给定的命令行选项输入是否被当前的命令行选项处理器接受。</returns>
        bool Accept(string arg);

        /// <summary>
        /// 从给定的命令行处理上下文解析一个命令行选项。
        /// </summary>
        /// <param name="context">待解析的命令行处理上下文对象。</param>
        /// <returns>一个值，该值指示处理是否成功。</returns>
        bool Resolve(ArgContext context);
    }
}
