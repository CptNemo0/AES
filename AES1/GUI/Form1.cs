using Cipher;
using System.Collections;
using System.Security.Cryptography;
using System.Text;
using System.Media;
using System.Windows.Forms;
using System.IO;

namespace GUI
{
    public partial class AES_Cipher_Tool : Form
    {
        private Utils slh;
        private Data data;
        private readonly string keyPath = "key.bin";
        private readonly string initialMessagePath = "message.bin";
        private readonly string encodedPath = "encoded.bin";
        private readonly string decodedPath = "decoded.bin";
        private readonly SoundPlayer hoodclassic;
        private readonly SoundPlayer awp;
        private readonly SoundPlayer damnson;
        private bool textinput = true;

        public AES_Cipher_Tool()
        {
            data = new Data();
            slh = new Utils();
            hoodclassic = new SoundPlayer("hoodclassic.wav");
            awp = new SoundPlayer("awp.wav");
            damnson = new SoundPlayer("damnson.wav");
            cleanFiles();
            InitializeComponent();
        }

        private void cleanFiles()
        {
            string nothing = String.Empty;

            using (BinaryWriter writer = new BinaryWriter(File.Open(keyPath, FileMode.Create)))
            {
                byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(nothing);
                writer.Write(byteArray);
            }

            using (BinaryWriter writer = new BinaryWriter(File.Open(initialMessagePath, FileMode.Create)))
            {
                byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(nothing);
                writer.Write(byteArray);
            }

            using (BinaryWriter writer = new BinaryWriter(File.Open(encodedPath, FileMode.Create)))
            {
                byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(nothing);
                writer.Write(byteArray);
            }

            using (BinaryWriter writer = new BinaryWriter(File.Open(decodedPath, FileMode.Create)))
            {
                byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(nothing);
                writer.Write(byteArray);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((data.getNk() == 4) || (data.getNk() == 6) || (data.getNk() == 8))
            {
                data.setCipherKey(slh.getCipherKey(data.getNk()));
                using (BinaryWriter writer = new BinaryWriter(File.Open(keyPath, FileMode.Create)))
                {
                    writer.Write(data.getCipherKey());
                }

                using (BinaryReader reader = new BinaryReader(File.Open(keyPath, FileMode.Open)))
                {
                    byte[] key = reader.ReadBytes((int)reader.BaseStream.Length);
                    keyBox.Text = System.Text.Encoding.UTF8.GetString(key);
                }
            }
        }

        private void lenBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lenBox.SelectedIndex == 0)
            {
                data.setNk(4);
            }
            else if (lenBox.SelectedIndex == 1)
            {
                data.setNk(6);
            }
            else if (lenBox.SelectedIndex == 2)
            {
                data.setNk(8);
            }
        }

        private void mainButton_Click(object sender, EventArgs e)
        {
            if (plaintextBox.Text.Length > 0)
            {
                awp.Play();

                using (BinaryReader reader = new BinaryReader(File.Open(keyPath, FileMode.Open)))
                {
                    byte[] key = reader.ReadBytes((int)reader.BaseStream.Length);
                    data.setNk(key.Length / 32);
                    data.setCipherKey(key);
                }

                data.setMessageString(plaintextBox.Text);

                using (BinaryWriter writer = new BinaryWriter(File.Open(initialMessagePath, FileMode.Create)))
                {
                    byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(data.getMessageString());
                    writer.Write(byteArray);
                }

                byte[] message_1;
                using (BinaryReader reader = new BinaryReader(File.Open(initialMessagePath, FileMode.Open)))
                {
                    message_1 = reader.ReadBytes((int)reader.BaseStream.Length);
                }

                using (BinaryWriter writer = new BinaryWriter(File.Open(encodedPath, FileMode.Create)))
                {
                    Cipher.AES ihavenoideaforname = new AES();
                    byte[] byteArray = ihavenoideaforname.encode(message_1, data.getCipherKey());
                    writer.Write(byteArray);
                    string strFromFile = System.Text.Encoding.UTF8.GetString(byteArray);
                    ciphertextBox.Text = strFromFile;
                }

                using (BinaryReader reader = new BinaryReader(File.Open(encodedPath, FileMode.Open)))
                {
                    byte[] byteArray = reader.ReadBytes((int)reader.BaseStream.Length);
                    string strFromFile = System.Text.Encoding.UTF8.GetString(byteArray);
                    ciphertextBox.Text = strFromFile;
                }
            }
        }

