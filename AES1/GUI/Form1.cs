using AES1;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GUI
{
    public partial class AES_Cipher_Tool : Form
    {
        private Utils slh;
        private Data data;
        private Presentation pres;
        private AESCipher cipher;
        private AESDecipher decipher;
        public AES_Cipher_Tool()
        {
            data = new Data();
            slh = new Utils();
            pres = new Presentation();
            cipher = new AESCipher(slh);
            decipher = new AESDecipher(slh);
            InitializeComponent();

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == 0) 
            {
                lenBox.Enabled = true;
                lenBox.Visible = true;
            }
            else
            {
                lenBox.Enabled = false;
                lenBox.Visible = false;
                keyBox.Text = "";
                byte[] temp = new byte[1];
                temp[0] = 0;
                data.setCipherKey(temp);
                data.setNk(0);
            }
        }

        private void lenBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lenBox.SelectedIndex == 0)
            {
                byte[] key = slh.getCipherKey(4);
                data.setCipherKey(key);
                data.setNk(4);
                keyBox.Text = pres.ByteArrayToString(data.getCipherKey());
                encryptButton.Enabled = true;
            }
            else if(lenBox.SelectedIndex == 1)
            {
                byte[] key = slh.getCipherKey(6);
                data.setCipherKey(key);
                data.setNk(6);
                keyBox.Text = pres.ByteArrayToString(data.getCipherKey());
                encryptButton.Enabled = true;
            }
            else
            {
                byte[] key = slh.getCipherKey(8);
                data.setCipherKey(key);
                data.setNk(8);
                keyBox.Text = pres.ByteArrayToString(data.getCipherKey());
                encryptButton.Enabled = true;
            }
        }

        private void mainButton_Click(object sender, EventArgs e)
        {
            if(plaintextBox.Text.Length == 0)
            {
             //alert
            }
            else
            {
                ciphertextBox.Text = "";
                StringBuilder a = new StringBuilder();
                data.setStringBuilder(a);

                data.setMessageString(plaintextBox.Text);
                data.setMessageBytes(Encoding.Default.GetBytes(plaintextBox.Text));
                data.setKeyScheadule(slh.KeyExpansion(data.getCipherKey()));

                int length = 0;

                if((int)(data.getMessageBytes().Length / 16) == 0)
                {
                    length = 16;
                }
                else if((data.getMessageBytes().Length % 16) != 0)
                {
                    length = data.getMessageBytes().Length + 16;
                }
                else
                {
                    length = data.getMessageBytes().Length;
                }

                byte[] result = new byte[length];
                byte[] temp = new byte[length];
                byte[] block = new byte[16];

                for (int i = 0; i < length; i++)
                {
                    if (i < data.getMessageBytes().Length)
                    {
                        temp[i] = data.getMessageBytes()[i];
                    }
                    else
                    {
                        temp[i] = 0;
                    }
                }

                for(int i = 0; i < temp.Length / 16; i++)
                {
                    for(int j = 0; j < 16; j++)
                    {
                        block[j] = temp[i * 16 + j];
                    }

                    result = slh.StateToBlock(cipher.Cipher(slh.BlockToState(block), data.getKeyScheadule(), data.getNk()));
                    data.GetStringBuilder().Append(pres.ByteArrayToString(result));
                }

                ciphertextBox.Text = data.GetStringBuilder().ToString();
            }
        }

        private void decryptButton_Click(object sender, EventArgs e) 
        {
            if(ciphertextBox.Text.Length == 0)
            {
                //alert
            }
            else
            {
                plaintextBox.Text = "";
                StringBuilder a = new StringBuilder();

                data.setStringBuilder(a);
                if(ciphertextBox.Text.Length % 16 == 0)
                {
                    data.setCipherKey(pres.HexStringToByteArray(keyBox.Text));
                }
                else
                {
                    //alert
                }
                data.setNk(ciphertextBox.Text.Length / 8);
                plaintextBox.Text = data.getCipherKey().Length.ToString();
                data.setMessageString(ciphertextBox.Text);
                data.setMessageBytes(Encoding.Default.GetBytes(plaintextBox.Text));
                data.setKeyScheadule(slh.KeyExpansion(data.getCipherKey()));

                if(ciphertextBox.Text.Length % 16 == 0)
                {
                    data.setMessageCipheredString(ciphertextBox.Text);
                }
                else
                {
                    //alert
                }
                data.setMessageCiphered(pres.HexStringToByteArray(data.getMessageCipheredString()));

                byte[] result = new byte[data.getMessageCiphered().Length];
                byte[] block = new byte[16];

                for (int i = 0; i < data.getMessageCiphered().Length / 16; i++)
                {
                    for (int j = 0; j < 16; j++)
                    {
                        block[j] = data.getMessageCiphered()[i * 16 + j];
                    }

                    result = slh.StateToBlock(decipher.InvCipher(slh.BlockToState(block), data.getKeyScheadule(), data.getNk()));
                    data.GetStringBuilder().Append(pres.ByteArrayToString(result));
                }
                plaintextBox.Text = pres.HexStringToString(data.GetStringBuilder().ToString());
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
    }
}