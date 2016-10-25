using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DES
{
    /// <summary>
    /// 运行DES加解密算法的主类
    /// </summary>
    class DESAlgorithm
    {
        /// <summary>
        /// 轮函数
        /// </summary>
        DESRoundFunction RoundFunction;
        /// <summary>
        /// 密钥的置换IP，数据的置换IP与IP^(-1)
        /// </summary>
        Permutator KeyIP, DataIP, DataIPRev, SubKeyPC;
        /// <summary>
        /// 左移位数
        /// </summary>
        int[] ShiftArray;
        /// <summary>
        /// 处理轮数
        /// </summary>
        int roundCount;
        /// <summary>
        /// 子密钥
        /// </summary>
        public Bitset[] subKeys { get; private set; }
        /// <summary>
        /// 构造函数
        /// </summary>
        public DESAlgorithm()
        {
            // 初始化轮函数
            RoundFunction = new DESRoundFunction(
                DESData.RawSBox.Select(array => new SubstitutionBox(array, 4)).ToArray(),
                new Permutator(DESData.EMatrix),
                new Permutator(DESData.PBox)
            );

            // 初始化各种置换函数
            KeyIP = new Permutator(DESData.InitialKeyPermutation);
            DataIP = new Permutator(DESData.InitialDataPermutation);
            SubKeyPC = new Permutator(DESData.SubKeyPC);
            DataIPRev = DataIP.GetInversePermutator();

            // 初始化左移位数
            ShiftArray = DESData.KeyShiftArray.Clone() as int[];
            roundCount = ShiftArray.Length;
        }
        /// <summary>
        /// 生成子密钥（工作密钥）过程
        /// </summary>
        /// <param name="processingKey">输入密钥</param>
        public void GenerateSubKeys(Bitset key)
        {
            subKeys = new Bitset[roundCount];
            // 初始置换，64->56比特
            Bitset processingKey = KeyIP.Perform(key);

            //拆成左右两半各28比特
            Bitset left = processingKey.LeftHalf();
            Bitset right = processingKey.RightHalf();

            // 循环roundCount次，生成子密钥（工作密钥）
            for (int i=0;i<roundCount;++i)
            {
                //循环左移
                left = left.ShiftLeft(ShiftArray[i]);
                right = right.ShiftLeft(ShiftArray[i]);

                //合并后用PC置换
                subKeys[i] = SubKeyPC.Perform(Bitset.Join(left, right));
            }
        }
        /// <summary>
        /// 加密解密过程主函数
        /// </summary>
        /// <param name="data">输入数据</param>
        /// <param name="key">输入密钥</param>
        /// <param name="isEncrypt">true为加密，false为解密</param>
        /// <returns>加密则输出密文，解密则输出明文</returns>
        private Bitset Process(Bitset data,Bitset key,bool isEncrypt)
        {
            // 先生成子密钥
            GenerateSubKeys(key);

            // 初始置换
            Bitset processingData = DataIP.Perform(data);

            // 循环roundCount次，每轮调用轮函数
            for(int i=0;i<roundCount;++i)
            {
                // 使用第i个subkey进行轮函数
                // 加密和解密的区别仅仅是使用子密钥的顺序不同
                processingData = RoundFunction.Process(processingData, 
                    subKeys[isEncrypt ? i : roundCount - i - 1]);
                //Console.WriteLine(i + " : " + processingData);

                // 如果不是最后一轮，进行左右置换SW
                if(i!=roundCount-1)
                {
                    Bitset left = processingData.LeftHalf();
                    Bitset right = processingData.RightHalf();
                    processingData = Bitset.Join(right, left);
                }
            }
            // 最后执行逆置换IP^(-1)
            processingData = DataIPRev.Perform(processingData);
            return processingData;
        }
        /// <summary>
        /// 加密方法
        /// </summary>
        /// <param name="data">明文</param>
        /// <param name="key">密钥</param>
        /// <returns>密文</returns>
        public Bitset Encrypt(Bitset data, Bitset key)
        {
            return Process(data, key, true);
        }
        /// <summary>
        /// 解密方法
        /// </summary>
        /// <param name="data">密文</param>
        /// <param name="key">密钥</param>
        /// <returns>明文</returns>
        public Bitset Decrypt(Bitset data, Bitset key)
        {
            return Process(data, key, false);
        }
    }
}