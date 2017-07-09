namespace BITOJ.SubmissionHost.Data
{
    /// <summary>
    /// 为 SubmissionRequestArrived 事件提供回调委托签名。
    /// </summary>
    /// <param name="sender">事件的触发者。</param>
    /// <param name="e">事件数据对象。</param>
    public delegate void SubmissionRequstArrivedEventHandler(object sender, SubmissionRequestArrivedEventArgs e);
}
