using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DES
{
    /// <summary>
    /// S盒类
    /// </summary>
    class SubstitutionBox
    {
        /// <summary>
        /// S盒矩阵
        /// </summary>
        private readonly int[,] data;
        /// <summary>
        /// S盒的构造函数
        /// </summary>
        /// <param name="substitution">输入的矩阵</param>
        public SubstitutionBox(int[,] substitution)
        {
            data = substitution.Clone() as int[,];
        }
        /// <summary>
        /// 另一个构造函数
        /// </summary>
        /// <param name="substitution">以数组形式输入的S盒矩阵</param>
        /// <param name="rowCount">矩阵的行数</param>
        public SubstitutionBox(int[] substitution,int rowCount)
        {
            if (substitution.Length % rowCount != 0)
                throw new ArgumentException("无法整除行数");
            data = new int[rowCount, substitution.Length / rowCount];
            int p = 0;
            for (int i = 0; i < rowCount; ++i)
            {
                for (int j = 0; j < substitution.Length / rowCount; ++j)
                {
                    data[i, j] = substitution[p++];
                }
            }
        }
        /// <summary>
        /// S盒变换的主函数
        /// </summary>
        /// <param name="input">输入的01串</param>
        /// <returns>变换后的01串</returns>
        public Bitset Perform(Bitset input)
        {
            // 只考虑DES的S盒实现
            if(data.GetLength(0)==4&&data.GetLength(1)==16&&input.Length==6)
            {
                // 结果一定为4位
                Bitset result = new Bitset(4);
                // 中间4个Bit拿来作为n
                int n = input.Substring(1, 4).ToIntegerValue();
                // 前后两个Bit拿来作为l
                int l = input.SelectIndex(new int[] { 0, 5 }).ToIntegerValue();
                // 将矩阵第l行第n列作为输出，并且转化为01串
                int num = data[l, n];
                result.PasteInteger(num);
                return result;
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
