namespace AES
{
    public class Word
    {
        public byte[] w;
        public Word(byte b0, byte b1, byte b2, byte b3)
        {
            w = new byte[4];
            w[0] = b0;
            w[1] = b1;
            w[2] = b2;
            w[3] = b3;
        }

        public static Word operator ^(Word word1, Word word2)
        {
            word1.w[0] = (byte)(word1.w[0] ^ word2.w[0]);
            word1.w[1] = (byte)(word1.w[1] ^ word2.w[1]);
            word1.w[2] = (byte)(word1.w[2] ^ word2.w[2]);
            word1.w[3] = (byte)(word1.w[3] ^ word2.w[3]);
            return word1;
        }

        public void print()
        {
            for (int i = 0; i < 4; i++)
            {
                byte[] tmp = new byte[1];
                tmp[0] = w[i];
                Console.Write(BitConverter.ToString(tmp));
            }
            Console.WriteLine();
        }
    }
}
