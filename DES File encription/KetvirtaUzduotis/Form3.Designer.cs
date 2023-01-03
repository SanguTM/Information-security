
namespace KetvirtaUzduotis
{
    partial class Menu
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
            this.NewPasswordButton = new System.Windows.Forms.Button();
            this.EditPasswordButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NewPasswordButton
            // 
            this.NewPasswordButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NewPasswordButton.Location = new System.Drawing.Point(170, 139);
            this.NewPasswordButton.Name = "NewPasswordButton";
            this.NewPasswordButton.Size = new System.Drawing.Size(169, 81);
            this.NewPasswordButton.TabIndex = 0;
            this.NewPasswordButton.Text = "New Password";
            this.NewPasswordButton.UseVisualStyleBackColor = true;
            this.NewPasswordButton.Click += new System.EventHandler(this.NewPasswordButton_Click);
            // 
            // EditPasswordButton
            // 
            this.EditPasswordButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.EditPasswordButton.Location = new System.Drawing.Point(405, 139);
            this.EditPasswordButton.Name = "EditPasswordButton";
            this.EditPasswordButton.Size = new System.Drawing.Size(169, 81);
            this.EditPasswordButton.TabIndex = 1;
            this.EditPasswordButton.Text = "Edit Password";
            this.EditPasswordButton.UseVisualStyleBackColor = true;
            this.EditPasswordButton.Click += new System.EventHandler(this.EditPasswordButton_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.EditPasswordButton);
            this.Controls.Add(this.NewPasswordButton);
            this.Name = "Menu";
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button NewPasswordButton;
        private System.Windows.Forms.Button EditPasswordButton;
    }
}