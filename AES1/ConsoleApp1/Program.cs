using AES;
using System.Collections;
using System.Text;

public class Program
{
    public static void Main(string[] args)
    {

        string message = "Ala ma kota, Ala ma psa, a handlarz niewolników Ale ma!";
        string filePath = "message.bin";

        using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
        {
            
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(message);

            
            writer.Write(byteArray);
        }

        Utils slh = new Utils();
        int Nk = 4;
        byte[] key = slh.getCipherKey(Nk);
        string keyPath = "key.bin";

        using (BinaryWriter writer = new BinaryWriter(File.Open(keyPath, FileMode.Create)))
        {
            writer.Write(key);
        }


        byte[] message_1;
        using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
        {
            message_1 = reader.ReadBytes((int)reader.BaseStream.Length);
        }

        byte[] key_1;
        using (BinaryReader reader = new BinaryReader(File.Open(keyPath, FileMode.Open)))
        {
            key_1 = reader.ReadBytes((int)reader.BaseStream.Length);
        }

        string encodedPath = "encoded.bin";
        using (BinaryWriter writer = new BinaryWriter(File.Open(encodedPath, FileMode.Create)))
        {
            Ihavenoideaforname ihavenoideaforname = new Ihavenoideaforname();
            byte[] byteArray = ihavenoideaforname.encode(message_1, key_1);
            string strFromFile = System.Text.Encoding.UTF8.GetString(byteArray);
            Console.WriteLine(strFromFile);
            writer.Write(byteArray);
        }


        //decoding
        byte[] message_2;
        using (BinaryReader reader = new BinaryReader(File.Open(encodedPath, FileMode.Open)))
        {
            message_2 = reader.ReadBytes((int)reader.BaseStream.Length);
            string strFromFile = System.Text.Encoding.UTF8.GetString(message_2);
            Console.WriteLine(strFromFile);
        }

        byte[] key_2;
        using (BinaryReader reader = new BinaryReader(File.Open(keyPath, FileMode.Open)))
        {
            key_2 = reader.ReadBytes((int)reader.BaseStream.Length);
        }

        string decodedPath = "decoded.bin";
        using (BinaryWriter writer = new BinaryWriter(File.Open(decodedPath, FileMode.Create)))
        {
            Ihavenoideaforname ihavenoideaforname = new Ihavenoideaforname();
            byte[] byteArray = ihavenoideaforname.decode(message_2, key_2);
            writer.Write(byteArray);
        }

    }
}