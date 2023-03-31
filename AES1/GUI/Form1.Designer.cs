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
            plaintextBox = new TextBox();
            ciphertextBox = new TextBox();
            encryptButton = new Button();
            keyBox = new TextBox();
            lenBox = new ListBox();
            decryptButton = new Button();
            button1 = new Button();
            saveButton = new Button();
            savectButton = new Button();
            loadkButton = new Button();
            loadctButton = new Button();
            genkButton = new Button();
            loadptButton = new Button();
            SuspendLayout();
            // 
            // plaintextBox
            // 
            plaintextBox.BackColor = Color.FromArgb(34, 34, 40);
            plaintextBox.Cursor = Cursors.IBeam;
            plaintextBox.Font = new Font("Arial", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            plaintextBox.ForeColor = Color.White;
            plaintextBox.Location = new Point(90, 180);
            plaintextBox.MaximumSize = new Size(420, 420);
            plaintextBox.MaxLength = 2000000;
            plaintextBox.MinimumSize = new Size(420, 420);
            plaintextBox.Multiline = true;
            plaintextBox.Name = "plaintextBox";
            plaintextBox.PlaceholderText = "Plaintext ";
            plaintextBox.Size = new Size(420, 420);
            plaintextBox.TabIndex = 0;
            plaintextBox.Tag = "plaintextBox";
            // 
            // ciphertextBox
            // 
            ciphertextBox.BackColor = Color.FromArgb(34, 34, 40);
            ciphertextBox.Cursor = Cursors.IBeam;
            ciphertextBox.Font = new Font("Arial", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            ciphertextBox.ForeColor = Color.White;
            ciphertextBox.Location = new Point(770, 180);
            ciphertextBox.MaximumSize = new Size(420, 420);
            ciphertextBox.MaxLength = 2000000;
            ciphertextBox.MinimumSize = new Size(420, 420);
            ciphertextBox.Multiline = true;
            ciphertextBox.Name = "ciphertextBox";
            ciphertextBox.PlaceholderText = "Cipher text";
            ciphertextBox.Size = new Size(420, 420);
            ciphertextBox.TabIndex = 1;
            ciphertextBox.Tag = "plaintextBox";
            ciphertextBox.KeyPress += ciphertextBox_KeyPress;
            // 
            // encryptButton
            // 
            encryptButton.BackColor = Color.FromArgb(34, 34, 40);
            encryptButton.FlatAppearance.BorderColor = Color.Black;
            encryptButton.FlatAppearance.BorderSize = 2;
            encryptButton.Font = new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Point);
            encryptButton.ForeColor = Color.White;
            encryptButton.Location = new Point(575, 295);
            encryptButton.Name = "encryptButton";
            encryptButton.Size = new Size(130, 51);
            encryptButton.TabIndex = 2;
            encryptButton.Text = "Encrypt";
            encryptButton.UseVisualStyleBackColor = false;
            encryptButton.Click += mainButton_Click;
            // 
            // keyBox
            // 
            keyBox.BackColor = Color.FromArgb(34, 34, 40);
            keyBox.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            keyBox.ForeColor = Color.White;
            keyBox.Location = new Point(314, 122);
            keyBox.Multiline = true;
            keyBox.Name = "keyBox";
            keyBox.PlaceholderText = "Cipher Key";
            keyBox.Size = new Size(659, 24);
            keyBox.TabIndex = 3;
            keyBox.Tag = "keyBox";
            keyBox.TextAlign = HorizontalAlignment.Center;
            keyBox.KeyPress += keyBox_KeyPress;
            // 
            // lenBox
            // 
            lenBox.BackColor = Color.FromArgb(34, 34, 40);
            lenBox.ColumnWidth = 60;
            lenBox.Font = new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Point);
            lenBox.ForeColor = Color.White;
            lenBox.FormattingEnabled = true;
            lenBox.ItemHeight = 17;
            lenBox.Items.AddRange(new object[] { "128 bit", "192 bit", "256 bit" });
            lenBox.Location = new Point(410, 53);
            lenBox.Margin = new Padding(0);
            lenBox.Name = "lenBox";
            lenBox.Size = new Size(71, 55);
            lenBox.TabIndex = 5;
            lenBox.SelectedIndexChanged += lenBox_SelectedIndexChanged;
            // 
            // decryptButton
            // 
            decryptButton.BackColor = Color.FromArgb(34, 34, 40);
            decryptButton.FlatAppearance.BorderColor = Color.Black;
            decryptButton.FlatAppearance.BorderSize = 2;
            decryptButton.Font = new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Point);
            decryptButton.ForeColor = Color.White;
            decryptButton.Location = new Point(575, 352);
            decryptButton.Name = "decryptButton";
            decryptButton.Size = new Size(130, 51);
            decryptButton.TabIndex = 6;
            decryptButton.Text = "Decrypt";
            decryptButton.UseVisualStyleBackColor = false;
            decryptButton.Click += decryptButton_Click;
            // 
            // button1
            // 
            button1.Location = new Point(603, 266);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 7;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // saveButton
            // 
            saveButton.BackColor = Color.FromArgb(34, 34, 40);
            saveButton.FlatAppearance.BorderColor = Color.Black;
            saveButton.FlatAppearance.BorderSize = 2;
            saveButton.Font = new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Point);
            saveButton.ForeColor = Color.White;
            saveButton.Location = new Point(583, 53);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(93, 55);
            saveButton.TabIndex = 8;
            saveButton.Text = "Save Key";
            saveButton.UseVisualStyleBackColor = false;
            saveButton.Click += saveButton_Click;
            // 
            // savectButton
            // 
            savectButton.BackColor = Color.FromArgb(34, 34, 40);
            savectButton.FlatAppearance.BorderColor = Color.Black;
            savectButton.FlatAppearance.BorderSize = 2;
            savectButton.Font = new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Point);
            savectButton.ForeColor = Color.White;
            savectButton.Location = new Point(781, 53);
            savectButton.Name = "savectButton";
            savectButton.Size = new Size(93, 55);
            savectButton.TabIndex = 9;
            savectButton.Text = "Save Cipher text";
            savectButton.UseVisualStyleBackColor = false;
            savectButton.Click += savectButton_Click;
            // 
            // loadkButton
            // 
            loadkButton.BackColor = Color.FromArgb(34, 34, 40);
            loadkButton.FlatAppearance.BorderColor = Color.Black;
            loadkButton.FlatAppearance.BorderSize = 2;
            loadkButton.Font = new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Point);
            loadkButton.ForeColor = Color.White;
            loadkButton.Location = new Point(682, 53);
            loadkButton.Name = "loadkButton";
            loadkButton.Size = new Size(93, 55);
            loadkButton.TabIndex = 10;
            loadkButton.Text = "Load Key";
            loadkButton.UseVisualStyleBackColor = false;
            loadkButton.Click += loadkButton_Click;
            // 
            // loadctButton
            // 
            loadctButton.BackColor = Color.FromArgb(34, 34, 40);
            loadctButton.FlatAppearance.BorderColor = Color.Black;
            loadctButton.FlatAppearance.BorderSize = 2;
            loadctButton.Font = new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Point);
            loadctButton.ForeColor = Color.White;
            loadctButton.Location = new Point(880, 53);
            loadctButton.Name = "loadctButton";
            loadctButton.Size = new Size(93, 55);
            loadctButton.TabIndex = 11;
            loadctButton.Text = "Load Cipher text";
            loadctButton.UseVisualStyleBackColor = false;
            loadctButton.Click += loadctButton_Click;
            // 
            // genkButton
            // 
            genkButton.BackColor = Color.FromArgb(34, 34, 40);
            genkButton.FlatAppearance.BorderColor = Color.Black;
            genkButton.FlatAppearance.BorderSize = 2;
            genkButton.Font = new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Point);
            genkButton.ForeColor = Color.White;
            genkButton.Location = new Point(314, 53);
            genkButton.Name = "genkButton";
            genkButton.Size = new Size(93, 55);
            genkButton.TabIndex = 12;
            genkButton.Text = "Generate Key";
            genkButton.UseVisualStyleBackColor = false;
            genkButton.Click += listBox1_SelectedIndexChanged;
            // 
            // loadptButton
            // 
            loadptButton.BackColor = Color.FromArgb(34, 34, 40);
            loadptButton.FlatAppearance.BorderColor = Color.Black;
            loadptButton.FlatAppearance.BorderSize = 2;
            loadptButton.Font = new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Point);
            loadptButton.ForeColor = Color.White;
            loadptButton.Location = new Point(484, 53);
            loadptButton.Name = "loadptButton";
            loadptButton.Size = new Size(93, 55);
            loadptButton.TabIndex = 13;
            loadptButton.Text = "Load Plaintext";
            loadptButton.UseVisualStyleBackColor = false;
            loadptButton.Click += loadptButton_Click;
            // 
            // AES_Cipher_Tool
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 26, 32);
            ClientSize = new Size(1264, 681);
            Controls.Add(loadptButton);
            Controls.Add(genkButton);
            Controls.Add(loadctButton);
            Controls.Add(loadkButton);
            Controls.Add(savectButton);
            Controls.Add(saveButton);
            Controls.Add(button1);
            Controls.Add(decryptButton);
            Controls.Add(lenBox);
            Controls.Add(keyBox);
            Controls.Add(encryptButton);
            Controls.Add(ciphertextBox);
            Controls.Add(plaintextBox);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Location = new Point(325, 180);
            Margin = new Padding(4);
            MaximumSize = new Size(1280, 720);
            MinimumSize = new Size(1280, 720);
            Name = "AES_Cipher_Tool";
            StartPosition = FormStartPosition.CenterScreen;
            Tag = "window";
            Text = "AES Cipher Tool";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox plaintextBox;
        private TextBox ciphertextBox;
        private Button encryptButton;
        private TextBox keyBox;
        private ListBox lenBox;
        private Button decryptButton;
        private Button button1;
        private Button saveButton;
        private Button savectButton;
        private Button loadkButton;
        private Button loadctButton;
        private Button genkButton;
        private Button loadptButton;
    }
}