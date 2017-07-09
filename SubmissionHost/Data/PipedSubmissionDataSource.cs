namespace BITOJ.SubmissionHost.Data
{
    using BITOJ.Core.Data;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.IO.Pipes;
    using System.Text;
    using System.Threading;

    /// <summary>
    /// 使用底层管道服务作为基础通信媒介的 SubmissionDataSource 实现。
    /// </summary>
    public sealed class PipedSubmissionDataSource : SubmissionDataSource
    {
        private static readonly Encoding DefaultEncoding = Encoding.UTF8;

        private string m_upstreamPipeName;          // 上行管道名称。
        private string m_downstreamPipeName;        // 下行管道名称。
        private Thread m_listenThread;
        private bool m_disposed;

        /// <summary>
        /// 初始化 PipedSubmissionDataSource 类的新实例。
        /// </summary>
        /// <param name="pipeName">底层管道名称。</param>
        /// <exception cref="ArgumentNullException"/>
        public PipedSubmissionDataSource(string upstreamPipeName, string downstreamPipeName) : base()
        {
            m_upstreamPipeName = upstreamPipeName;
            m_downstreamPipeName = downstreamPipeName;
            m_listenThread = null;
            m_disposed = false;
        }

        /// <summary>
        /// 监听线程入口点。
        /// </summary>
        private void ListenThreadEntry()
        {
            try
            {
                using (NamedPipeServerStream serverPipe = new NamedPipeServerStream(m_upstreamPipeName))
                {
                    serverPipe.WaitForConnection();
                    using (StreamReader reader = new StreamReader(serverPipe, DefaultEncoding))
                    {
                        string json = reader.ReadToEnd();

                        // 尝试将 JSON 解析为数据对象。
                        SubmissionHandle submission = null;
                        try
                        {
                            submission = JsonConvert.DeserializeObject<SubmissionHandle>(json);
                        }
                        catch
                        {
                        }

                        if (submission != null)
                        {
                            // 触发事件。
                            SubmissionRequestArrivedEventArgs e = new SubmissionRequestArrivedEventArgs(submission);
                            OnSubmissionRequestArrived(e);
                        }
                    }
                }
            }
            catch (ThreadAbortException)
            {
                // 线程被外部代码强制终止。
            }
        }

        /// <summary>
        /// 开始在新线程中监听从管道传来的用户提交请求事件。
        /// </summary>
        /// <exception cref="InvalidOperationException"/>
        /// <exception cref="ObjectDisposedException"/>
        public void StartListen()
        {
            if (m_listenThread != null)
                throw new InvalidOperationException("后台监听线程已经启动。");
            if (m_disposed)
                throw new ObjectDisposedException("PipedSubmissionDataSource");

            m_listenThread = new Thread(ListenThreadEntry);
            m_listenThread.Start();
        }

        /// <summary>
        /// 结束监听从管道传来的用户提交请求事件。
        /// </summary>
        /// <exception cref="InvalidOperationException"/>
        public void StopListen()
        {
            if (m_listenThread == null)
                throw new InvalidOperationException("后台监听线程尚未启动。");
            if (m_disposed)
                throw new ObjectDisposedException("PipedSubmissionDataSource");

            m_listenThread.Abort();
        }

        /// <summary>
        /// 将一个用户提交状态通过管道回送回数据源。
        /// </summary>
        /// <param name="submission">要回送的用户提交状态对象。</param>
        /// <exception cref="ArgumentNullException"/>
        public override void SendSubmissionStatesToSource(SubmissionHandle submission)
        {
            if (submission == null)
                throw new ArgumentNullException(nameof(submission));

            using (NamedPipeClientStream clientPipe = new NamedPipeClientStream(m_downstreamPipeName))
            {
                clientPipe.Connect();

                using (StreamWriter writer = new StreamWriter(clientPipe, DefaultEncoding))
                {
                    string json = JsonConvert.SerializeObject(submission);
                    writer.Write(json);
                    clientPipe.Flush();
                }
            }
        }

        /// <summary>
        /// 释放当前对象所占用的所有资源。
        /// </summary>
        public override void Dispose()
        {
            if (!m_disposed)
            {
                if (m_listenThread != null)
                {
                    StopListen();
                }
            
                m_disposed = true;
            }

            base.Dispose();
        }
    }
}
