using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DES
{
    static class Program
    {
        public static string RSA_PUBLIC_FILE_NAME = "密钥传输/rsa_public.dat";
        public static string ENCRYPTED_KEY_FILE_NAME = "密钥传输/encrypted_key.chip";
        public static string RSA_PRIVATE_FILE_NAME = "接收者私钥/rsa_private.dat";

        public static Form2 Form;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Directory.CreateDirectory("密钥传输");
            Directory.CreateDirectory("接收者私钥");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form = new Form2();
            Application.Run(Form);
        }
    }
}
