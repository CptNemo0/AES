namespace GUI
{
    partial class AES_Cipher_Tool
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.plaintextBox = new System.Windows.Forms.TextBox();
            this.ciphertextBox = new System.Windows.Forms.TextBox();
            this.mainButton = new System.Windows.Forms.Button();
            this.keyBox = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // plaintextBox
            // 
            this.plaintextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(40)))));
            this.plaintextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.plaintextBox.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.plaintextBox.ForeColor = System.Drawing.Color.White;
            this.plaintextBox.Location = new System.Drawing.Point(90, 180);
            this.plaintextBox.MaximumSize = new System.Drawing.Size(420, 420);
            this.plaintextBox.MaxLength = 2000000;
            this.plaintextBox.MinimumSize = new System.Drawing.Size(420, 420);
            this.plaintextBox.Multiline = true;
            this.plaintextBox.Name = "plaintextBox";
            this.plaintextBox.PlaceholderText = "Plaintext ";
            this.plaintextBox.Size = new System.Drawing.Size(420, 420);
            this.plaintextBox.TabIndex = 0;
            this.plaintextBox.Tag = "plaintextBox";
            // 
            // ciphertextBox
            // 
            this.ciphertextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(40)))));
            this.ciphertextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ciphertextBox.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ciphertextBox.ForeColor = System.Drawing.Color.White;
            this.ciphertextBox.Location = new System.Drawing.Point(770, 180);
            this.ciphertextBox.MaximumSize = new System.Drawing.Size(420, 420);
            this.ciphertextBox.MaxLength = 2000000;
            this.ciphertextBox.MinimumSize = new System.Drawing.Size(420, 420);
            this.ciphertextBox.Multiline = true;
            this.ciphertextBox.Name = "ciphertextBox";
            this.ciphertextBox.PlaceholderText = "Cipher text";
            this.ciphertextBox.Size = new System.Drawing.Size(420, 420);
            this.ciphertextBox.TabIndex = 1;
            this.ciphertextBox.Tag = "plaintextBox";
            // 
            // mainButton
            // 
            this.mainButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(40)))));
            this.mainButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.mainButton.FlatAppearance.BorderSize = 2;
            this.mainButton.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.mainButton.ForeColor = System.Drawing.Color.White;
            this.mainButton.Location = new System.Drawing.Point(575, 295);
            this.mainButton.Name = "mainButton";
            this.mainButton.Size = new System.Drawing.Size(130, 130);
            this.mainButton.TabIndex = 2;
            this.mainButton.Text = "Encrypt / Decrypt";
            this.mainButton.UseVisualStyleBackColor = false;
            // 
            // keyBox
            // 
            this.keyBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(40)))));
            this.keyBox.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.keyBox.Location = new System.Drawing.Point(90, 118);
            this.keyBox.Multiline = true;
            this.keyBox.Name = "keyBox";
            this.keyBox.PlaceholderText = "Cipher Key";
            this.keyBox.Size = new System.Drawing.Size(420, 24);
            this.keyBox.TabIndex = 3;
            this.keyBox.Tag = "keyBox";
            this.keyBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(40)))));
            this.listBox1.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listBox1.ForeColor = System.Drawing.Color.White;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 17;
            this.listBox1.Items.AddRange(new object[] {
            "Generate key",
            "Use your own key"});
            this.listBox1.Location = new System.Drawing.Point(90, 36);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(166, 38);
            this.listBox1.TabIndex = 4;
            // 
            // AES_Cipher_Tool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.keyBox);
            this.Controls.Add(this.mainButton);
            this.Controls.Add(this.ciphertextBox);
            this.Controls.Add(this.plaintextBox);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(325, 180);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(1280, 720);
            this.MinimumSize = new System.Drawing.Size(1280, 720);
            this.Name = "AES_Cipher_Tool";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "window";
            this.Text = "AES Cipher Tool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox plaintextBox;
        private TextBox ciphertextBox;
        private Button mainButton;
        private TextBox keyBox;
        private ListBox listBox1;
    }
}