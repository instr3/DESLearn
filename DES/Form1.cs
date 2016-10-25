using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DES
{
    partial class Form1 : Form
    {
        public DESAlgorithm DES = new DESAlgorithm();
        public bool busy;
        public Bitset Key, IV;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitset key = new Bitset("00010011 00110100 01010111 01111001 10011011 10111100 11011111 11110001");
            DES.GenerateSubKeys(key);
            for (int i = 0; i < 6; ++i)
            {
                Logger.Text += DES.subKeys[i].ToString() + Environment.NewLine;
            }
            Logger.Text += Environment.NewLine;
            //Bitset input = new Bitset("0000 0001 0010 0011 0100 0101 0110 0111 1000 1001 1010 1011 1100 1101 1110 1111");
            Bitset input = new Bitset(new byte[] { 0, 1, 2, 3, 4, 5, 6, 7 });
            Logger.Text += input.ToString() + Environment.NewLine;
            Bitset result = DES.Encrypt(input, key);
            Logger.Text += result.ToString();
            //MessageBox.Show(DES.Encrypt(input, key).ToString());
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (busy)
                return;
            if (keyFileDialog.ShowDialog() == DialogResult.OK)
            {
                Bitset newKey = LoadKey(keyFileDialog.FileName);
                if (newKey != null)
                {
                    Key = newKey;
                    textBoxKey.Text = Key.ToString();
                }
            }
        }

        private Bitset LoadKey(string fileName)
        {
            using (BinaryReader br = new BinaryReader(new FileStream(fileName, FileMode.Open, FileAccess.Read)))
            {
                byte[] keyBytes = br.ReadBytes(9);
                if (keyBytes.Length != 8)
                {
                    MessageBox.Show("密钥长度不为8字节（64Bit），请核验！");
                    return null;
                }
                Log("使用密钥文件：" + fileName);
                return new Bitset(keyBytes);

            }
        }

        private void encryptButton_Click(object sender, EventArgs e)
        {
            EncryptDecryptUserGuide(false);
        }

        private void DecryptButton_Click(object sender, EventArgs e)
        {
            EncryptDecryptUserGuide(true);
        }

        private void EncryptDecryptUserGuide(bool isDecrypt)
        {
            if (busy)
                return;
            string sourceType = isDecrypt ? "密文" : "明文";
            string targetType = isDecrypt ? "明文" : "密文";
            string operationType = isDecrypt ? "解密" : "加密";
            try
            {
                MessageBox.Show("请选择" + sourceType + "文本。");
                if (encryptFileDialog.ShowDialog() != DialogResult.OK)
                    return;
                textBoxInputFile.Text = encryptFileDialog.FileName;
                MessageBox.Show("请选择" + targetType + "存储位置。");
                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    return;
                textBoxOutputFile.Text = saveFileDialog.FileName;
                if (Key == null)
                {
                    MessageBox.Show("密钥尚未加载，请选择密钥。");
                    button2_Click(null, null);
                    if (Key == null)
                        return;
                }
                using (BinaryReader br = new BinaryReader(new FileStream(encryptFileDialog.FileName, FileMode.Open, FileAccess.Read)))
                {
                    using (BinaryWriter bw = new BinaryWriter(new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write)))
                    {
                        DESStream encryptStream = new DESStream(br, Key, bw, IV);
                        busy = true;
                        if (isDecrypt)
                        {
                            Log("开始解密");
                            encryptStream.Decrypt();
                            IV = encryptStream.IV;
                            IVText.Text = IV.ToString();
                            Log("解密结束");
                        }
                        else
                        {
                            Log("开始加密");
                            if (IV==null)
                            {
                                RandomIVButton_Click(null,null);
                            }
                            encryptStream.Encrypt();
                            Log("加密结束");
                        }
                        busy = false;
                    }
                }
                MessageBox.Show(operationType + "成功。");

            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("错误：文件未找到");
                MessageBox.Show(operationType + "失败。");
            }
            catch (IOException)
            {
                MessageBox.Show("错误：文件读写发生错误");
                MessageBox.Show(operationType + "失败。");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            MaximizeBox = false;
            Log("程序启动");
            Log("此程序为DES演示程序，使用朴素方法编写算法，可扩展性强但未进行优化，加解密大文件（超过5MB）可能较慢");
        }
        public void Log(string text)
        {
            Logger.Text += string.Format("[{0:HH}:{0:mm}:{0:ss}.{0:fff}]", DateTime.Now) + text + Environment.NewLine;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("信息安全原理课程项目\n作者：14计算机 姜峻岩\n学号：14307130166\n第三方库：未使用");
        }

        private void RandomIVButton_Click(object sender, EventArgs e)
        {
            Log("生成随机初始向量：IV(64 bit)");
            IV = Bitset.RandomGenerate(64);
            IVText.Text = IV.ToString();
        }
    }
}
