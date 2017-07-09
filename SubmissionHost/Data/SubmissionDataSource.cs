namespace BITOJ.SubmissionHost.Data
{
    using BITOJ.Core.Data;
    using System;

    /// <summary>
    /// 为用户提交数据源提供抽象基类。
    /// </summary>
    public abstract class SubmissionDataSource : IDisposable
    {
        /// <summary>
        /// 初始化 SubmissionDataSource 类的新实例。
        /// </summary>
        protected SubmissionDataSource()
        {
        }

        ~SubmissionDataSource()
        {
            Dispose();
        }

        /// <summary>
        /// 触发 SubmissionRequestArrivedEventArgs 事件。
        /// </summary>
        /// <param name="e">事件数据对象。</param>
        protected void OnSubmissionRequestArrived(SubmissionRequestArrivedEventArgs e)
        {
            SubmissionRequestArrived?.Invoke(this, e);
        }

        /// <summary>
        /// 当客户端传来新的用户提交时触发。
        /// </summary>
        public event SubmissionRequstArrivedEventHandler SubmissionRequestArrived;

        /// <summary>
        /// 在派生类中重写时，将一个用户提交的状态数据回送给数据源。
        /// </summary>
        /// <param name="submission">要回送的用户提交状态对象。</param>
        public abstract void SendSubmissionStatesToSource(SubmissionHandle submission);

        /// <summary>
        /// 在派生类中重写时，释放当前对象占用的所有资源。
        /// </summary>
        public virtual void Dispose()
        {
        }
    }
}
