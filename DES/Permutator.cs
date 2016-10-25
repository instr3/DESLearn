using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DES
{
    /// <summary>
    /// 坐标置换盒的类
    /// </summary>
    class Permutator
    {
        /// <summary>
        /// 置换数组
        /// </summary>
        private readonly int[] data;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="permutation">输入的置换数组</param>
        public Permutator(int[] permutation)
        {
            data = permutation.Clone() as int[];
        }
        /// <summary>
        /// 置换主函数
        /// </summary>
        /// <param name="input">输入的01串</param>
        /// <returns>输出的01串</returns>
        public Bitset Perform(Bitset input)
        {
            Bitset result = new Bitset(data.Length);
            // 简单地找出对应下标的元素的值，依次放在结果01串中
            for(int i=0;i< result.Length;++i)
            {
                result[i] = input[data[i]];
            }
            return result;
        }
        /// <summary>
        /// 获取逆置换
        /// </summary>
        /// <returns>逆置换</returns>
        public Permutator GetInversePermutator()
        {
            int[] result = new int[data.Length];
            // 简单的求一个反函数
            for(int i=0;i<data.Length;++i)
            {
                result[data[i]] = i;
            }
            return new Permutator(result);
        }
    }
}
