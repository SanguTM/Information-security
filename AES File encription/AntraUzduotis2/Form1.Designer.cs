
namespace AntraUzduotis2
{
    partial class Form1
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
            this.FileImputBox = new System.Windows.Forms.TextBox();
            this.Encript = new System.Windows.Forms.Button();
            this.Decript = new System.Windows.Forms.Button();
            this.labelFilePath = new System.Windows.Forms.Label();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.ModeComboBox = new System.Windows.Forms.ComboBox();
            this.Mode = new System.Windows.Forms.Label();
            this.PasswordBox = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // FileImputBox
            // 
            this.FileImputBox.Location = new System.Drawing.Point(350, 160);
            this.FileImputBox.Name = "FileImputBox";
            this.FileImputBox.Size = new System.Drawing.Size(100, 20);
            this.FileImputBox.TabIndex = 0;
            // 
            // Encript
            // 
            this.Encript.Location = new System.Drawing.Point(275, 240);
            this.Encript.Name = "Encript";
            this.Encript.Size = new System.Drawing.Size(75, 23);
            this.Encript.TabIndex = 2;
            this.Encript.Text = "Encript";
            this.Encript.UseVisualStyleBackColor = true;
            this.Encript.Click += new System.EventHandler(this.Encript_Click);
            // 
            // Decript
            // 
            this.Decript.Location = new System.Drawing.Point(382, 240);
            this.Decript.Name = "Decript";
            this.Decript.Size = new System.Drawing.Size(75, 23);
            this.Decript.TabIndex = 3;
            this.Decript.Text = "Decript";
            this.Decript.UseVisualStyleBackColor = true;
            this.Decript.Click += new System.EventHandler(this.Decript_Click);
            // 
            // labelFilePath
            // 
            this.labelFilePath.AutoSize = true;
            this.labelFilePath.Location = new System.Drawing.Point(283, 163);
            this.labelFilePath.Name = "labelFilePath";
            this.labelFilePath.Size = new System.Drawing.Size(50, 13);
            this.labelFilePath.TabIndex = 4;
            this.labelFilePath.Text = "File path:";
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(467, 160);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(28, 23);
            this.buttonBrowse.TabIndex = 7;
            this.buttonBrowse.Text = "...";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // ModeComboBox
            // 
            this.ModeComboBox.FormattingEnabled = true;
            this.ModeComboBox.Items.AddRange(new object[] {
            "ECB",
            "CBC",
            "CFB"});
            this.ModeComboBox.Location = new System.Drawing.Point(350, 195);
            this.ModeComboBox.Name = "ModeComboBox";
            this.ModeComboBox.Size = new System.Drawing.Size(100, 21);
            this.ModeComboBox.TabIndex = 8;
            // 
            // Mode
            // 
            this.Mode.AutoSize = true;
            this.Mode.Location = new System.Drawing.Point(244, 198);
            this.Mode.Name = "Mode";
            this.Mode.Size = new System.Drawing.Size(89, 13);
            this.Mode.TabIndex = 9;
            this.Mode.Text = "Encryption mode:";
            // 
            // PasswordBox
            // 
            this.PasswordBox.Location = new System.Drawing.Point(350, 124);
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.Size = new System.Drawing.Size(100, 20);
            this.PasswordBox.TabIndex = 10;
            // 
            // Password
            // 
            this.Password.AutoSize = true;
            this.Password.Location = new System.Drawing.Point(283, 127);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(53, 13);
            this.Password.TabIndex = 11;
            this.Password.Text = "Password";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.PasswordBox);
            this.Controls.Add(this.Mode);
            this.Controls.Add(this.ModeComboBox);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.labelFilePath);
            this.Controls.Add(this.Decript);
            this.Controls.Add(this.Encript);
            this.Controls.Add(this.FileImputBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FileImputBox;
        private System.Windows.Forms.Button Encript;
        private System.Windows.Forms.Button Decript;
        private System.Windows.Forms.Label labelFilePath;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.ComboBox ModeComboBox;
        private System.Windows.Forms.Label Mode;
        private System.Windows.Forms.TextBox PasswordBox;
        private System.Windows.Forms.Label Password;
    }
}

