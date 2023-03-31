using AES;
using System;
using System.Buffers.Text;
using System.Collections;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Text;

public class Program
{
    public static byte[] testKey1 = { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0a, 0x0b, 0x0c, 0x0d, 0x0e, 0x0f }; //Nk = 4

    public static byte[] testKey2 = { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0a, 0x0b, 0x0c, 0x0d, 0x0e, 0x0f, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x17 }; //Nk = 6

    public static byte[] testKey3 = { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0a, 0x0b, 0x0c, 0x0d, 0x0e, 0x0f, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x17, 0x18, 0x19, 0x1a, 0x1b, 0x1c, 0x1d, 0x1e, 0x1f }; // Nk = 8

    public static byte[] testPlaintext = { 0x00, 0x11, 0x22, 0x33, 0x44, 0x55, 0x66, 0x77, 0x88, 0x99, 0xaa, 0xbb, 0xcc, 0xdd, 0xee, 0xff };
   
    public static void Main()
    {
        string wiadomosc = "Ala ma kota, Ala ma psa, a handlarz niewolników Ale ma!";
        byte[] wiadomosc_bytes = Encoding.UTF8.GetBytes(wiadomosc);

        Utils slh = new Utils();
        Word[] KeyScheadule = slh.KeyExpansion(testKey1);
        int Nk = 4;
        
        Ihavenoideaforname ihavenoideaforname = new Ihavenoideaforname();
        ihavenoideaforname.encode(wiadomosc_bytes, testKey1);
        /*
        Utils slh = new Utils();
        
        AESCipher cipher = new AESCipher(slh);
        AESDecipher decipher = new AESDecipher(slh); 
        Word[] KeyScheadule = slh.KeyExpansion(testKey1);
        Word[] KeyScheadule = slh.KeyExpansion(testKey1);
        int Nk = 4;

        Console.Write("Cipher Key: " + slh.ByteArrayToStr(testKey1) + "\n");
        Console.Write("Plaintext : " + slh.ByteArrayToStr(testPlaintext) + "\n");
   
        byte[,] complete1 = cipher.Cipher(slh.BlockToState(testPlaintext), KeyScheadule, Nk);
        byte[] output = slh.StateToBlock(complete1);
        Console.Write("Cipher text : " + slh.ByteArrayToStr(output) + "\n");
        
        byte[,] initial = decipher.InvCipher(slh.BlockToState(output), KeyScheadule, Nk);
        byte[] output2 = slh.StateToBlock(initial);
        Console.Write("Inverse cipher text (plaintext): " + slh.ByteArrayToStr(output2) + "\n" );
        */
    }
}