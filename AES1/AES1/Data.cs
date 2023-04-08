namespace Cipher
{
    public class Data
    {
        private byte[] cipherKey;
        private byte[] messageBytes;
        private byte[] messageCiphered;
        private string messageString;
        private int initialMessageLenght;
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

            initialMessageLenght = 0;
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

        public int getInitialMessageLenght()
        {
            return initialMessageLenght;
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
    
        public void setInitialMessageLenght(int  initialMessageLenght)
        {
            this.initialMessageLenght = initialMessageLenght;
        }
    }
}
