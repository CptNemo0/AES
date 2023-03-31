namespace AES
{
    public class Data
    {
        private byte[] cipherKey;
        private string messageString;
        private byte[] messageBytes;
        private byte[] messageCiphered;
        private int Nk;


        public Data()
        {
            cipherKey = new byte[1];
            cipherKey[0] = 0;

            messageString = "Initialization";

            messageBytes = new byte[1];
            messageBytes[0] = 0;

            messageCiphered = new byte[1];
            messageCiphered[0] = 0;

            Nk = 4;
        }

        public byte[] getCipherKey()
        {
            return cipherKey;
        }

        public string getMessageString()
        {
            return messageString;
        }

        public byte[] getMessageBytes()
        {
            return messageBytes;
        }

        public byte[] getMessageCiphered()
        {
            return messageCiphered;
        }

        public int getNk()
        {
            return Nk;
        }


        public void setCipherKey(byte[] K)
        {
            this.cipherKey = K;
        }

        public void setMessageString(string message)
        {
            this.messageString = message;
        }

        public void setMessageBytes(byte[] messageBytes)
        {
            this.messageBytes = messageBytes;
        }

        public void setMessageCiphered(byte[] messageCiphered)
        {
            this.messageCiphered = messageCiphered;
        }

        public void setNk(int nk)
        {
            this.Nk = nk;
        }
    }
}
