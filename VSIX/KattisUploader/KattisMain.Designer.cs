﻿namespace KattisUploader
{
    partial class KattisMain
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
            this.components = new System.ComponentModel.Container();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.lbLanguages = new System.Windows.Forms.ListBox();
            this.kattisMainBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cbKattisIDS = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.kattisMainBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(47, 29);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(70, 25);
            this.lblUser.TabIndex = 0;
            this.lblUser.Text = "label1";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(47, 89);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(70, 25);
            this.lblPassword.TabIndex = 1;
            this.lblPassword.Text = "label2";
            // 
            // tbUser
            // 
            this.tbUser.Location = new System.Drawing.Point(157, 29);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(185, 31);
            this.tbUser.TabIndex = 2;
            this.tbUser.Text = "mark-wardell";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(157, 83);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(185, 31);
            this.tbPassword.TabIndex = 3;
            this.tbPassword.Text = "aa14d4dd381062429ac55d28c90b65b7715dfe30726ad37847557216cf6261df";
            // 
            // lbLanguages
            // 
            this.lbLanguages.DataSource = this.kattisMainBindingSource;
            this.lbLanguages.FormattingEnabled = true;
            this.lbLanguages.ItemHeight = 25;
            this.lbLanguages.Location = new System.Drawing.Point(52, 181);
            this.lbLanguages.Name = "lbLanguages";
            this.lbLanguages.Size = new System.Drawing.Size(296, 479);
            this.lbLanguages.TabIndex = 4;
            // 
            // kattisMainBindingSource
            // 
            this.kattisMainBindingSource.DataSource = typeof(KattisUploader.KattisMain);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "label2";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(380, 83);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1099, 571);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "using System; \r\nnamespace HelloWorld \r\n{ \r\nclass Program \r\n{ \r\nstatic void Main(s" +
    "tring[] args) \r\n{ \r\nConsole.WriteLine(\"Hello World!\"); \r\n} \r\n} \r\n}\r\n\r\n";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(622, 690);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(296, 83);
            this.button1.TabIndex = 7;
            this.button1.Text = "Submit To Kattis\r\n";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // cbKattisIDS
            // 
            this.cbKattisIDS.FormattingEnabled = true;
            this.cbKattisIDS.Location = new System.Drawing.Point(392, 26);
            this.cbKattisIDS.Name = "cbKattisIDS";
            this.cbKattisIDS.Size = new System.Drawing.Size(424, 33);
            this.cbKattisIDS.TabIndex = 8;
            // 
            // KattisMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1565, 815);
            this.Controls.Add(this.cbKattisIDS);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbLanguages);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbUser);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUser);
            this.Name = "KattisMain";
            this.Text = "KattisMain";
            this.Load += new System.EventHandler(this.KattisMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kattisMainBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.ListBox lbLanguages;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource kattisMainBindingSource;
        private System.Windows.Forms.ComboBox cbKattisIDS;
    }
}