        private void decryptButton_Click(object sender, EventArgs e)
        {
            using (BinaryReader reader = new BinaryReader(File.Open(keyPath, FileMode.Open)))
            {
                byte[] key = reader.ReadBytes((int)reader.BaseStream.Length);
                data.setNk(key.Length / 4);
                data.setCipherKey(key);
            }

            if ((data.getNk()) == 4 || (data.getNk() == 6) || (data.getNk() == 8)) 
            {
                hoodclassic.Play();

                using (BinaryReader reader = new BinaryReader(File.Open(encodedPath, FileMode.Open)))
                {
                    byte[] message_1 = reader.ReadBytes((int)reader.BaseStream.Length);
                    data.setMessageCiphered(message_1);
                }

                plaintextBox.Text = "A";

                using (BinaryWriter writer = new BinaryWriter(File.Open(decodedPath, FileMode.Create)))
                {
                    AES ihavenoideaforname = new AES();
                    byte[] byteArray = ihavenoideaforname.decode(data.getMessageCiphered(), data.getCipherKey());
                    data.setMessageBytes(byteArray);
                    writer.Write(byteArray);
                }

                plaintextBox.Text = "B";

                textinput = false;

                using (MD5 md5 = MD5.Create())
                {
                    byte[] hashBytes = md5.ComputeHash(data.getMessageBytes());
                    string hashString = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
                    checksumBox.Text = hashString;
                }

                string message = Encoding.UTF8.GetString(data.getMessageBytes());
                plaintextBox.Text = message;
            }   
        }

        private void keyBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar >= 'a' && e.KeyChar <= 'f') || (e.KeyChar >= 'A' && e.KeyChar <= 'F')))
            {
                e.Handled = true;
            }
        }

        private void ciphertextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar >= 'a' && e.KeyChar <= 'f') || (e.KeyChar >= 'A' && e.KeyChar <= 'F')))
            {
                e.Handled = true;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save Key!";
            saveFileDialog.Filter = "Bin files (*.bin)|*.bin";
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog.FileName;

                using (BinaryReader reader = new BinaryReader(File.Open(keyPath, FileMode.Open)))
                {
                    byte[] key = reader.ReadBytes((int)reader.BaseStream.Length);
                    data.setCipherKey(key);
                }

                using (BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.Create)))
                {
                    writer.Write(data.getCipherKey());
                }
            }
        }

        private void savectButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save Ciphertext!";
            saveFileDialog.Filter = "Bin files (*.bin)|*.bin";
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog.FileName;

                using (BinaryReader reader = new BinaryReader(File.Open(encodedPath, FileMode.Open)))
                {
                    byte[] encoded = reader.ReadBytes((int)reader.BaseStream.Length);
                    data.setMessageCiphered(encoded);
                }

                using (BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.Create)))
                {
                    writer.Write(data.getMessageCiphered());
                }
            }
        }

        private void loadkButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Load Key!";
            openFileDialog.Filter = "Bin files (*.bin)|*.bin";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;

                using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
                {
                    byte[] key = reader.ReadBytes((int)reader.BaseStream.Length);
                    data.setCipherKey(key);
                }
            }

            using (BinaryWriter writer = new BinaryWriter(File.Open(keyPath, FileMode.Create)))
            {
                writer.Write(data.getCipherKey());
            }

            using (BinaryReader reader = new BinaryReader(File.Open(keyPath, FileMode.Open)))
            {
                byte[] key = reader.ReadBytes((int)reader.BaseStream.Length);
                keyBox.Text = System.Text.Encoding.UTF8.GetString(key);
            }
        }

        private void loadctButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Load Ciphertext!";
            openFileDialog.Filter = "Bin files (*.bin)|*.bin";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;

                using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
                {
                    byte[] ciphertext = reader.ReadBytes((int)reader.BaseStream.Length);
                    data.setMessageCiphered(ciphertext);
                }
            }

            using (BinaryWriter writer = new BinaryWriter(File.Open(encodedPath, FileMode.Create)))
            {
                byte[] byteArray = data.getMessageCiphered();
                writer.Write(byteArray);
                string strFromFile = System.Text.Encoding.UTF8.GetString(byteArray);
                ciphertextBox.Text = strFromFile;
            }
        }

        private void loadptButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Open File";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                byte[] imageData = File.ReadAllBytes(fileName);

                using (MD5 md5 = MD5.Create())
                {
                    byte[] hashBytes = md5.ComputeHash(imageData);
                    data.setMessageBytes(imageData);
                    string hashString = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
                    checksumBox.Text = hashString;
                }
                textinput = false;
            }
            damnson.Play();
            using (BinaryWriter writer = new BinaryWriter(File.Open(initialMessagePath, FileMode.Create)))
            {
                writer.Write(data.getMessageBytes());
            }

            string strFromFile = System.Text.Encoding.UTF8.GetString(data.getMessageBytes());
            plaintextBox.Text = strFromFile;
        }

        private void plaintextBox_TextChanged(object sender, EventArgs e)
        {
            if (textinput)
            {
                string input = plaintextBox.Text;
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);

                using (MD5 md5 = MD5.Create())
                {
                    byte[] hashBytes = md5.ComputeHash(inputBytes);
                    string hashString = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
                    checksumBox.Text = hashString;
                }
            }
            else
            {
                textinput = true;
            }
        }

        private void ciphertextBox_TextChanged(object sender, EventArgs e)
        {
            if (ciphertextBox.Text.Length > 0)
            {
                ciphertextBox.Enabled = true;
            }
        }

        private void cleanButton_Click(object sender, EventArgs e)
        {
            cleanFiles();
            data = new Data();
            textinput = true;
            ciphertextBox.Text = string.Empty;
            plaintextBox.Text = string.Empty;
            keyBox.Text = string.Empty;
            checksumBox.Text = string.Empty;
        }
    }
}