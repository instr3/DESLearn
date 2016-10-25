using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DES
{
    /// <summary>
    /// 用于计算轮函数的类。在DES中只有一个实例
    /// </summary>
    class DESRoundFunction
    {
        /// <summary>
        /// S盒
        /// </summary>
        readonly SubstitutionBox[] S;
        /// <summary>
        /// E矩阵与P盒
        /// </summary>
        readonly Permutator EMatrix, PBox;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="roundS">输入的S盒</param>
        /// <param name="roundE">输入的E矩阵</param>
        /// <param name="roundP">输入的P盒</param>
        public DESRoundFunction(SubstitutionBox[] roundS, Permutator roundE, Permutator roundP)
        {
            S = roundS;
            EMatrix = roundE;
            PBox = roundP;
        }
        /// <summary>
        /// 轮函数的主处理函数
        /// </summary>
        /// <param name="input">输入的64比特（包括Li-1与Ri-1）</param>
        /// <param name="key">输入的子密钥</param>
        /// <returns>输出的64比特（包括Li与Ri）</returns>
        public Bitset Process(Bitset input,Bitset key)
        {
            //判断输入是否合法
            if(input.Length!=64||key.Length!=48)
            {
                throw new ArgumentException("输入不合法");
            }

            // 拆成两个32比特，Ri不动，Li进行处理
            Bitset left = input.LeftHalf();
            Bitset right = input.RightHalf();

            // 计算轮函数f值，先R进行E矩阵置换，从32比特变为48比特：
            Bitset f = EMatrix.Perform(right);

            // 然后将f值与密钥相异或
            f = f.Xor(key);

            // 将值拆成8个6bit串，输入S盒
            Bitset[] groups = f.SplitByLength(6);
            for(int i=0;i<8;++i)
            {
                // 进行S盒变换
                groups[i] = S[i].Perform(groups[i]);
            }
            // 将f和成一个01串
            f = Bitset.Join(groups);

            // 再经过P盒坐标置换
            f = PBox.Perform(f);

            // 与L_(i-1)异或
            f = f.Xor(left);

            //输出结果，注意没有经过左右交换SW
            return Bitset.Join(f, right);
        }
    }
}
