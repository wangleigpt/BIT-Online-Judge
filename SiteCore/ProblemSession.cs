namespace BITOJ.Core
{
    using BITOJ.Core.Data;
    using System;

    /// <summary>
    /// 封装题目的信息交互会话上下文信息。
    /// </summary>
    public class ProblemSession : IDisposable
    {
        private ProblemHandle m_handle;
        private IProblemDataProvider m_problemData;
        private bool m_disposed;

        /// <summary>
        /// 使用指定的题目句柄初始化 ProblemSession 类的新实例。
        /// </summary>
        /// <param name="handle">题目句柄对象。</param>
        /// <param name="desiredAccess">创建的 ProblemSession 对象具有的访问权限。</param>
        public ProblemSession(ProblemHandle handle, ProblemDataAccess desiredAccess)
        {
            m_handle = handle;
            m_problemData = ProblemDataProviderFactory.CreateDataProvider(handle, 
                desiredAccess == ProblemDataAccess.ReadOnly);
            m_disposed = false;
        }

        ~ProblemSession()
        {
            Dispose();
        }

        /// <summary>
        /// 获取当前题目会话的题目句柄。
        /// </summary>
        /// <exception cref="ObjectDisposedException"/>
        public ProblemHandle Handle
        {
            get
            {
                if (m_disposed)
                    throw new ObjectDisposedException(GetType().Name);

                return m_handle;
            }
        }

        /// <summary>
        /// 获取当前题目会话的数据源提供对象。
        /// </summary>
        /// <exception cref="ObjectDisposedException"/>
        public IProblemDataProvider ProblemData
        {
            get
            {
                if (m_disposed)
                    throw new ObjectDisposedException(GetType().Name);

                return m_problemData;
            }
        }

        /// <summary>
        /// 关闭当前题目会话并释放由当前对象占有的所有资源。
        /// </summary>
        public void Dispose()
        {
            if (!m_disposed)
            {
                m_problemData.Dispose();
                m_disposed = true;
            }
        }
    }
}
