using Cipher;
using System.Collections;
using System.Security.Cryptography;
using System.Text;
using System.Media;
using System.Windows.Forms;
using System.IO;
using System;

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
        private bool isFileMode = true;

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
                keyBox.Text = BitConverter.ToString(data.getCipherKey()).Replace("-", "");
                /*
                using (BinaryReader reader = new BinaryReader(File.Open(keyPath, FileMode.Open)))
                {
                    byte[] key = reader.ReadBytes((int)reader.BaseStream.Length);
                    keyBox.Text = System.Text.Encoding.UTF8.GetString(key);
                }
                */
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
            awp.Play();

            if (data.getCipherKey().Length == 1)
            {
                data.setNk(4);
                data.setCipherKey(slh.getCipherKey(4));
                keyBox.Text = BitConverter.ToString(data.getCipherKey()).Replace("-", "");
            }

            if (isFileMode)
            {
                int len = data.getMessageBytes().Length;

                if (len > 16)
                {
                    data.setInitialMessageLenght(len % 16);
                }
                else if (len < 16)
                {
                    data.setInitialMessageLenght(16 - len);
                }


                /*
                using (BinaryReader reader = new BinaryReader(File.Open(keyPath, FileMode.Open)))
                {
                    byte[] key = reader.ReadBytes((int)reader.BaseStream.Length);
                    data.setNk(key.Length / 32);
                    data.setCipherKey(key);
                }

                data.setMessageString(plaintextBox.Text);
                ////

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
                */


                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] hashValue = sha256.ComputeHash(data.getMessageBytes());
                    string hashString = BitConverter.ToString(hashValue).Replace("-", "");
                    checksumBox.Text = hashString;
                }


                using (BinaryWriter writer = new BinaryWriter(File.Open(encodedPath, FileMode.Create)))
                {
                    Cipher.AES ihavenoideaforname = new AES();
                    byte[] byteArray = ihavenoideaforname.encode(data.getMessageBytes(), data.getCipherKey());
                    writer.Write(byteArray);
                    data.setMessageCiphered(byteArray);
                    string strFromFile = BitConverter.ToString(data.getMessageCiphered()).Replace("-", "");
                    ciphertextBox.Text = strFromFile;
                }

                /*
                using (BinaryReader reader = new BinaryReader(File.Open(encodedPath, FileMode.Open)))
                {
                    byte[] byteArray = reader.ReadBytes((int)reader.BaseStream.Length);
                    string strFromFile = System.Text.Encoding.UTF8.GetString(byteArray);
                    ciphertextBox.Text = strFromFile;
                }
                */
            }
            else
            {
                data.setMessageString(plaintextBox.Text);

                using (BinaryWriter writer = new BinaryWriter(File.Open(initialMessagePath, FileMode.Create)))
                {
                    byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(data.getMessageString());
                    data.setMessageBytes(byteArray);
                    writer.Write(byteArray);
                }

                int len = data.getMessageBytes().Length;

                if (len > 16)
                {
                    data.setInitialMessageLenght(len % 16);
                }
                else if (len < 16)
                {
                    data.setInitialMessageLenght(16 - len);
                }

                /*
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] hashValue = sha256.ComputeHash(data.getMessageBytes());
                    string hashString = BitConverter.ToString(hashValue).Replace("-", "");
                    checksumBox.Text = hashString;
                }
                */

                using (BinaryWriter writer = new BinaryWriter(File.Open(encodedPath, FileMode.Create)))
                {
                    Cipher.AES ihavenoideaforname = new AES();
                    byte[] byteArray = ihavenoideaforname.encode(data.getMessageBytes(), data.getCipherKey());
                    writer.Write(byteArray);
                    data.setMessageCiphered(byteArray);
                    string strFromFile = BitConverter.ToString(data.getMessageCiphered()).Replace("-", "");
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

                using (BinaryWriter writer = new BinaryWriter(File.Open(decodedPath, FileMode.Create)))
                {
                    AES ihavenoideaforname = new AES();
                    byte[] byteArray = ihavenoideaforname.decode(data.getMessageCiphered(), data.getCipherKey());
                    // if we have encoded message of length 4 bytes it will return this message thus 4 bytes and 12 zeros appended to the end, fix it 

                    byte[] theactuallone = new byte[byteArray.Length - data.getInitialMessageLenght()];


                    for (int i = 0; i < theactuallone.Length; i++)
                    {
                        theactuallone[i] = byteArray[i];
                    }
                    

                    data.setMessageBytes(theactuallone);
                    writer.Write(theactuallone);
                }

                textinput = false;

                byte[] hashValue;
                using (SHA256 sha256 = SHA256.Create())
                {
                    hashValue = sha256.ComputeHash(data.getMessageBytes());
                    string hashString = BitConverter.ToString(hashValue).Replace("-", "");
                    checksumBox.Text = hashString;
                }

                //string message = BitConverter.ToString(data.getMessageBytes()).Replace("-", "");
                plaintextBox.Text = Encoding.UTF8.GetString(data.getMessageBytes());
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

            SaveFileDialog saveLenght = new SaveFileDialog();
            saveLenght.Title = "Save Lenght!";
            saveLenght.Filter = "Bin files (*.bin)|*.bin";
            saveLenght.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (saveLenght.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveLenght.FileName;

                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    writer.Write(data.getInitialMessageLenght());
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

            keyBox.Text = BitConverter.ToString(data.getCipherKey()).Replace("-", "");

            /*
            using (BinaryReader reader = new BinaryReader(File.Open(keyPath, FileMode.Open)))
            {
                byte[] key = reader.ReadBytes((int)reader.BaseStream.Length);
                keyBox.Text = System.Text.Encoding.UTF8.GetString(key);
            }
            */
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

            OpenFileDialog openFileDialogLen = new OpenFileDialog();
            openFileDialogLen.Title = "Load Lenght!";
            openFileDialogLen.Filter = "Bin files (*.bin)|*.bin";
            openFileDialogLen.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialogLen.Multiselect = false;

            if (openFileDialogLen.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialogLen.FileName;

                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line = reader.ReadLine();
                    data.setInitialMessageLenght(int.Parse(line));
                }
            }

            using (BinaryWriter writer = new BinaryWriter(File.Open(encodedPath, FileMode.Create)))
            {
                byte[] byteArray = data.getMessageCiphered();
                writer.Write(byteArray);
                ciphertextBox.Text = BitConverter.ToString(byteArray).Replace("-", "");
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
                data.setMessageBytes(File.ReadAllBytes(fileName));
            }

            damnson.Play();

            using (BinaryWriter writer = new BinaryWriter(File.Open(initialMessagePath, FileMode.Create)))
            {
                writer.Write(data.getMessageBytes());
            }

            plaintextBox.Text = BitConverter.ToString(data.getMessageBytes()).Replace("-", "");

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashValue = sha256.ComputeHash(data.getMessageBytes());
                string hashString = BitConverter.ToString(hashValue).Replace("-", "").ToLower();
                checksumBox.Text = hashString;
            }
        }

        private void plaintextBox_TextChanged(object sender, EventArgs e)
        {
            if(!isFileMode)
            {
                string input = plaintextBox.Text;
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                data.setMessageBytes(inputBytes);

                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] hashValue = sha256.ComputeHash(data.getMessageBytes());
                    string hashString = BitConverter.ToString(hashValue).Replace("-", "");
                    checksumBox.Text = hashString;
                }
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

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == 0)
            {
                //File Mode
                cleanFiles();
                data = new Data();
                textinput = true;
                ciphertextBox.Text = string.Empty;
                plaintextBox.Text = string.Empty;
                keyBox.Text = string.Empty;
                checksumBox.Text = string.Empty;

                plaintextBox.Enabled = false;
                loadptButton.Enabled = true;
                loadctButton.Enabled = true;
                isFileMode = true;
            }
            else if (listBox1.SelectedIndex == 1)
            {
                //Text Mode
                cleanFiles();
                data = new Data();
                textinput = true;
                ciphertextBox.Text = string.Empty;
                plaintextBox.Text = string.Empty;
                keyBox.Text = string.Empty;
                checksumBox.Text = string.Empty;

                plaintextBox.Enabled = true;
                loadptButton.Enabled = false;
                loadctButton.Enabled = false;
                isFileMode = false;
            }
        }
    }
}