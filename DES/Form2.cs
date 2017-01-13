using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DES
{
    partial class Form2 : Form
    {
        public DESAlgorithm DES = new DESAlgorithm();
        public BigInteger EncryptedDESKey, RecEncryptedDESKey;
        public bool busy;
        public Bitset Key, IV, RecKey;
        public RSA.RSA ReceiverRSA;
        public RSA.RSAPublicKey ReceiverPublicKey;
        
        public Form2()
        {
            InitializeComponent();
        }
        public void Log(string text)
        {
            Logger.Text += string.Format("[{0:HH}:{0:mm}:{0:ss}.{0:fff}]", DateTime.Now) + text + Environment.NewLine;
        }
        void MessageHint(string text)
        {
            MessageBox.Show(text,"提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        void MessageError(string text)
        {
            MessageBox.Show(text,"错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private Bitset LoadKey(string fileName)
        {
            using (BinaryReader br = new BinaryReader(new FileStream(fileName, FileMode.Open, FileAccess.Read)))
            {
                byte[] keyBytes = br.ReadBytes(9);
                if (keyBytes.Length != 8)
                {
                    MessageError("密钥长度不为8字节（64Bit），请核验！");
                    return null;
                }
                Log("使用密钥文件：" + fileName);
                return new Bitset(keyBytes);

            }
        }
        private void LoadKeyButton_Click(object sender, EventArgs e)
        {
            if (busy)
                return;
            if (keyFileDialog.ShowDialog() == DialogResult.OK)
            {
                Bitset newKey = LoadKey(keyFileDialog.FileName);
                if (newKey != null)
                {
                    if (newKey.ToBigIntegerValue() == 0)
                    {
                        MessageBox.Show("0 不是一个合法的密钥。");
                        return;
                    }
                    Key = newKey;
                    textBoxKey.Text = Key.ToString();
                    textBoxRSAInput.Text = Key.ToBigIntegerValue().ToString();
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            buttonRecRSALoad_Click(null, e);
            buttonGetRSAPublic_Click(null, e);
            Log("程序启动");
        }

        private void buttonGetRSAPublic_Click(object sender, EventArgs e)
        {
            if (busy)
                return;
            try
            {
                using (FileStream fs = new FileStream(Program.RSA_PUBLIC_FILE_NAME, FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    ReceiverPublicKey = bf.Deserialize(fs) as RSA.RSAPublicKey;
                }
            }
            catch
            {
                if(sender!=null)
                    MessageError("公钥 " + Program.RSA_PUBLIC_FILE_NAME + " 读取失败，请让接收者重新生成RSA密钥对");
                ReceiverPublicKey = null;
                textBoxRSAPublicKey.Text = "接收者尚未提供公钥";
                return;
            }
            if (sender != null)
                MessageHint("公钥 " + Program.RSA_PUBLIC_FILE_NAME + " 读取成功");
            textBoxRSAPublicKey.Text = ReceiverPublicKey.ToString();
            return;
        }

        private void buttonRecRSANew_Click(object sender, EventArgs e)
        {
            if (busy) return;
            ReceiverRSA = new RSA.RSA(16);
            textBoxRecRSA.Text = ReceiverRSA.ToString();
            Log("已生成新RSA密钥对，记得要保存才能生效");

        }

        private void buttonRecRSALoad_Click(object sender, EventArgs e)
        {
            if (busy) return;
            try
            {
                using (FileStream fs = new FileStream(Program.RSA_PRIVATE_FILE_NAME, FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    ReceiverRSA = bf.Deserialize(fs) as RSA.RSA;
                }
            }
            catch
            {
                if (sender != null)
                    MessageError("私钥 " + Program.RSA_PRIVATE_FILE_NAME + " 读取失败，请重新生成RSA密钥对");
                ReceiverRSA = null;
                textBoxRecRSA.Text = "";
                return;
            }
            if (sender != null)
                MessageHint("私钥 " + Program.RSA_PRIVATE_FILE_NAME + " 读取成功！");
            textBoxRecRSA.Text = ReceiverRSA.ToString();
        }

        private void buttonRecRSASave_Click(object sender, EventArgs e)
        {
            if (busy) return;
            if (ReceiverRSA==null)
            {
                MessageError("请先生成密钥对");
                return;
            }
            try
            {
                using (FileStream fs = new FileStream(Program.RSA_PRIVATE_FILE_NAME, FileMode.Create))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, ReceiverRSA);
                }
                using (FileStream fs = new FileStream(Program.RSA_PUBLIC_FILE_NAME, FileMode.Create))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, ReceiverRSA.publicKey);
                }
            }
            catch
            {
                MessageError("保存失败，可能是由于文件系统原因");
                return;
            }
            MessageHint("私钥已保存到 " + Program.RSA_PRIVATE_FILE_NAME + Environment.NewLine + "公钥已保存到 " + Program.RSA_PUBLIC_FILE_NAME); ;

        }

        private void buttonEncrypt_Click(object sender, EventArgs e)
        {
            if (busy)
                return;
            try
            {
                MessageHint("请选择明文文本。");
                if (encryptFileDialog.ShowDialog() != DialogResult.OK)
                    return;
                textBoxInputFile.Text = encryptFileDialog.FileName;
                MessageHint("请选择密文存储位置。");
                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    return;
                textBoxOutputFile.Text = saveFileDialog.FileName;
                if (Key == null)
                {
                    MessageHint("密钥尚未加载，请选择密钥。");
                    LoadKeyButton_Click(sender, e);
                    if (Key == null)
                        return;
                }
                if(ReceiverPublicKey==null)
                {
                    buttonGetRSAPublic_Click(sender, e);
                    if (ReceiverPublicKey == null)
                        return;
                }
                buttonRSAEncrypt_Click(sender, e);
                using (BinaryReader br = new BinaryReader(new FileStream(encryptFileDialog.FileName, FileMode.Open, FileAccess.Read)))
                {
                    using (BinaryWriter bw = new BinaryWriter(new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write)))
                    {
                        DESStream encryptStream = new DESStream(br, Key, bw, IV);
                        busy = true;
                        Log("开始加密");
                        if (IV == null)
                        {
                            RandomIVButton_Click(null, null);
                        }
                        encryptStream.Encrypt();
                        Log("加密结束");
                        busy = false;
                    }
                }
                MessageHint("加密成功。");
            }
            catch (FileNotFoundException)
            {
                MessageError("错误：文件未找到");
                MessageError("加密失败。");
            }
            catch (IOException)
            {
                MessageError("错误：文件读写发生错误");
                MessageError("加密失败。");
            }
        }

        private void buttonRSAEncrypt_Click(object sender, EventArgs e)
        {
            if (busy) return;

            if(ReceiverPublicKey==null)
            {
                MessageError("请先加载接收者公钥！");
                return;
            }
            else if(Key==null)
            {
                MessageError("请先加载DES密钥文件！");
                return;
            }
            EncryptedDESKey = ReceiverPublicKey.EncryptBlock(Key.ToBigIntegerValue());
            textBoxRSAOutput.Text = EncryptedDESKey.ToString();
            using (FileStream fs = new FileStream(Program.ENCRYPTED_KEY_FILE_NAME, FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, EncryptedDESKey);
            }
            Log("RSA加密成功");
            MessageHint("加密传送密钥已经存储至 " + Program.ENCRYPTED_KEY_FILE_NAME);
        }

        private void buttonRSADecrypt_Click(object sender, EventArgs e)
        {
            if (busy) return;

            if (ReceiverRSA == null)
            {
                MessageError("你还没有私钥！");
                return;
            }
            else if (RecEncryptedDESKey == 0)
            {
                MessageError("请先加载加密传送密钥！");
                return;
            }
            RecKey = new Bitset(64);
            try
            {
                BigInteger result = ReceiverRSA.DecryptBlock(RecEncryptedDESKey);
                RecKey.PasteBigInteger(result);
                textBoxRecKey.Text = RecKey.ToString();
                textBoxRecRSAOutput.Text = result.ToString();
                Log("RSA解密成功");
                MessageHint("RSA解密成功，得到DES密钥！");
            }
            catch
            {
                MessageError("文件不合法，RSA私钥与加密文件不匹配。");
                RecKey = null;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("信息安全原理课程项目\n作者：14计算机 姜峻岩\n学号：14307130166\n第三方库：未使用");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Form1().ShowDialog();
        }

        private void buttonDecrypt_Click(object sender, EventArgs e)
        {
            if (busy) return;
            try
            {
                MessageHint("请选择密文文本。");
                if (encryptFileDialog.ShowDialog() != DialogResult.OK)
                    return;
                textBoxRecInputFile.Text = encryptFileDialog.FileName;
                MessageHint("请选择明文存储位置。");
                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    return;
                textBoxRecOutputFile.Text = saveFileDialog.FileName;
                if (RecKey == null)
                {
                    buttonRecLoadRSAInput_Click(sender, e);
                    if (RecEncryptedDESKey == 0) return;
                    buttonRSADecrypt_Click(sender, e);
                    if (RecKey == null)
                        return;
                }
                using (BinaryReader br = new BinaryReader(new FileStream(encryptFileDialog.FileName, FileMode.Open, FileAccess.Read)))
                {
                    using (BinaryWriter bw = new BinaryWriter(new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write)))
                    {
                        DESStream encryptStream = new DESStream(br, RecKey, bw, IV);
                        busy = true;
                        Log("开始解密");
                        encryptStream.Decrypt();
                        Log("解密结束");
                        busy = false;
                    }
                }
                MessageHint("DES解密成功。");

            }
            catch (FileNotFoundException)
            {
                MessageError("错误：文件未找到");
                MessageError("解密失败。");
            }
            catch (IOException)
            {
                MessageError("错误：文件读写发生错误");
                MessageError("解密失败。");
            }
        }

        private void buttonRecLoadRSAInput_Click(object sender, EventArgs e)
        {
            if (busy) return;
            try
            {
                using (FileStream fs = new FileStream(Program.ENCRYPTED_KEY_FILE_NAME, FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    RecEncryptedDESKey = (BigInteger)bf.Deserialize(fs);
                }
            }
            catch
            {
                MessageError("加密传送密钥 " + Program.ENCRYPTED_KEY_FILE_NAME + " 读取失败！发送者还没有执行过加密操作。");
                RecEncryptedDESKey = 0;
                textBoxRecRSAInput.Text = "";
                return;
            }
            Log("加载加密传输密钥成功");
            MessageHint("加密传输密钥 " + Program.ENCRYPTED_KEY_FILE_NAME + " 读取成功！");
            textBoxRecRSAInput.Text = RecEncryptedDESKey.ToString();
        }

        private void RandomIVButton_Click(object sender, EventArgs e)
        {
            Log("生成随机初始向量：IV(64 bit)");
            IV = Bitset.RandomGenerate(64);
            IVText.Text = IV.ToString();
        }
    }
}
