using AES1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public class Data
    {
        private byte[] cipherKey;
        private string messageString;
        private byte[] messageBytes;
        private byte[] messageCiphered;
        private string messageCipheredString;
        private int Nk;
        private Word[] KeyScheadule;
        private StringBuilder stringBuilder;

        public Data()
        { 
            cipherKey = new byte[1];
            cipherKey[0] = 0;

            messageString = "Initialization";

            messageBytes = new byte[1];
            messageBytes[0] = 0;

            messageCiphered = new byte[1];
            messageCiphered[0] = 0;

            Nk = 0;
            KeyScheadule = new Word[1];

            messageCipheredString = "Initialization";

            stringBuilder = new StringBuilder();
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

        public Word[] getKeyScheadule()
        {
            return KeyScheadule;
        }

        public string getMessageCipheredString()
        {
            return messageCipheredString;
        }

        public StringBuilder GetStringBuilder()
        {
            return this.stringBuilder;
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
   
        public void setKeyScheadule(Word[] ks)
        {
            this.KeyScheadule = ks;
        }
    
        public void setMessageCipheredString(string m)
        {
            this.messageCipheredString = m;
        }
    
        public void setStringBuilder(StringBuilder a)
        {
            this.stringBuilder = a;
        }
    }
}
