namespace DES
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.Logger = new System.Windows.Forms.TextBox();
            this.LoadKeyButton = new System.Windows.Forms.Button();
            this.keyFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.encryptFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxKey = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.textBoxInputFile = new System.Windows.Forms.TextBox();
            this.textBoxOutputFile = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DecryptButton = new System.Windows.Forms.Button();
            this.encryptButton = new System.Windows.Forms.Button();
            this.IVText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.RandomIVButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(12, 122);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "测试";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Logger
            // 
            this.Logger.ForeColor = System.Drawing.Color.Gray;
            this.Logger.Location = new System.Drawing.Point(12, 151);
            this.Logger.Multiline = true;
            this.Logger.Name = "Logger";
            this.Logger.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Logger.Size = new System.Drawing.Size(601, 153);
            this.Logger.TabIndex = 1;
            // 
            // LoadKeyButton
            // 
            this.LoadKeyButton.Location = new System.Drawing.Point(12, 12);
            this.LoadKeyButton.Name = "LoadKeyButton";
            this.LoadKeyButton.Size = new System.Drawing.Size(96, 23);
            this.LoadKeyButton.TabIndex = 0;
            this.LoadKeyButton.Text = "加载密钥";
            this.LoadKeyButton.UseVisualStyleBackColor = true;
            this.LoadKeyButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // keyFileDialog
            // 
            this.keyFileDialog.Filter = "密钥文件|*.*";
            // 
            // encryptFileDialog
            // 
            this.encryptFileDialog.Filter = "输入数据|*.*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(147, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "密钥为";
            // 
            // textBoxKey
            // 
            this.textBoxKey.Enabled = false;
            this.textBoxKey.Location = new System.Drawing.Point(194, 14);
            this.textBoxKey.Name = "textBoxKey";
            this.textBoxKey.Size = new System.Drawing.Size(419, 21);
            this.textBoxKey.TabIndex = 4;
            this.textBoxKey.Text = "未加载密钥";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(127, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "输入文件为";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.FileName = "output.txt";
            this.saveFileDialog.Filter = "输出数据|*.*";
            // 
            // textBoxInputFile
            // 
            this.textBoxInputFile.Enabled = false;
            this.textBoxInputFile.Location = new System.Drawing.Point(194, 41);
            this.textBoxInputFile.Name = "textBoxInputFile";
            this.textBoxInputFile.Size = new System.Drawing.Size(419, 21);
            this.textBoxInputFile.TabIndex = 6;
            // 
            // textBoxOutputFile
            // 
            this.textBoxOutputFile.Enabled = false;
            this.textBoxOutputFile.Location = new System.Drawing.Point(194, 68);
            this.textBoxOutputFile.Name = "textBoxOutputFile";
            this.textBoxOutputFile.Size = new System.Drawing.Size(419, 21);
            this.textBoxOutputFile.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(127, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "输出文件为";
            // 
            // DecryptButton
            // 
            this.DecryptButton.Location = new System.Drawing.Point(12, 67);
            this.DecryptButton.Name = "DecryptButton";
            this.DecryptButton.Size = new System.Drawing.Size(96, 23);
            this.DecryptButton.TabIndex = 9;
            this.DecryptButton.Text = "解密";
            this.DecryptButton.UseVisualStyleBackColor = true;
            this.DecryptButton.Click += new System.EventHandler(this.DecryptButton_Click);
            // 
            // encryptButton
            // 
            this.encryptButton.Location = new System.Drawing.Point(12, 40);
            this.encryptButton.Name = "encryptButton";
            this.encryptButton.Size = new System.Drawing.Size(96, 23);
            this.encryptButton.TabIndex = 10;
            this.encryptButton.Text = "加密";
            this.encryptButton.UseVisualStyleBackColor = true;
            this.encryptButton.Click += new System.EventHandler(this.encryptButton_Click);
            // 
            // IVText
            // 
            this.IVText.Enabled = false;
            this.IVText.Location = new System.Drawing.Point(194, 95);
            this.IVText.Name = "IVText";
            this.IVText.Size = new System.Drawing.Size(419, 21);
            this.IVText.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(127, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "初始化向量";
            // 
            // RandomIVButton
            // 
            this.RandomIVButton.Location = new System.Drawing.Point(12, 94);
            this.RandomIVButton.Name = "RandomIVButton";
            this.RandomIVButton.Size = new System.Drawing.Size(96, 23);
            this.RandomIVButton.TabIndex = 13;
            this.RandomIVButton.Text = "随机初始向量";
            this.RandomIVButton.UseVisualStyleBackColor = true;
            this.RandomIVButton.Click += new System.EventHandler(this.RandomIVButton_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 123);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(601, 23);
            this.progressBar.TabIndex = 14;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(560, 314);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(53, 12);
            this.linkLabel1.TabIndex = 15;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "关于项目";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 335);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.RandomIVButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.IVText);
            this.Controls.Add(this.encryptButton);
            this.Controls.Add(this.DecryptButton);
            this.Controls.Add(this.textBoxOutputFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxInputFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxKey);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LoadKeyButton);
            this.Controls.Add(this.Logger);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "DES算法";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox Logger;
        private System.Windows.Forms.Button LoadKeyButton;
        private System.Windows.Forms.OpenFileDialog keyFileDialog;
        private System.Windows.Forms.OpenFileDialog encryptFileDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.TextBox textBoxInputFile;
        private System.Windows.Forms.TextBox textBoxOutputFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button DecryptButton;
        private System.Windows.Forms.Button encryptButton;
        private System.Windows.Forms.TextBox IVText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button RandomIVButton;
        public System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}

