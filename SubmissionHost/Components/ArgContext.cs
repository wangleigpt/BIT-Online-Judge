namespace BITOJ.SubmissionHost.Components
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 封装命令行选项处理上下文信息。
    /// </summary>
    public sealed class ArgContext
    {
        /// <summary>
        /// 获取当前应用程序的命令行选项。
        /// </summary>
        /// <returns>当前应用程序的命令行选项。</returns>
        public static string[] GetArgs()
        {
            return Environment.GetCommandLineArgs();
        }

        private int m_ptr;

        /// <summary>
        /// 初始化 ArgContext 类的新实例。
        /// </summary>
        public ArgContext()
        {
            Args = GetArgs();
            m_ptr = 0;
            Result = new Dictionary<string, object>();
        }

        /// <summary>
        /// 获取命令行选项。
        /// </summary>
        public string[] Args { get; private set; }

        /// <summary>
        /// 获取一个值，该值指示当前处理的项是否为最后一项。
        /// </summary>
        public bool Last
        {
            get { return m_ptr == Args.Length; }
        }

        /// <summary>
        /// 获取当前的解析结果。
        /// </summary>
        public Dictionary<string, object> Result { get; private set; }

        /// <summary>
        /// 获取下一个等待处理的命令行选项。
        /// </summary>
        public string Next
        {
            get
            {
                if (Last)
                {
                    return null;
                }
                else
                {
                    return Args[m_ptr];
                }
            }
        }

        /// <summary>
        /// 获得下一个命令行选项并递增索引指针。
        /// </summary>
        /// <returns>下一个命令行选项。若已经处理到最后一个命令行选项，返回 null 。</returns>
        public string FetchNext()
        {
            if (Last)
            {
                return null;
            }
            else
            {
                return Args[m_ptr++];
            }
        }

        /// <summary>
        /// 获取下一个命令行选项并递增索引指针，同时检查其是否为选项名。
        /// </summary>
        /// <returns>下一个命令行选项。若已经处理到最后一个命令行选项或获取到的选项不是一个合法的选项名，返回 null 。</returns>
        public string FetchOptionName()
        {
            string next = FetchNext();
            if (next == null)
            {
                return null;
            }

            if (next.Length ==  0 || next[0] != '-')
            {
                // 当前选项不是一个合法的选项名。
                --m_ptr;
                return null;
            }
            else
            {
                return next;
            }
        }

        /// <summary>
        /// 获取下一个命令行选项并递增索引指针，同时检查其是否为选项参数。
        /// </summary>
        /// <returns>下一个命令行选项。若已经处理到最后一个命令行选项或获取到的选项不是一个合法的选项参数，返回 null 。</returns>
        public string FetchOptionArg()
        {
            string next = FetchNext();
            if (next == null)
            {
                return null;
            }

            if (next.Length > 0 && next[0] == '-')
            {
                // 当前选项不是一个合法的参数。
                --m_ptr;
                return null;
            }
            else
            {
                return next;
            }
        }
    }
}
