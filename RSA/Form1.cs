using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

namespace RSA
{
    public partial class Form1 : Form
    {
        RSA rsa;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rsa = new RSA(16);
            textBox2.Text = rsa.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                textBox3.Text = rsa.EncryptBlock(BigInteger.Parse(textBox1.Text)).ToString();
            }
            catch
            {
                MessageBox.Show("输入不合法");
            }
            //BigInteger x, y;
            //Console.WriteLine(Mathbase.ExtendGCD(27, 150,out x,out y));
            //Console.WriteLine(x+","+ y);
            /*Console.WriteLine(Mathbase.GetInverse(26, 101));
            Console.WriteLine(Mathbase.GetInverse(27, 101));
            Console.WriteLine(Mathbase.GetInverse(28, 101));
            Console.WriteLine(Mathbase.GetInverse(29, 101));
            Console.WriteLine(Mathbase.GetInverse(26, 105));
            Console.WriteLine(Mathbase.GetInverse(29, 105));*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = rsa.DecryptBlock(BigInteger.Parse(textBox3.Text)).ToString();
            }
            catch
            {
                MessageBox.Show("输入不合法");
            }

        }
    }
}
