using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RSA
{
    [Serializable]
    /// <summary>
    /// RSA公钥类
    /// </summary>
    public class RSAPublicKey
    {
        public BigInteger e;
        public BigInteger n;
        public int ByteCount;
        /// <summary>
        /// RSA公钥初始化函数
        /// </summary>
        /// <param name="inputE">RSA中的公钥e</param>
        /// <param name="inputN">RSA中的公钥n</param>
        /// <param name="inputByteCount">RSA的字节数（bit数/8）</param>
        public RSAPublicKey(BigInteger inputE,BigInteger inputN,int inputByteCount)
        {
            e = inputE;
            n = inputN;
            ByteCount = inputByteCount;
        }
        /// <summary>
        /// 用公钥加密
        /// </summary>
        /// <param name="m">明文</param>
        /// <returns>密文</returns>
        public BigInteger EncryptBlock(BigInteger m)
        {
            if (m >= n || m < 0) throw new ArgumentException("内容越界");
            return BigInteger.ModPow(m, e, n);
        }
        /// <summary>
        /// 打印公钥信息
        /// </summary>
        /// <returns>转化后的字符串</returns>
        public override string ToString()
        {
            return string.Join(Environment.NewLine, new string[] {
                ("[RSA" + (ByteCount * 8) + "]"),
                ("----PUBLIC KEY----"),
                ("e=" + e),
                ("n=" + n)});
        }
    }
}
