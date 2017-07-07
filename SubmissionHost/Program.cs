namespace BITOJ.SubmissionHost
{
    using BITOJ.SubmissionHost.Components;
    using NLog;
    using System.Collections.Generic;
    using System.Reflection;

    /// <summary>
    /// SubmissionHost 程序的入口点容器。
    /// </summary>
    public static class Program
    {
        private static Logger Log;

        static Program()
        {
            // 初始化日志对象。
            Log = LogManager.GetCurrentClassLogger();
        }

        /// <summary>
        /// 应用程序入口点。
        /// </summary>
        /// <param name="args">命令行选项。</param>
        public static int Main(string[] args)
        {
            // Usage: subhst -k <VerdictKey>

            // 检查判题器连接密钥设置。
            ArgHandlerDispatcher dispatcher = new ArgHandlerDispatcher();
            dispatcher.LoadArgHandlers(Assembly.GetExecutingAssembly());
            Dictionary<string, object> argSettings = ArgResolver.Resolve(dispatcher);

            if (argSettings == null)
            {
                Log.Error("在解析命令行选项的过程中发生了错误。请检查输入的命令行选项。");
                return -1;
            }
            if (!argSettings.ContainsKey("key"))
            {
                Log.Error("未设置判题器连接密钥。");
                return -1;
            }

            byte[] verdictKey = (byte[])argSettings["key"];
            // TO IMPLEMENT HERE.
            
            return 0;
        }
    }
}
