namespace BITOJ.SubmissionHost.Security.Authorization
{
    using BITOJ.SubmissionHost.Security.Cryptography;
    using System;

    /// <summary>
    /// 封装一个会话密钥槽。
    /// </summary>
    public sealed class SessionKeySlot
    {
        private byte[] m_originalKey;                   // 原始密钥
        private IKeyTransformAlgorithm m_transform;     // 密钥转换算法。

        /// <summary>
        /// 初始化 SessionKeySlot 类的新实例。
        /// </summary>
        /// <param name="originalKey">原始密钥。</param>
        /// <param name="transform">密钥转换算法实现。</param>
        /// <exception cref="ArgumentNullException"/>
        public SessionKeySlot(byte[] originalKey, IKeyTransformAlgorithm transform)
        {
            m_originalKey = originalKey ?? throw new ArgumentNullException(nameof(originalKey));
            m_transform = transform;
        }

        /// <summary>
        /// 检查给定的密钥是否与当前密钥槽中的密钥匹配。
        /// </summary>
        /// <param name="key">要验证的密钥。</param>
        /// <returns>一个值，该值指示给定的密钥是否与当前密钥槽中的密钥匹配。</returns>
        /// <exception cref="ArgumentNullException"/>
        public bool Verify(byte[] key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            byte[] expected = m_transform.Transform(m_originalKey);
            
            // 检查两 byte[] 是否一致。
            if (key.Length != expected.Length)
            {
                return false;
            }
            for (int i = 0; i < key.Length; ++i)
            {
                if (key[i] != expected[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
