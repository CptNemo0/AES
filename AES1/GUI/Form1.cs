using Cipher;
using System.Collections;
using System.Security.Cryptography;
using System.Text;
using System.Media;
using System.Windows.Forms;

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

        public AES_Cipher_Tool()
        {
            data = new Data();
            slh = new Utils();
            hoodclassic = new SoundPlayer("hoodclassic.wav");
            awp = new SoundPlayer("awp.wav");
            damnson = new SoundPlayer("damnson.wav");
            InitializeComponent();
            plaintextBox.TextChanged += plaintextBox_TextChanged;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
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
            
;            if (plaintextBox.Text.Length > 0)
            {
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
                awp.Play();
            }
        }

        private void decryptButton_Click(object sender, EventArgs e)
        {
             hoodclassic.Play();

            using (BinaryReader reader = new BinaryReader(File.Open(keyPath, FileMode.Open)))
            {
                byte[] key = reader.ReadBytes((int)reader.BaseStream.Length);
                data.setNk(key.Length / 32);
                data.setCipherKey(key);
            }

            using (BinaryReader reader = new BinaryReader(File.Open(encodedPath, FileMode.Open)))
            {
                byte[] message_1 = reader.ReadBytes((int)reader.BaseStream.Length);
                data.setMessageCiphered(message_1);
            }

            using (BinaryWriter writer = new BinaryWriter(File.Open(decodedPath, FileMode.Create)))
            {
                Cipher.AES ihavenoideaforname = new AES();
                byte[] byteArray = ihavenoideaforname.decode(data.getMessageCiphered(), data.getCipherKey());
                data.setMessageBytes(byteArray);
                writer.Write(byteArray);
            }

            using (BinaryReader reader = new BinaryReader(File.Open(decodedPath, FileMode.Open)))
            {
                byte[] byteArray = reader.ReadBytes((int)reader.BaseStream.Length);
                string strFromFile = System.Text.Encoding.UTF8.GetString(byteArray);
                plaintextBox.Text = strFromFile;

 
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
            openFileDialog.Title = "Load Plaintext";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                data.setMessageBytes(File.ReadAllBytes(fileName));
            }

            using (BinaryWriter writer = new BinaryWriter(File.Open(initialMessagePath, FileMode.Create)))
            {
                writer.Write(data.getMessageBytes());
            }

            string strFromFile = System.Text.Encoding.UTF8.GetString(data.getMessageBytes());
            plaintextBox.Text = strFromFile;

            damnson.Play();
        }

        private void plaintextBox_TextChanged(object sender, EventArgs e)
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
    }
}