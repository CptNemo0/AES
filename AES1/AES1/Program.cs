using AES1;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Text;
/*
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
        for(int i = 0; i < 4; i++)
        {
            byte[] tmp = new byte[1];
            tmp[0] = w[i];
            Console.Write(BitConverter.ToString(tmp));
        }
        Console.WriteLine();
    }
};
*/
public class Program
{
    public static byte[] testKey1 = { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0a, 0x0b, 0x0c, 0x0d, 0x0e, 0x0f }; //Nk = 4

    public static byte[] testKey2 = { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0a, 0x0b, 0x0c, 0x0d, 0x0e, 0x0f, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x17 }; //Nk = 6

    public static byte[] testPlaintext = { 0x00, 0x11, 0x22, 0x33, 0x44, 0x55, 0x66, 0x77, 0x88, 0x99, 0xaa, 0xbb, 0xcc, 0xdd, 0xee, 0xff };
   
    public static void Main()
    {
        Utils slh = new Utils();
        AESCipher cipher = new AESCipher(slh);
        AESDecipher decipher = new AESDecipher(slh); 
        Word[] KeyScheadule = slh.KeyExpansion(testKey2);

        Console.Write("Cipher Key: ");
        slh.PrintByteArray(testKey2);

        Console.Write("Plaintext : ");
        slh.PrintByteArray(testPlaintext);

        byte[,] test = slh.BlockToState(testPlaintext);
        
        byte[,] complete1 = cipher.Cipher(slh.BlockToState(testPlaintext), KeyScheadule, 6);
        byte[] output = slh.StateToBlock(complete1);
        Console.Write("Cipher text : ");
        slh.PrintByteArray(output);

        byte[,] initial = decipher.InvCipher(slh.BlockToState(output), KeyScheadule, 6);
        byte[] output2 = slh.StateToBlock(initial);
        Console.Write("Inverse cipher text (plaintext): ");
        slh.PrintByteArray(output2);
    }
}