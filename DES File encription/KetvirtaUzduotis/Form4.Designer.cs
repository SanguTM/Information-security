
namespace KetvirtaUzduotis
{
    partial class EditPassword
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
            this.EditButton = new System.Windows.Forms.Button();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.URLTextBox = new System.Windows.Forms.TextBox();
            this.NoteTextBox = new System.Windows.Forms.TextBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.URLLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.CommentLabel = new System.Windows.Forms.Label();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.FindButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // EditButton
            // 
            this.EditButton.Location = new System.Drawing.Point(272, 239);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(102, 23);
            this.EditButton.TabIndex = 23;
            this.EditButton.Text = "Edit";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(361, 194);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(100, 23);
            this.passwordTextBox.TabIndex = 22;
            // 
            // URLTextBox
            // 
            this.URLTextBox.Location = new System.Drawing.Point(361, 162);
            this.URLTextBox.Name = "URLTextBox";
            this.URLTextBox.Size = new System.Drawing.Size(100, 23);
            this.URLTextBox.TabIndex = 21;
            // 
            // NoteTextBox
            // 
            this.NoteTextBox.Location = new System.Drawing.Point(361, 130);
            this.NoteTextBox.Name = "NoteTextBox";
            this.NoteTextBox.Size = new System.Drawing.Size(100, 23);
            this.NoteTextBox.TabIndex = 20;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(361, 98);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(100, 23);
            this.NameTextBox.TabIndex = 19;
            // 
            // URLLabel
            // 
            this.URLLabel.AutoSize = true;
            this.URLLabel.Location = new System.Drawing.Point(299, 168);
            this.URLLabel.Name = "URLLabel";
            this.URLLabel.Size = new System.Drawing.Size(28, 15);
            this.URLLabel.TabIndex = 18;
            this.URLLabel.Text = "URL";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(299, 106);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(39, 15);
            this.NameLabel.TabIndex = 17;
            this.NameLabel.Text = "Name";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(299, 199);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(57, 15);
            this.PasswordLabel.TabIndex = 16;
            this.PasswordLabel.Text = "Password";
            // 
            // CommentLabel
            // 
            this.CommentLabel.AutoSize = true;
            this.CommentLabel.Location = new System.Drawing.Point(299, 138);
            this.CommentLabel.Name = "CommentLabel";
            this.CommentLabel.Size = new System.Drawing.Size(33, 15);
            this.CommentLabel.TabIndex = 15;
            this.CommentLabel.Text = "Note";
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(403, 239);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(102, 23);
            this.DeleteButton.TabIndex = 24;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // FindButton
            // 
            this.FindButton.Location = new System.Drawing.Point(498, 97);
            this.FindButton.Name = "FindButton";
            this.FindButton.Size = new System.Drawing.Size(102, 23);
            this.FindButton.TabIndex = 25;
            this.FindButton.Text = "Find";
            this.FindButton.UseVisualStyleBackColor = true;
            this.FindButton.Click += new System.EventHandler(this.FindButton_Click);
            // 
            // EditPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.FindButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.URLTextBox);
            this.Controls.Add(this.NoteTextBox);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.URLLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.CommentLabel);
            this.Name = "EditPassword";
            this.Text = "Edit password";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox URLTextBox;
        private System.Windows.Forms.TextBox NoteTextBox;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label URLLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label CommentLabel;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button FindButton;
    }
}