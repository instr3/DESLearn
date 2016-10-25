using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace DES
{
    class DESStream
    {
        public DESAlgorithm DES;
        BinaryReader reader;
        BinaryWriter writer;
        Bitset key;
        Bitset lastAnswer;
        public Bitset IV { get; private set; }
        /// <summary>
        /// 构造新的DES流
        /// </summary>
        /// <param name="inputReader">待加密/解密输入流</param>
        /// <param name="inputKey">密钥</param>
        /// <param name="inputWriter">结果输出流</param>
        /// <param name="inputIV">初始向量，解密时不需要提供</param>
        public DESStream(BinaryReader inputReader,Bitset inputKey,BinaryWriter inputWriter,Bitset inputIV=null)
        {
            reader = inputReader;
            writer = inputWriter;
            key = inputKey;
            DES = new DESAlgorithm();
            if(inputIV!=null)
                IV = inputIV;
            else
                IV = new Bitset(64);
        }
        public int EncryptBlock()
        {
            byte[] readByte = reader.ReadBytes(8);
            byte[] newByte;
            if (readByte.Length != 8)
            {
                newByte = new byte[8];
                for (int i = 0; i < readByte.Length; ++i)
                {
                    newByte[i] = readByte[i];
                }
                newByte[7] = (byte)((7 - readByte.Length) * 8);
            }
            else
                newByte = readByte;
            Bitset processData = new Bitset(newByte);
            lastAnswer = DES.Encrypt(processData.Xor(lastAnswer), key);
            byte[] writeByte = lastAnswer.ToByteArray();
            writer.Write(writeByte);
            return readByte.Length;
        }
        byte[] lastBytesToOutput;
        public int DecryptBlock(byte[] readByte)
        {
            if (readByte.Length != 8)
            {
                MessageBox.Show("不合法的密文：长度不为64bit的倍数");
                return 0;
            }
            Bitset processData = new Bitset(readByte);
            byte[] writeByte = DES.Decrypt(processData, key).Xor(lastAnswer).ToByteArray();
            lastAnswer = processData;
            lastBytesToOutput = writeByte;
            return readByte.Length;
        }

        public bool Encrypt()
        {
            long totLength = reader.BaseStream.Length, currentLength = 0;
            // 先输出加密后的IV，以供解密
            writer.Write(DES.Encrypt(IV, key).ToByteArray());
            lastAnswer = IV;
            long roundCount = 0;
            while (EncryptBlock() == 8)
            {
                currentLength += 8;
                roundCount++;
                if(roundCount%100==0)
                {
                    Program.Form.progressBar.Value = (int)(currentLength * 100.0 / totLength);
                    Application.DoEvents();
                }
            }
            Program.Form.progressBar.Value = 100;
            return true;
        }
        public bool Decrypt()
        {
            long totLength = reader.BaseStream.Length, currentLength = 0;
            IV = DES.Decrypt(new Bitset(reader.ReadBytes(8)), key);
            lastAnswer = IV;
            byte[] readByte = reader.ReadBytes(8);
            if (readByte.Length == 0)
            {
                MessageBox.Show("不合法的密文：密文是空文件");
                return false;
            }
            long roundCount=0;
            while (true)
            {
                if (DecryptBlock(readByte) != 8) return false;
                readByte = reader.ReadBytes(8);
                if (readByte.Length == 0) break; // 已处理到文件末尾
                writer.Write(lastBytesToOutput);
                currentLength += 8;
                roundCount++;
                if (roundCount % 100 == 0)
                {
                    Program.Form.progressBar.Value = (int)(currentLength * 100.0 / totLength);
                    Application.DoEvents();
                }
            }

            // 处理最后一块，去除明文后的填充字符
            byte eraseBitCount = lastBytesToOutput[7];
            int writeByteCount = 7 - lastBytesToOutput[7] / 8;
            for (int i = 0; i < writeByteCount; ++i)
                writer.Write(lastBytesToOutput[i]);
            Program.Form.progressBar.Value = 100;
            return true;
        }
    }
}
