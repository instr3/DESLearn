using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RSA
{
    /// <summary>
    /// RSA所必要的一些数论函数的实现
    /// </summary>
    class Mathbase
    {
        static Random random = new Random((int)DateTime.Now.Ticks);
        /// <summary>
        /// 中国剩余定理，x=a1 mod m1, x=a2 mod m2，求解x
        /// </summary>
        /// <param name="a1">a1</param>
        /// <param name="m1">m1</param>
        /// <param name="a2">a2</param>
        /// <param name="m2">m2</param>
        /// <returns>所求结果x</returns>
        public static BigInteger CRT(BigInteger a1,BigInteger m1,BigInteger a2,BigInteger m2)
        {
            return (a1 * m2 * GetInverse(m2, m1) + a2 * m1 * GetInverse(m1, m2)) % (m1 * m2);
        }
        /// <summary>
        /// 扩展欧几里得，求解ax+by=gcd(a,b)中的x与y
        /// </summary>
        /// <param name="a">a</param>
        /// <param name="b">b</param>
        /// <param name="x">x</param>
        /// <param name="y">y</param>
        /// <returns>gcd(a,b)</returns>
        public static BigInteger ExtendGCD(BigInteger a,BigInteger b,out BigInteger x,out BigInteger y)
        {
            if(b==0)
            {
                x = 1;y = 0;return a;
            }
            BigInteger x0 = 1, y0 = 0, x1 = 0, y1 = 1, x2, y2;
            BigInteger r, p;
            p = BigInteger.DivRem(a, b, out r);
            while(r>0)
            {
                x2 = x0 - x1 * p;
                y2 = y0 - y1 * p;
                x0 = x1; x1 = x2; y0 = y1; y1 = y2;
                a = b;b = r; p = BigInteger.DivRem(a, b, out r);
            }
            x = x1;
            y = y1;
            return b;
        }
        /// <summary>
        /// 求解逆元ax%mod=1
        /// </summary>
        /// <param name="a">待求逆元数</param>
        /// <param name="mod">取模</param>
        /// <returns>逆元</returns>
        public static BigInteger GetInverse(BigInteger a,BigInteger mod)
        {
            BigInteger x, y;
            BigInteger gcd = ExtendGCD(a, mod, out x, out y);
            if(gcd!=1)
            {
                throw new Exception("GCD is not 1, cannot get inverse");
            }
            return x < 0 ? x + mod : x;
        }
        /// <summary>
        /// 返回区间[0,right]随机大整数
        /// </summary>
        /// <param name="right">右端点</param>
        /// <returns>随机大整数</returns>
        public static BigInteger RandomRange(BigInteger right)
        {
            byte[] bytes = new byte[right.ToByteArray().Length+2];
            BigInteger result;
            random.NextBytes(bytes);
            bytes[bytes.Length - 1] &= 0x7f;
            result = new BigInteger(bytes);
            return result % (right + 1);
        }
        /// <summary>
        /// 返回[left,right]内的随机数
        /// </summary>
        /// <param name="left">区间左端点</param>
        /// <param name="right">区间右端点</param>
        /// <returns>随机数</returns>
        public static BigInteger RandomRange(BigInteger left,BigInteger right)
        {
            return RandomRange(right - left) + left;
        }
        /// <summary>
        /// 返回不超过n字节的随机大整数
        /// </summary>
        /// <param name="n">字节数</param>
        /// <returns>随机数</returns>
        public static BigInteger RandomBits(int n)
        {
            byte[] bytes = new byte[n + 1];
            random.NextBytes(bytes);
            bytes[n] = 0;
            return new BigInteger(bytes);
        }
        /// <summary>
        /// 返回不超过n字节的随机质数
        /// </summary>
        /// <param name="bytes">字节数</param>
        /// <param name="confidence">置信程度（Miller-Rabin测试次数）</param>
        /// <returns>生成的质数</returns>
        public static BigInteger GeneratePrime(int bytes,int confidence=10)
        {
            BigInteger result;
            while(true)
            {
                result = RandomBits(bytes);
                if(result%2==0)
                {
                    result++;
                }
                if (result>3&&MillerRabin(result, confidence))
                    return result;
            }
        }
        /// <summary>
        /// Miller-Rabin素数测试法
        /// </summary>
        /// <param name="n">待测数</param>
        /// <param name="loopTimes">测试次数</param>
        /// <returns>返回true：很可能是质数；返回false：一定不是质数</returns>
        public static bool MillerRabin(BigInteger n,BigInteger loopTimes)
        {
            if (n < 0) throw new ArgumentException("参数为负");
            if (n <= 1) return false;
            if (n <= 3) return true;
            BigInteger m = n - 1;
            int k = 0;
            while (m % 2 == 0)
            {
                ++k;
                m /= 2;
            }
            for(int i=0;i< loopTimes;++i)
            {
                BigInteger a = RandomRange(2, n - 2);
                BigInteger b = BigInteger.ModPow(a, m, n);
                if (b == 1) continue;
                int j = 0;
                while(true)
                {
                    if (j == k) return false;
                    if (b == n - 1) break;
                    b = b * b % n;++j;
                }
            }
            return true;
        }
    }
}
