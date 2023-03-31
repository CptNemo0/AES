using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AES
{
    public class Presentation
    {
        public string ByteArrayToString(byte[] arr)
        {
            StringBuilder stringBuilder = new StringBuilder();
            byte[] temp = new byte[1];
            for(int i = 0; i < arr.Length; i++)
            {
                temp[0] = arr[i];
                stringBuilder.Append(BitConverter.ToString(temp));
            }
            return stringBuilder.ToString();
        }

        public byte[] HexStringToByteArray(string hex)
        {
            byte[] byteArray = Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
            return byteArray;
        }

        public string HexStringToString(string hexString)
        {
            byte[] byteArray = Enumerable.Range(0, hexString.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hexString.Substring(x, 2), 16))
                             .ToArray();
            return Encoding.UTF8.GetString(byteArray);  
        }
    }
}
