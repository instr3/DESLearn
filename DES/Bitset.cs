using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DES
{
    /// <summary>
    /// 用简单算法实现的一个二进制串处理类
    /// </summary>
    class Bitset : ICloneable
    {
        private bool[] data;
        /// <summary>
        /// 获取二进制串长度
        /// </summary>
        public int Length
        {
            get { return data.Length; }
        }
        /// <summary>
        /// 下标访问
        /// </summary>
        /// <param name="i">输入下标</param>
        /// <returns>输出对应下标的01位</returns>
        public bool this[int i]
        {
            get { return data[i]; }
            set { data[i] = value; }
        }
        /// <summary>
        /// 构造n位空OldBitset
        /// </summary>
        /// <param name="n">初始长度</param>
        public Bitset(int n)
        {
            data = new bool[n];
        }
        /// <summary>
        /// 复制构造函数
        /// </summary>
        /// <param name="rhs">待复制OldBitset</param>
        public Bitset(Bitset rhs)
        {
            data = rhs.data.Clone() as bool[];
        }
        /// <summary>
        /// 字符串构造函数
        /// </summary>
        /// <param name="str">由字符串构造OldBitset</param>
        public Bitset(string str)
        {
            data = str.Replace(" ", "").Select(ch => ch != '0').ToArray();
        }
        public Bitset(byte[] byteArr)
        {
            data = new bool[byteArr.Length * 8];
            for (int i = 0; i < byteArr.Length; ++i)
            {
                for (int j = 0; j < 8; ++j)
                {
                    data[j + i * 8] = (byteArr[i] & 1 << (7 - j)) != 0;
                }
            }
        }
        /// <summary>
        /// 将某位置为1
        /// </summary>
        /// <param name="i">修改位</param>
        public void Set(int i)
        {
            data[i] = true;
        }
        /// <summary>
        /// 将某位置为0
        /// </summary>
        /// <param name="i">修改位</param>
        public void Reset(int i)
        {
            data[i] = false;
        }
        /// <summary>
        /// 执行二进制串或操作
        /// </summary>
        /// <param name="rhs">操作数</param>
        /// <returns>操作结果</returns>
        public Bitset Or(Bitset rhs)
        {
            if (data.Length != rhs.data.Length)
            {
                throw new ArgumentException("OldBitset长度不相等");
            }
            Bitset result = new Bitset(data.Length);
            for (int i = 0; i < data.Length; ++i)
            {
                result.data[i] = data[i] || rhs.data[i];
            }
            return result;
        }
        /// <summary>
        /// 执行二进制串非操作
        /// </summary>
        /// <returns>操作结果</returns>
        public Bitset Not()
        {
            Bitset result = new Bitset(data.Length);
            for (int i = 0; i < data.Length; ++i)
            {
                result.data[i] = !data[i];
            }
            return result;
        }
        /// <summary>
        /// 执行二进制串与操作
        /// </summary>
        /// <param name="rhs">操作数</param>
        /// <returns>操作结果</returns>
        public Bitset And(Bitset rhs)
        {
            if (data.Length != rhs.data.Length)
            {
                throw new ArgumentException("OldBitset长度不相等");
            }
            Bitset result = new Bitset(data.Length);
            for (int i = 0; i < data.Length; ++i)
            {
                result.data[i] = data[i] && rhs.data[i];
            }
            return result;
        }
        /// <summary>
        /// 执行二进制串异或操作
        /// </summary>
        /// <param name="rhs">操作数</param>
        /// <returns>操作结果</returns>
        public Bitset Xor(Bitset rhs)
        {
            if (data.Length != rhs.data.Length)
            {
                throw new ArgumentException("OldBitset长度不相等");
            }
            Bitset result = new Bitset(data.Length);
            for (int i = 0; i < data.Length; ++i)
            {
                result.data[i] = data[i] != rhs.data[i];
            }
            return result;
        }
        /// <summary>
        /// 执行二进制串循环右移操作
        /// </summary>
        /// <param name="rhs">操作数</param>
        /// <returns>操作结果</returns>
        public Bitset ShiftRight(int rhs)
        {
            Bitset result = new Bitset(data.Length);
            for (int i = 0; i < rhs; ++i)
                result.data[i] = data[i - rhs + data.Length];
            for (int i = rhs; i < data.Length; ++i)
                result.data[i] = data[i - rhs];
            return result;
        }
        /// <summary>
        /// 执行二进制串循环左移操作
        /// </summary>
        /// <param name="rhs">操作数</param>
        /// <returns>操作结果</returns>
        public Bitset ShiftLeft(int rhs)
        {
            Bitset result = new Bitset(data.Length);
            for (int i = 0; i < data.Length - rhs; ++i)
                result.data[i] = data[i + rhs];
            for (int i = data.Length - rhs; i < data.Length; ++i)
                result.data[i] = data[i + rhs - data.Length];
            return result;
        }
        /// <summary>
        /// 执行二进制串循环右移一次
        /// </summary>
        /// <returns>操作结果</returns>
        public Bitset ShiftRight() { return ShiftRight(1); }
        /// <summary>
        /// 执行二进制串循环左移一次
        /// </summary>
        /// <returns>操作结果</returns>
        public Bitset ShiftLeft() { return ShiftLeft(1); }
        /// <summary>
        /// 用数组下标选取OldBitset中某些位，组成新OldBitset返回
        /// </summary>
        /// <param name="indexes">选取数组</param>
        /// <returns>操作结果</returns>
        public Bitset SelectIndex(int[] indexes)
        {
            if (indexes == null) return new Bitset(0);
            Bitset result = new Bitset(indexes.Length);
            for (int i = 0; i < result.data.Length; ++i)
            {
                result.data[i] = data[indexes[i]];
            }
            return result;
        }
        /// <summary>
        /// 用区间选取OldBitset中的某些位，组成新OldBitset返回
        /// </summary>
        /// <param name="start">区间起始位置</param>
        /// <param name="length">区间长度</param>
        /// <returns>操作结果</returns>
        public Bitset Substring(int start, int length)
        {
            if (length < 0 || start + length > data.Length)
            {
                throw new ArgumentException("参数越界");
            }

            Bitset result = new Bitset(length);
            for (int i = 0; i < length; ++i)
            {
                result.data[i] = data[i + start];
            }
            return result;
        }
        /// <summary>
        /// 用从左端点开始的区间选取OldBitset中的某几位，组成新OldBitset返回
        /// </summary>
        /// <param name="length">区间长度</param>
        /// <returns>操作结果</returns>
        public Bitset Left(int length)
        {
            return Substring(0, length);
        }
        /// <summary>
        /// 用从右端点开始的区间选取OldBitset中的某几位，组成新OldBitset返回
        /// </summary>
        /// <param name="length">区间长度</param>
        /// <returns>操作结果</returns>
        public Bitset Right(int length)
        {
            return Substring(data.Length - length, length);
        }
        /// <summary>
        /// 返回OldBitset的左半部分，如果OldBitset长度不为2的倍数则抛出异常
        /// </summary>
        /// <returns>操作结果</returns>
        public Bitset LeftHalf()
        {
            if (data.Length % 2 != 0) throw new ArgumentException("原长不为偶数");
            return Left(data.Length / 2);
        }
        /// <summary>
        /// 返回OldBitset的右半部分，如果OldBitset长度不为2的倍数则抛出异常
        /// </summary>
        /// <returns>操作结果</returns>
        public Bitset RightHalf()
        {
            if (data.Length % 2 != 0) throw new ArgumentException("原长不为偶数");
            return Right(data.Length / 2);
        }
        /// <summary>
        /// 将OldBitset转化为长整型输出
        /// </summary>
        /// <returns>转化后结果</returns>
        public long ToLongValue()
        {
            long result = 0;
            for (int i = 0; i < data.Length; ++i)
            {
                result = result * 2 + (data[i] ? 1 : 0);
            }
            return result;
        }
        /// <summary>
        /// 将OldBitset转化为整型输出
        /// </summary>
        /// <returns>转化后结果</returns>
        public int ToIntegerValue()
        {
            int result = 0;
            for (int i = 0; i < data.Length; ++i)
            {
                result = result * 2 + (data[i] ? 1 : 0);
            }
            return result;
        }
        /// <summary>
        /// 从整型构造OldBitset数据
        /// </summary>
        /// <param name="input">输入的整型</param>
        public void PasteInteger(int input)
        {
            for (int i = data.Length - 1; i >= 0; --i)
            {
                data[i] = input % 2 == 1;
                input /= 2;
            }
        }
        /// <summary>
        /// 将两段OldBitset中的01串进行拼接并返回新构造的OldBitset
        /// </summary>
        /// <param name="lhs">操作数1</param>
        /// <param name="rhs">操作数2</param>
        /// <returns>拼接后组成的OldBitset</returns>
        public static Bitset Join(Bitset lhs, Bitset rhs)
        {
            Bitset result = new Bitset(lhs.data.Length + rhs.data.Length);
            for (int i = 0; i < lhs.data.Length; ++i)
                result.data[i] = lhs.data[i];
            for (int i = 0; i < rhs.data.Length; ++i)
                result.data[i + lhs.data.Length] = rhs.data[i];
            return result;
        }
        /// <summary>
        /// 将若干OldBitset中的01串依次拼接并返回构造的新OldBitset
        /// </summary>
        /// <param name="bitsets">操作数组</param>
        /// <returns>拼接后的OldBitset</returns>
        public static Bitset Join(params Bitset[] bitsets)
        {
            Bitset result = new Bitset(bitsets.Select(b => b.Length).Sum());
            int i = 0;
            foreach (Bitset bs in bitsets)
                foreach (bool b in bs.data)
                    result.data[i++] = b;
            return result;
        }
        /// <summary>
        /// 将给定OldBitset的01串按定长分割成子OldBitset，如果不能恰好分割成整数段则抛出异常
        /// </summary>
        /// <param name="length">分割长度</param>
        /// <returns>分割后的子OldBitset数组</returns>
        public Bitset[] SplitByLength(int length)
        {
            if (data.Length % length != 0)
            {
                throw new ArgumentException("不能整除拆分长度");
            }
            Bitset[] results = new Bitset[data.Length / length];
            int p = 0;
            for (int i = 0; i < results.Length; ++i)
            {
                results[i] = new Bitset(length);
                for (int j = 0; j < length; ++j)
                {
                    results[i].data[j] = data[p++];
                }
            }
            return results;
        }
        /// <summary>
        /// 实现IClonable的接口函数
        /// </summary>
        /// <returns>克隆后物体</returns>
        public object Clone()
        {
            return MemberwiseClone();
        }
        /// <summary>
        /// 重载object的ToString函数
        /// </summary>
        /// <returns>输出字符串</returns>
        public override string ToString()
        {
            return new string(data.Select(b => b ? '1' : '0').ToArray());

        }
        /// <summary>
        /// 转化为byte数组
        /// </summary>
        /// <returns>转化后结果</returns>
        public byte[] ToByteArray()
        {
            if (data.Length % 8 != 0)
            {
                throw new NotSupportedException("数据长度不为8的倍数");
            }
            byte[] result = new byte[data.Length / 8];
            for (int i = 0; i < result.Length; ++i)
            {
                for (int j = 0; j < 8; ++j)
                {
                    if (data[i * 8 + j])
                        result[i] |= (byte)(1 << 7 - j);
                }
            }
            return result;
        }
        public static Bitset RandomGenerate(int n)
        {
            Bitset result = new Bitset(n);
            Random random = new Random();
            for (int i=0;i<n;++i)
            {
                result.data[i] = random.Next() % 2 != 0;
            }
            return result;
        }
    }
}
