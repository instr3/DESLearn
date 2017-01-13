namespace DES
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.encryptFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.keyFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.Logger = new System.Windows.Forms.TextBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonEncrypt = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RandomIVButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.IVText = new System.Windows.Forms.TextBox();
            this.textBoxOutputFile = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxInputFile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxKey = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.LoadKeyButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonRSAEncrypt = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxRSAOutput = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxRSAInput = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxRSAPublicKey = new System.Windows.Forms.TextBox();
            this.buttonGetRSAPublic = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonDecrypt = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBoxRecOutputFile = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxRecInputFile = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxRecKey = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonRecLoadRSAInput = new System.Windows.Forms.Button();
            this.buttonRSADecrypt = new System.Windows.Forms.Button();
            this.buttonRecRSASave = new System.Windows.Forms.Button();
            this.buttonRecRSALoad = new System.Windows.Forms.Button();
            this.textBoxRecRSAInput = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxRecRSAOutput = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxRecRSA = new System.Windows.Forms.TextBox();
            this.buttonRecRSANew = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(566, 524);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(53, 12);
            this.linkLabel1.TabIndex = 31;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "关于项目";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // encryptFileDialog
            // 
            this.encryptFileDialog.Filter = "输入数据|*.*";
            // 
            // keyFileDialog
            // 
            this.keyFileDialog.Filter = "密钥文件|*.*";
            // 
            // Logger
            // 
            this.Logger.ForeColor = System.Drawing.Color.Gray;
            this.Logger.Location = new System.Drawing.Point(16, 399);
            this.Logger.Multiline = true;
            this.Logger.Name = "Logger";
            this.Logger.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Logger.Size = new System.Drawing.Size(601, 112);
            this.Logger.TabIndex = 18;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.FileName = "output.txt";
            this.saveFileDialog.Filter = "输出数据|*.*";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(612, 343);
            this.tabControl1.TabIndex = 32;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.buttonEncrypt);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(604, 317);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "发送者";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonEncrypt
            // 
            this.buttonEncrypt.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonEncrypt.Location = new System.Drawing.Point(6, 286);
            this.buttonEncrypt.Name = "buttonEncrypt";
            this.buttonEncrypt.Size = new System.Drawing.Size(176, 23);
            this.buttonEncrypt.TabIndex = 15;
            this.buttonEncrypt.Text = "加密文件并加密传输密钥";
            this.buttonEncrypt.UseVisualStyleBackColor = true;
            this.buttonEncrypt.Click += new System.EventHandler(this.buttonEncrypt_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RandomIVButton);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.IVText);
            this.groupBox2.Controls.Add(this.textBoxOutputFile);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBoxInputFile);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBoxKey);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.LoadKeyButton);
            this.groupBox2.Location = new System.Drawing.Point(8, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(590, 131);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DES";
            // 
            // RandomIVButton
            // 
            this.RandomIVButton.Location = new System.Drawing.Point(6, 102);
            this.RandomIVButton.Name = "RandomIVButton";
            this.RandomIVButton.Size = new System.Drawing.Size(96, 23);
            this.RandomIVButton.TabIndex = 24;
            this.RandomIVButton.Text = "随机初始向量";
            this.RandomIVButton.UseVisualStyleBackColor = true;
            this.RandomIVButton.Click += new System.EventHandler(this.RandomIVButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(121, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 23;
            this.label4.Text = "初始化向量";
            // 
            // IVText
            // 
            this.IVText.Location = new System.Drawing.Point(188, 103);
            this.IVText.Name = "IVText";
            this.IVText.ReadOnly = true;
            this.IVText.Size = new System.Drawing.Size(396, 21);
            this.IVText.TabIndex = 22;
            // 
            // textBoxOutputFile
            // 
            this.textBoxOutputFile.Location = new System.Drawing.Point(188, 76);
            this.textBoxOutputFile.Name = "textBoxOutputFile";
            this.textBoxOutputFile.ReadOnly = true;
            this.textBoxOutputFile.Size = new System.Drawing.Size(396, 21);
            this.textBoxOutputFile.TabIndex = 20;
            this.textBoxOutputFile.Text = "未选择密文存储位置";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(121, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 19;
            this.label3.Text = "密文文件为";
            // 
            // textBoxInputFile
            // 
            this.textBoxInputFile.Location = new System.Drawing.Point(188, 49);
            this.textBoxInputFile.Name = "textBoxInputFile";
            this.textBoxInputFile.ReadOnly = true;
            this.textBoxInputFile.Size = new System.Drawing.Size(396, 21);
            this.textBoxInputFile.TabIndex = 18;
            this.textBoxInputFile.Text = "未选择明文文件";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(121, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 17;
            this.label2.Text = "明文文件为";
            // 
            // textBoxKey
            // 
            this.textBoxKey.Location = new System.Drawing.Point(188, 22);
            this.textBoxKey.Name = "textBoxKey";
            this.textBoxKey.ReadOnly = true;
            this.textBoxKey.Size = new System.Drawing.Size(396, 21);
            this.textBoxKey.TabIndex = 16;
            this.textBoxKey.Text = "未加载密钥";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(141, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "密钥为";
            // 
            // LoadKeyButton
            // 
            this.LoadKeyButton.Location = new System.Drawing.Point(6, 20);
            this.LoadKeyButton.Name = "LoadKeyButton";
            this.LoadKeyButton.Size = new System.Drawing.Size(96, 23);
            this.LoadKeyButton.TabIndex = 14;
            this.LoadKeyButton.Text = "加载DES密钥";
            this.LoadKeyButton.UseVisualStyleBackColor = true;
            this.LoadKeyButton.Click += new System.EventHandler(this.LoadKeyButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonRSAEncrypt);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxRSAOutput);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textBoxRSAInput);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBoxRSAPublicKey);
            this.groupBox1.Controls.Add(this.buttonGetRSAPublic);
            this.groupBox1.Location = new System.Drawing.Point(11, 143);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(590, 137);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "RSA";
            // 
            // buttonRSAEncrypt
            // 
            this.buttonRSAEncrypt.Location = new System.Drawing.Point(6, 105);
            this.buttonRSAEncrypt.Name = "buttonRSAEncrypt";
            this.buttonRSAEncrypt.Size = new System.Drawing.Size(93, 23);
            this.buttonRSAEncrypt.TabIndex = 25;
            this.buttonRSAEncrypt.Text = "RSA加密";
            this.buttonRSAEncrypt.UseVisualStyleBackColor = true;
            this.buttonRSAEncrypt.Click += new System.EventHandler(this.buttonRSAEncrypt_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(138, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 24;
            this.label1.Text = "接收者公钥";
            // 
            // textBoxRSAOutput
            // 
            this.textBoxRSAOutput.Location = new System.Drawing.Point(185, 107);
            this.textBoxRSAOutput.Name = "textBoxRSAOutput";
            this.textBoxRSAOutput.ReadOnly = true;
            this.textBoxRSAOutput.Size = new System.Drawing.Size(396, 21);
            this.textBoxRSAOutput.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(132, 110);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 12);
            this.label7.TabIndex = 22;
            this.label7.Text = "RSA密文";
            // 
            // textBoxRSAInput
            // 
            this.textBoxRSAInput.Location = new System.Drawing.Point(185, 80);
            this.textBoxRSAInput.Name = "textBoxRSAInput";
            this.textBoxRSAInput.ReadOnly = true;
            this.textBoxRSAInput.Size = new System.Drawing.Size(396, 21);
            this.textBoxRSAInput.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(70, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 12);
            this.label6.TabIndex = 3;
            this.label6.Text = "RSA明文（DES密钥）";
            // 
            // textBoxRSAPublicKey
            // 
            this.textBoxRSAPublicKey.Location = new System.Drawing.Point(211, 20);
            this.textBoxRSAPublicKey.Multiline = true;
            this.textBoxRSAPublicKey.Name = "textBoxRSAPublicKey";
            this.textBoxRSAPublicKey.ReadOnly = true;
            this.textBoxRSAPublicKey.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxRSAPublicKey.Size = new System.Drawing.Size(370, 54);
            this.textBoxRSAPublicKey.TabIndex = 2;
            // 
            // buttonGetRSAPublic
            // 
            this.buttonGetRSAPublic.Location = new System.Drawing.Point(6, 20);
            this.buttonGetRSAPublic.Name = "buttonGetRSAPublic";
            this.buttonGetRSAPublic.Size = new System.Drawing.Size(126, 23);
            this.buttonGetRSAPublic.TabIndex = 0;
            this.buttonGetRSAPublic.Text = "加载接收者公钥";
            this.buttonGetRSAPublic.UseVisualStyleBackColor = true;
            this.buttonGetRSAPublic.Click += new System.EventHandler(this.buttonGetRSAPublic_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.buttonDecrypt);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(604, 317);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "接收者";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonDecrypt
            // 
            this.buttonDecrypt.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonDecrypt.Location = new System.Drawing.Point(6, 281);
            this.buttonDecrypt.Name = "buttonDecrypt";
            this.buttonDecrypt.Size = new System.Drawing.Size(176, 23);
            this.buttonDecrypt.TabIndex = 16;
            this.buttonDecrypt.Text = "解密文件";
            this.buttonDecrypt.UseVisualStyleBackColor = true;
            this.buttonDecrypt.Click += new System.EventHandler(this.buttonDecrypt_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBoxRecOutputFile);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.textBoxRecInputFile);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.textBoxRecKey);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(590, 105);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "DES";
            // 
            // textBoxRecOutputFile
            // 
            this.textBoxRecOutputFile.Location = new System.Drawing.Point(188, 76);
            this.textBoxRecOutputFile.Name = "textBoxRecOutputFile";
            this.textBoxRecOutputFile.ReadOnly = true;
            this.textBoxRecOutputFile.Size = new System.Drawing.Size(396, 21);
            this.textBoxRecOutputFile.TabIndex = 20;
            this.textBoxRecOutputFile.Text = "未选择明文存储位置";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(121, 81);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 19;
            this.label9.Text = "明文文件为";
            // 
            // textBoxRecInputFile
            // 
            this.textBoxRecInputFile.Location = new System.Drawing.Point(188, 49);
            this.textBoxRecInputFile.Name = "textBoxRecInputFile";
            this.textBoxRecInputFile.ReadOnly = true;
            this.textBoxRecInputFile.Size = new System.Drawing.Size(396, 21);
            this.textBoxRecInputFile.TabIndex = 18;
            this.textBoxRecInputFile.Text = "未选择密文文件";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(121, 54);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 17;
            this.label10.Text = "密文文件为";
            // 
            // textBoxRecKey
            // 
            this.textBoxRecKey.Location = new System.Drawing.Point(188, 22);
            this.textBoxRecKey.Name = "textBoxRecKey";
            this.textBoxRecKey.ReadOnly = true;
            this.textBoxRecKey.Size = new System.Drawing.Size(396, 21);
            this.textBoxRecKey.TabIndex = 16;
            this.textBoxRecKey.Text = "未提供密钥";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(141, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 15;
            this.label11.Text = "密钥为";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.buttonRecLoadRSAInput);
            this.groupBox4.Controls.Add(this.buttonRSADecrypt);
            this.groupBox4.Controls.Add(this.buttonRecRSASave);
            this.groupBox4.Controls.Add(this.buttonRecRSALoad);
            this.groupBox4.Controls.Add(this.textBoxRecRSAInput);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.textBoxRecRSAOutput);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.textBoxRecRSA);
            this.groupBox4.Controls.Add(this.buttonRecRSANew);
            this.groupBox4.Location = new System.Drawing.Point(6, 117);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(590, 158);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "RSA";
            // 
            // buttonRecLoadRSAInput
            // 
            this.buttonRecLoadRSAInput.Location = new System.Drawing.Point(6, 104);
            this.buttonRecLoadRSAInput.Name = "buttonRecLoadRSAInput";
            this.buttonRecLoadRSAInput.Size = new System.Drawing.Size(126, 23);
            this.buttonRecLoadRSAInput.TabIndex = 27;
            this.buttonRecLoadRSAInput.Text = "加载RSA密文";
            this.buttonRecLoadRSAInput.UseVisualStyleBackColor = true;
            this.buttonRecLoadRSAInput.Click += new System.EventHandler(this.buttonRecLoadRSAInput_Click);
            // 
            // buttonRSADecrypt
            // 
            this.buttonRSADecrypt.Location = new System.Drawing.Point(6, 130);
            this.buttonRSADecrypt.Name = "buttonRSADecrypt";
            this.buttonRSADecrypt.Size = new System.Drawing.Size(62, 23);
            this.buttonRSADecrypt.TabIndex = 26;
            this.buttonRSADecrypt.Text = "RSA解密";
            this.buttonRSADecrypt.UseVisualStyleBackColor = true;
            this.buttonRSADecrypt.Click += new System.EventHandler(this.buttonRSADecrypt_Click);
            // 
            // buttonRecRSASave
            // 
            this.buttonRecRSASave.Location = new System.Drawing.Point(6, 77);
            this.buttonRecRSASave.Name = "buttonRecRSASave";
            this.buttonRecRSASave.Size = new System.Drawing.Size(126, 23);
            this.buttonRecRSASave.TabIndex = 25;
            this.buttonRecRSASave.Text = "保存RSA密钥对";
            this.buttonRecRSASave.UseVisualStyleBackColor = true;
            this.buttonRecRSASave.Click += new System.EventHandler(this.buttonRecRSASave_Click);
            // 
            // buttonRecRSALoad
            // 
            this.buttonRecRSALoad.Location = new System.Drawing.Point(6, 49);
            this.buttonRecRSALoad.Name = "buttonRecRSALoad";
            this.buttonRecRSALoad.Size = new System.Drawing.Size(126, 23);
            this.buttonRecRSALoad.TabIndex = 24;
            this.buttonRecRSALoad.Text = "读取RSA密钥对";
            this.buttonRecRSALoad.UseVisualStyleBackColor = true;
            this.buttonRecRSALoad.Click += new System.EventHandler(this.buttonRecRSALoad_Click);
            // 
            // textBoxRecRSAInput
            // 
            this.textBoxRecRSAInput.Location = new System.Drawing.Point(188, 106);
            this.textBoxRecRSAInput.Name = "textBoxRecRSAInput";
            this.textBoxRecRSAInput.ReadOnly = true;
            this.textBoxRecRSAInput.Size = new System.Drawing.Size(396, 21);
            this.textBoxRecRSAInput.TabIndex = 23;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(135, 109);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 12);
            this.label12.TabIndex = 22;
            this.label12.Text = "RSA密文";
            // 
            // textBoxRecRSAOutput
            // 
            this.textBoxRecRSAOutput.Location = new System.Drawing.Point(188, 132);
            this.textBoxRecRSAOutput.Name = "textBoxRecRSAOutput";
            this.textBoxRecRSAOutput.ReadOnly = true;
            this.textBoxRecRSAOutput.Size = new System.Drawing.Size(396, 21);
            this.textBoxRecRSAOutput.TabIndex = 21;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(74, 135);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(113, 12);
            this.label13.TabIndex = 3;
            this.label13.Text = "RSA明文（DES密钥）";
            // 
            // textBoxRecRSA
            // 
            this.textBoxRecRSA.Location = new System.Drawing.Point(138, 20);
            this.textBoxRecRSA.Multiline = true;
            this.textBoxRecRSA.Name = "textBoxRecRSA";
            this.textBoxRecRSA.ReadOnly = true;
            this.textBoxRecRSA.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxRecRSA.Size = new System.Drawing.Size(446, 80);
            this.textBoxRecRSA.TabIndex = 2;
            this.textBoxRecRSA.Text = "你还没有RSA密钥对！赶紧生成一个吧！";
            // 
            // buttonRecRSANew
            // 
            this.buttonRecRSANew.Location = new System.Drawing.Point(6, 20);
            this.buttonRecRSANew.Name = "buttonRecRSANew";
            this.buttonRecRSANew.Size = new System.Drawing.Size(126, 23);
            this.buttonRecRSANew.TabIndex = 0;
            this.buttonRecRSANew.Text = "生成RSA新密钥对";
            this.buttonRecRSANew.UseVisualStyleBackColor = true;
            this.buttonRecRSANew.Click += new System.EventHandler(this.buttonRecRSANew_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(16, 361);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(601, 23);
            this.progressBar.TabIndex = 33;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(507, 524);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(53, 12);
            this.linkLabel2.TabIndex = 34;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Project1";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 544);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.Logger);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.Text = "DES + RSA";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.OpenFileDialog encryptFileDialog;
        private System.Windows.Forms.OpenFileDialog keyFileDialog;
        private System.Windows.Forms.TextBox Logger;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonGetRSAPublic;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox textBoxRSAPublicKey;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button RandomIVButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox IVText;
        private System.Windows.Forms.TextBox textBoxInputFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxKey;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button LoadKeyButton;
        private System.Windows.Forms.TextBox textBoxRSAOutput;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxRSAInput;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonEncrypt;
        private System.Windows.Forms.TextBox textBoxOutputFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBoxRecOutputFile;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxRecInputFile;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxRecKey;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBoxRecRSAInput;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxRecRSAOutput;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBoxRecRSA;
        private System.Windows.Forms.Button buttonRecRSANew;
        private System.Windows.Forms.Button buttonRecRSASave;
        private System.Windows.Forms.Button buttonRecRSALoad;
        private System.Windows.Forms.Button buttonDecrypt;
        public System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonRSAEncrypt;
        private System.Windows.Forms.Button buttonRSADecrypt;
        private System.Windows.Forms.Button buttonRecLoadRSAInput;
        private System.Windows.Forms.LinkLabel linkLabel2;
    }
}