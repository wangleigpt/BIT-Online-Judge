namespace BITOJ.SubmissionHost.Security.Cryptography
{
    /// <summary>
    /// 为密钥转换算法实现提供接口。
    /// </summary>
    public interface IKeyTransformAlgorithm
    {
        /// <summary>
        /// 将原始密钥转换为加密密钥。
        /// </summary>
        /// <param name="originalKey">待转换的原始密钥。</param>
        /// <returns>转换后的加密密钥。</returns>
        byte[] Transform(byte[] originalKey);
    }
}
