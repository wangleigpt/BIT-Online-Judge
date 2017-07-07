namespace BITOJ.SubmissionHost.Components
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 为命令行选项提供解析。
    /// </summary>
    internal static class ArgResolver
    {
        /// <summary>
        /// 解析程序命令行选项。
        /// </summary>
        /// <param name="dispatcher">命令行选项处理器指派器对象。</param>
        /// <returns>一个 string-object 字典，表示解析结果。若在解析过程中发生了错误，返回 null 。</returns>
        /// <exception cref="ArgumentNullException"/>
        public static Dictionary<string, object> Resolve(ArgHandlerDispatcher dispatcher)
        {
            if (dispatcher == null)
                throw new ArgumentNullException(nameof(dispatcher));

            ArgContext context = new ArgContext();
            while (!context.Last)
            {
                if (!dispatcher.Dispatch(context))
                {
                    return null;
                }
            }

            return context.Result;
        }
    }
}
