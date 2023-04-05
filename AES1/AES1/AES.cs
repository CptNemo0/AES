namespace Cipher
{
    public class AES
    {
        public byte[] encode(byte[] message_bytes, byte[] K)
        {
            if (message_bytes.Length == 0)
            {
                throw new ArgumentException("Message.Length = 0");
            }

            if ((K.Length != 16) && (K.Length != 24) && (K.Length != 32))
            {
                throw new ArgumentException("K.Length is not valid");
            }

            int Nk = K.Length / 4;
            int Nb = 4;
            int Nr = Nk + Nb + 2;

            Utils sln = new Utils();
            AESCipher cipher = new AESCipher(sln);
            Word[] KeyScheadule = sln.KeyExpansion(K);

            int length = 0;
            int helpper_length = message_bytes.Length / 16;

            if (helpper_length == 0)
            {
                length = 16;
            }
            else if (((message_bytes.Length % 16) != 0))
            {
                length = 16 * (helpper_length + 1);
            }
            else
            {
                length = 16 * helpper_length;
            }

            byte[] temp = new byte[length];
            byte[] block = new byte[16];
            byte[] result = new byte[length];

            for (int i = 0; i < length; i++)
            {
                if (message_bytes.Length > i)
                {
                    temp[i] = message_bytes[i];
                }
                else
                {
                    temp[i] = 0;
                }
            }

            byte[][] divided = new byte[length / 16][];

            for (int i = 0; i < length / 16; i++)
            {
                divided[i] = new byte[16];
                Array.Copy(temp, i * 16, divided[i], 0, 16);
            }

            for (int i = 0; i < length / 16; i++)
            {
                block = divided[i];

                byte[,] state = sln.BlockToState(block);

                byte[,] encryptedState = cipher.Cipher(state, KeyScheadule, Nk);

                byte[] encryptedBlock = sln.StateToBlock(encryptedState);

                Array.Copy(encryptedBlock, 0, result, i * 16, 16);
            }
            return result;
        }

        public byte[] decode(byte[] message_bytes, byte[] K)
        {
            if (message_bytes.Length == 0)
            {
                throw new ArgumentException("message_bytes.Length = 0");
            }

            if ((K.Length != 16) && (K.Length != 24) && (K.Length != 32))
            {
                throw new ArgumentException("K.Length is not valid");
            }

            int Nk = K.Length / 4;
            int Nb = 4;
            int Nr = Nk + Nb + 2;

            Utils sln = new Utils();
            AESDecipher decipher = new AESDecipher(sln);
            Word[] KeyScheadule = sln.KeyExpansion(K);

            int length = 0;
            int helpper_length = message_bytes.Length / 16;

            if (helpper_length == 0)
            {
                length = 16;
            }
            else if (((message_bytes.Length % 16) != 0))
            {
                length = 16 * (helpper_length + 1);
            }
            else
            {
                length = 16 * helpper_length;
            }

            byte[] temp = new byte[length];
            byte[] block = new byte[16];
            byte[] result = new byte[length];

            for (int i = 0; i < length; i++)
            {
                if (message_bytes.Length > i)
                {
                    temp[i] = message_bytes[i];
                }
                else
                {
                    temp[i] = 0;
                }
            }

            byte[][] divided = new byte[length / 16][];

            for (int i = 0; i < length / 16; i++)
            {
                divided[i] = new byte[16];
                Array.Copy(temp, i * 16, divided[i], 0, 16);
            }

            for (int i = 0; i < length / 16; i++)
            {
                block = divided[i];

                byte[,] state = sln.BlockToState(block);

                byte[,] encryptedState = decipher.InvCipher(state, KeyScheadule, Nk);

                byte[] encryptedBlock = sln.StateToBlock(encryptedState);

                Array.Copy(encryptedBlock, 0, result, i * 16, 16);
            }
            return result;
        }
    }
}
