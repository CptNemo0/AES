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
            saveButton = new Button();
            savectButton = new Button();
            loadkButton = new Button();
            loadctButton = new Button();
            genkButton = new Button();
            loadptButton = new Button();
            checksumBox = new TextBox();
            cleanButton = new Button();
            SuspendLayout();
            // 
            // plaintextBox
            // 
            plaintextBox.AllowDrop = true;
            plaintextBox.BackColor = Color.FromArgb(34, 34, 40);
            plaintextBox.Cursor = Cursors.IBeam;
            plaintextBox.Font = new Font("Arial", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            plaintextBox.ForeColor = Color.White;
            plaintextBox.Location = new Point(90, 180);
            plaintextBox.MaximumSize = new Size(420, 390);
            plaintextBox.MaxLength = 65535;
            plaintextBox.MinimumSize = new Size(420, 390);
            plaintextBox.Multiline = true;
            plaintextBox.Name = "plaintextBox";
            plaintextBox.PlaceholderText = "Plaintext ";
            plaintextBox.ScrollBars = ScrollBars.Both;
            plaintextBox.Size = new Size(420, 390);
            plaintextBox.TabIndex = 0;
            plaintextBox.Tag = "plaintextBox";
            plaintextBox.TextChanged += plaintextBox_TextChanged;
            // 
            // ciphertextBox
            // 
            ciphertextBox.BackColor = Color.FromArgb(34, 34, 40);
            ciphertextBox.Cursor = Cursors.IBeam;
            ciphertextBox.Enabled = false;
            ciphertextBox.Font = new Font("Arial", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            ciphertextBox.ForeColor = Color.White;
            ciphertextBox.Location = new Point(770, 180);
            ciphertextBox.MaximumSize = new Size(420, 420);
            ciphertextBox.MaxLength = 2000000;
            ciphertextBox.MinimumSize = new Size(420, 420);
            ciphertextBox.Multiline = true;
            ciphertextBox.Name = "ciphertextBox";
            ciphertextBox.PlaceholderText = "Cipher text";
            ciphertextBox.ReadOnly = true;
            ciphertextBox.Size = new Size(420, 420);
            ciphertextBox.TabIndex = 1;
            ciphertextBox.Tag = "plaintextBox";
            ciphertextBox.TextChanged += ciphertextBox_TextChanged;
            ciphertextBox.KeyPress += ciphertextBox_KeyPress;
            // 
            // encryptButton
            // 
            encryptButton.BackColor = Color.FromArgb(34, 34, 40);
            encryptButton.FlatAppearance.BorderColor = Color.FromArgb(147, 172, 201);
            encryptButton.FlatAppearance.BorderSize = 3;
            encryptButton.FlatStyle = FlatStyle.Flat;
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
            keyBox.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            keyBox.ForeColor = Color.White;
            keyBox.Location = new Point(310, 130);
            keyBox.Multiline = true;
            keyBox.Name = "keyBox";
            keyBox.PlaceholderText = "Cipher Key";
            keyBox.Size = new Size(660, 24);
            keyBox.TabIndex = 3;
            keyBox.Tag = "keyBox";
            keyBox.TextAlign = HorizontalAlignment.Center;
            keyBox.KeyPress += keyBox_KeyPress;
            // 
            // lenBox
            // 
            lenBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lenBox.BackColor = Color.FromArgb(34, 34, 40);
            lenBox.ColumnWidth = 60;
            lenBox.Font = new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Point);
            lenBox.ForeColor = Color.White;
            lenBox.FormattingEnabled = true;
            lenBox.ItemHeight = 17;
            lenBox.Items.AddRange(new object[] { "128 bit", "192 bit", "256 bit" });
            lenBox.Location = new Point(405, 53);
            lenBox.Margin = new Padding(0);
            lenBox.Name = "lenBox";
            lenBox.Size = new Size(90, 55);
            lenBox.TabIndex = 5;
            lenBox.SelectedIndexChanged += lenBox_SelectedIndexChanged;
            // 
            // decryptButton
            // 
            decryptButton.BackColor = Color.FromArgb(34, 34, 40);
            decryptButton.FlatAppearance.BorderColor = Color.FromArgb(147, 172, 201);
            decryptButton.FlatAppearance.BorderSize = 3;
            decryptButton.FlatStyle = FlatStyle.Flat;
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
            // saveButton
            // 
            saveButton.BackColor = Color.FromArgb(34, 34, 40);
            saveButton.FlatAppearance.BorderColor = Color.FromArgb(147, 172, 201);
            saveButton.FlatAppearance.BorderSize = 3;
            saveButton.FlatStyle = FlatStyle.Flat;
            saveButton.Font = new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Point);
            saveButton.ForeColor = Color.White;
            saveButton.Location = new Point(595, 53);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(90, 55);
            saveButton.TabIndex = 8;
            saveButton.Text = "Save Key";
            saveButton.UseVisualStyleBackColor = false;
            saveButton.Click += saveButton_Click;
            // 
            // savectButton
            // 
            savectButton.BackColor = Color.FromArgb(34, 34, 40);
            savectButton.FlatAppearance.BorderColor = Color.FromArgb(147, 172, 201);
            savectButton.FlatAppearance.BorderSize = 3;
            savectButton.FlatStyle = FlatStyle.Flat;
            savectButton.Font = new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Point);
            savectButton.ForeColor = Color.White;
            savectButton.Location = new Point(785, 53);
            savectButton.Name = "savectButton";
            savectButton.Size = new Size(90, 55);
            savectButton.TabIndex = 9;
            savectButton.Text = "Save Cipher text";
            savectButton.UseVisualStyleBackColor = false;
            savectButton.Click += savectButton_Click;
            // 
            // loadkButton
            // 
            loadkButton.BackColor = Color.FromArgb(34, 34, 40);
            loadkButton.FlatAppearance.BorderColor = Color.FromArgb(147, 172, 201);
            loadkButton.FlatAppearance.BorderSize = 3;
            loadkButton.FlatStyle = FlatStyle.Flat;
            loadkButton.Font = new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Point);
            loadkButton.ForeColor = Color.White;
            loadkButton.Location = new Point(690, 53);
            loadkButton.Name = "loadkButton";
            loadkButton.Size = new Size(90, 55);
            loadkButton.TabIndex = 10;
            loadkButton.Text = "Load Key";
            loadkButton.UseVisualStyleBackColor = false;
            loadkButton.Click += loadkButton_Click;
            // 
            // loadctButton
            // 
            loadctButton.BackColor = Color.FromArgb(34, 34, 40);
            loadctButton.FlatAppearance.BorderColor = Color.FromArgb(147, 172, 201);
            loadctButton.FlatAppearance.BorderSize = 3;
            loadctButton.FlatStyle = FlatStyle.Flat;
            loadctButton.Font = new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Point);
            loadctButton.ForeColor = Color.White;
            loadctButton.Location = new Point(880, 53);
            loadctButton.Name = "loadctButton";
            loadctButton.Size = new Size(90, 55);
            loadctButton.TabIndex = 11;
            loadctButton.Text = "Load Cipher text";
            loadctButton.UseVisualStyleBackColor = false;
            loadctButton.Click += loadctButton_Click;
            // 
            // genkButton
            // 
            genkButton.BackColor = Color.FromArgb(34, 34, 40);
            genkButton.FlatAppearance.BorderColor = Color.FromArgb(147, 172, 201);
            genkButton.FlatAppearance.BorderSize = 3;
            genkButton.FlatStyle = FlatStyle.Flat;
            genkButton.Font = new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Point);
            genkButton.ForeColor = Color.White;
            genkButton.Location = new Point(310, 53);
            genkButton.Name = "genkButton";
            genkButton.Size = new Size(90, 55);
            genkButton.TabIndex = 12;
            genkButton.Text = "Generate Key";
            genkButton.UseVisualStyleBackColor = false;
            genkButton.Click += listBox1_SelectedIndexChanged;
            // 
            // loadptButton
            // 
            loadptButton.BackColor = Color.FromArgb(34, 34, 40);
            loadptButton.FlatAppearance.BorderColor = Color.FromArgb(147, 172, 201);
            loadptButton.FlatAppearance.BorderSize = 3;
            loadptButton.FlatStyle = FlatStyle.Flat;
            loadptButton.Font = new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Point);
            loadptButton.ForeColor = Color.White;
            loadptButton.Location = new Point(500, 53);
            loadptButton.Name = "loadptButton";
            loadptButton.Size = new Size(90, 55);
            loadptButton.TabIndex = 13;
            loadptButton.Text = "Load Plaintext";
            loadptButton.UseVisualStyleBackColor = false;
            loadptButton.Click += loadptButton_Click;
            // 
            // checksumBox
            // 
            checksumBox.BackColor = Color.FromArgb(34, 34, 40);
            checksumBox.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            checksumBox.ForeColor = Color.White;
            checksumBox.Location = new Point(90, 576);
            checksumBox.Multiline = true;
            checksumBox.Name = "checksumBox";
            checksumBox.PlaceholderText = "Checksum";
            checksumBox.Size = new Size(420, 24);
            checksumBox.TabIndex = 14;
            checksumBox.Tag = "checksumBox";
            checksumBox.TextAlign = HorizontalAlignment.Center;
            // 
            // cleanButton
            // 
            cleanButton.BackColor = Color.FromArgb(34, 34, 40);
            cleanButton.FlatAppearance.BorderColor = Color.FromArgb(147, 172, 201);
            cleanButton.FlatAppearance.BorderSize = 3;
            cleanButton.FlatStyle = FlatStyle.Flat;
            cleanButton.Font = new Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Point);
            cleanButton.ForeColor = Color.White;
            cleanButton.Location = new Point(575, 409);
            cleanButton.Name = "cleanButton";
            cleanButton.Size = new Size(130, 51);
            cleanButton.TabIndex = 15;
            cleanButton.Text = "Clean";
            cleanButton.UseVisualStyleBackColor = false;
            cleanButton.Click += cleanButton_Click;
            // 
            // AES_Cipher_Tool
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(35, 35, 43);
            ClientSize = new Size(1264, 681);
            Controls.Add(cleanButton);
            Controls.Add(checksumBox);
            Controls.Add(loadptButton);
            Controls.Add(genkButton);
            Controls.Add(loadctButton);
            Controls.Add(loadkButton);
            Controls.Add(savectButton);
            Controls.Add(saveButton);
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
        private Button saveButton;
        private Button savectButton;
        private Button loadkButton;
        private Button loadctButton;
        private Button genkButton;
        private Button loadptButton;
        private TextBox checksumBox;
        private Button cleanButton;
    }
}