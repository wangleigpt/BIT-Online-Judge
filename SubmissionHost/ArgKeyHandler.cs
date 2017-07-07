namespace BITOJ.SubmissionHost
{
    using BITOJ.SubmissionHost.Components;
    using NLog;
    using System;
    using System.Text;

    /// <summary>
    /// 处理 -k 命令行选项。
    /// </summary>
    internal sealed class ArgKeyHandler : IArgHandler
    {
        private static Logger Log = LogManager.GetCurrentClassLogger();

        public bool Accept(string arg)
        {
            return (string.Compare(arg, "-k", false) == 0);
        }

        public bool Resolve(ArgContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if (context.Result.ContainsKey("key"))
            {
                Log.Error("重复设置判题器连接密钥。");
                return false;
            }

            context.FetchNext();    // 跳过 -k 选项。
            string key = context.FetchOptionArg();

            if (key == null)
            {
                Log.Error("命令行选项 -k 无参数。");
                return false;
            }
            else
            {
                // 加载 literal key。
                context.Result.Add("key", Encoding.Unicode.GetBytes(key));

                return true;
            }
        }
    }
}
