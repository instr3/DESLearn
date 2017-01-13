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
    /// RSA生成类
    /// </summary>
    public class RSA
    {
        // 私钥
        private BigInteger p, q;
        private BigInteger d;
        // 公钥
        public RSAPublicKey publicKey;

        public int ByteCount;
        /// <summary>
        /// 生成新密钥、公钥对
        /// </summary>
        /// <param name="bytes">RSA算法的字节数（bit数除以8）</param>
        public RSA(int bytes)
        {
            ByteCount = bytes;
            BigInteger phi;
            BigInteger e = 65537;
            BigInteger n;
            do
            {
                p = Mathbase.GeneratePrime(bytes/2);
                q = Mathbase.GeneratePrime(bytes/2);
                n = p * q;
                phi = (p - 1) * (q - 1);
            } while (phi <= e || BigInteger.GreatestCommonDivisor(e, phi) != 1);

            d = Mathbase.GetInverse(e, phi);
            publicKey = new RSAPublicKey(e, n, ByteCount);
        }
        /// <summary>
        /// 转字符串，打印RSA信息
        /// </summary>
        /// <returns>字符串</returns>
        public override string ToString()
        {
            return string.Join(Environment.NewLine,new string[] {
                ("[RSA" + (ByteCount * 8) + "]"),
                ("----PUBLIC KEY----"),
                ("e=" + publicKey.e),
                ("n=" + publicKey.n),
                ("----PRIVATE KEY----"),
                ("p=" + p),
                ("q=" + q),
                ("d=" + d) });
        }

        /// <summary>
        /// 加密操作
        /// </summary>
        /// <param name="m">明文</param>
        /// <returns>密文</returns>
        public BigInteger EncryptBlock(BigInteger m)
        {
            if (m >= publicKey.n || m < 0) throw new ArgumentException("内容越界");
            return BigInteger.ModPow(m, publicKey.e, publicKey.n);
        }
        /// <summary>
        /// 解密操作
        /// </summary>
        /// <param name="c">密文</param>
        /// <returns>明文</returns>
        public BigInteger DecryptBlock(BigInteger c)
        {
            if (c >= publicKey.n || c < 0) throw new ArgumentException("内容越界");
            // 普通解密算法
            // return BigInteger.ModPow(c, d, publicKey.n);
            // 快速解密算法
            BigInteger c1 = c % p, c2 = c % q;
            BigInteger d1 = d % (p-1), d2 = d % (q-1);
            BigInteger m1 = BigInteger.ModPow(c1, d1, p);
            BigInteger m2 = BigInteger.ModPow(c2, d2, q);
            return Mathbase.CRT(m1, p, m2, q);
        }
    }
}
