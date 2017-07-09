namespace BITOJ.SubmissionHost.Data
{
    using BITOJ.Core.Data;
    using System;
    
    /// <summary>
    /// 为 SubmissionRequestArrived 事件提供数据。
    /// </summary>
    public sealed class SubmissionRequestArrivedEventArgs : EventArgs
    {
        /// <summary>
        /// 获取最新请求的用户提交数据对象。
        /// </summary>
        public SubmissionHandle Submission { get; private set; }

        /// <summary>
        /// 初始化 SubmissionRequestArrivedEventArgs 类的新实例。
        /// </summary>
        /// <param name="submission">最新请求的用户提交数据对象。</param>
        public SubmissionRequestArrivedEventArgs(SubmissionHandle submission) : base()
        {
            Submission = submission;
        }
    }
}
