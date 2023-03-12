using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AES1
{
    public class Utils
    {
        // Substitution box
        public readonly static byte[,] sbox =
        {
            { 0x63, 0x7C, 0x77, 0x7B, 0xF2, 0x6B, 0x6F, 0xC5, 0x30, 0x01, 0x67, 0x2B, 0xFE, 0xD7, 0xAB, 0x76 },
            { 0xCA, 0x82, 0xC9, 0x7D, 0xFA, 0x59, 0x47, 0xF0, 0xAD, 0xD4, 0xA2, 0xAF, 0x9C, 0xA4, 0x72, 0xC0 },
            { 0xB7, 0xFD, 0x93, 0x26, 0x36, 0x3F, 0xF7, 0xCC, 0x34, 0xA5, 0xE5, 0xF1, 0x71, 0xD8, 0x31, 0x15 },
            { 0x04, 0xC7, 0x23, 0xC3, 0x18, 0x96, 0x05, 0x9A, 0x07, 0x12, 0x80, 0xE2, 0xEB, 0x27, 0xB2, 0x75 },
            { 0x09, 0x83, 0x2C, 0x1A, 0x1B, 0x6E, 0x5A, 0xA0, 0x52, 0x3B, 0xD6, 0xB3, 0x29, 0xE3, 0x2F, 0x84 },
            { 0x53, 0xD1, 0x00, 0xED, 0x20, 0xFC, 0xB1, 0x5B, 0x6A, 0xCB, 0xBE, 0x39, 0x4A, 0x4C, 0x58, 0xCF },
            { 0xD0, 0xEF, 0xAA, 0xFB, 0x43, 0x4D, 0x33, 0x85, 0x45, 0xF9, 0x02, 0x7F, 0x50, 0x3C, 0x9F, 0xA8 },
            { 0x51, 0xA3, 0x40, 0x8F, 0x92, 0x9D, 0x38, 0xF5, 0xBC, 0xB6, 0xDA, 0x21, 0x10, 0xFF, 0xF3, 0xD2 },
            { 0xCD, 0x0C, 0x13, 0xEC, 0x5F, 0x97, 0x44, 0x17, 0xC4, 0xA7, 0x7E, 0x3D, 0x64, 0x5D, 0x19, 0x73 },
            { 0x60, 0x81, 0x4F, 0xDC, 0x22, 0x2A, 0x90, 0x88, 0x46, 0xEE, 0xB8, 0x14, 0xDE, 0x5E, 0x0B, 0xDB },
            { 0xE0, 0x32, 0x3A, 0x0A, 0x49, 0x06, 0x24, 0x5C, 0xC2, 0xD3, 0xAC, 0x62, 0x91, 0x95, 0xE4, 0x79 },
            { 0xE7, 0xC8, 0x37, 0x6D, 0x8D, 0xD5, 0x4E, 0xA9, 0x6C, 0x56, 0xF4, 0xEA, 0x65, 0x7A, 0xAE, 0x08 },
            { 0xBA, 0x78, 0x25, 0x2E, 0x1C, 0xA6, 0xB4, 0xC6, 0xE8, 0xDD, 0x74, 0x1F, 0x4B, 0xBD, 0x8B, 0x8A },
            { 0x70, 0x3E, 0xB5, 0x66, 0x48, 0x03, 0xF6, 0x0E, 0x61, 0x35, 0x57, 0xB9, 0x86, 0xC1, 0x1D, 0x9E },
            { 0xE1, 0xF8, 0x98, 0x11, 0x69, 0xD9, 0x8E, 0x94, 0x9B, 0x1E, 0x87, 0xE9, 0xCE, 0x55, 0x28, 0xDF },
            { 0x8C, 0xA1, 0x89, 0x0D, 0xBF, 0xE6, 0x42, 0x68, 0x41, 0x99, 0x2D, 0x0F, 0xB0, 0x54, 0xBB, 0x16 }
        };

        public readonly static byte[,] inv_sbox =
        {
            { 0x52, 0x09, 0x6A, 0xD5, 0x30, 0x36, 0xA5, 0x38, 0xBF, 0x40, 0xA3, 0x9E, 0x81, 0xF3, 0xD7, 0xFB },
            { 0x7C, 0xE3, 0x39, 0x82, 0x9B, 0x2F, 0xFF, 0x87, 0x34, 0x8E, 0x43, 0x44, 0xC4, 0xDE, 0xE9, 0xCB },
            { 0x54, 0x7B, 0x94, 0x32, 0xA6, 0xC2, 0x23, 0x3D, 0xEE, 0x4C, 0x95, 0x0B, 0x42, 0xFA, 0xC3, 0x4E },
            { 0x08, 0x2E, 0xA1, 0x66, 0x28, 0xD9, 0x24, 0xB2, 0x76, 0x5B, 0xA2, 0x49, 0x6D, 0x8B, 0xD1, 0x25 },
            { 0x72, 0xF8, 0xF6, 0x64, 0x86, 0x68, 0x98, 0x16, 0xD4, 0xA4, 0x5C, 0xCC, 0x5D, 0x65, 0xB6, 0x92 },
            { 0x6C, 0x70, 0x48, 0x50, 0xFD, 0xED, 0xB9, 0xDA, 0x5E, 0x15, 0x46, 0x57, 0xA7, 0x8D, 0x9D, 0x84 },
            { 0x90, 0xD8, 0xAB, 0x00, 0x8C, 0xBC, 0xD3, 0x0A, 0xF7, 0xE4, 0x58, 0x05, 0xB8, 0xB3, 0x45, 0x06 },
            { 0xD0, 0x2C, 0x1E, 0x8F, 0xCA, 0x3F, 0x0F, 0x02, 0xC1, 0xAF, 0xBD, 0x03, 0x01, 0x13, 0x8A, 0x6B },
            { 0x3A, 0x91, 0x11, 0x41, 0x4F, 0x67, 0xDC, 0xEA, 0x97, 0xF2, 0xCF, 0xCE, 0xF0, 0xB4, 0xE6, 0x73 },
            { 0x96, 0xAC, 0x74, 0x22, 0xE7, 0xAD, 0x35, 0x85, 0xE2, 0xF9, 0x37, 0xE8, 0x1C, 0x75, 0xDF, 0x6E },
            { 0x47, 0xF1, 0x1A, 0x71, 0x1D, 0x29, 0xC5, 0x89, 0x6F, 0xB7, 0x62, 0x0E, 0xAA, 0x18, 0xBE, 0x1B },
            { 0xFC, 0x56, 0x3E, 0x4B, 0xC6, 0xD2, 0x79, 0x20, 0x9A, 0xDB, 0xC0, 0xFE, 0x78, 0xCD, 0x5A, 0xF4 },
            { 0x1F, 0xDD, 0xA8, 0x33, 0x88, 0x07, 0xC7, 0x31, 0xB1, 0x12, 0x10, 0x59, 0x27, 0x80, 0xEC, 0x5F },
            { 0x60, 0x51, 0x7F, 0xA9, 0x19, 0xB5, 0x4A, 0x0D, 0x2D, 0xE5, 0x7A, 0x9F, 0x93, 0xC9, 0x9C, 0xEF },
            { 0xA0, 0xE0, 0x3B, 0x4D, 0xAE, 0x2A, 0xF5, 0xB0, 0xC8, 0xEB, 0xBB, 0x3C, 0x83, 0x53, 0x99, 0x61 },
            { 0x17, 0x2B, 0x04, 0x7E, 0xBA, 0x77, 0xD6, 0x26, 0xE1, 0x69, 0x14, 0x63, 0x55, 0x21, 0x0C, 0x7D }
        };

        public byte[] getCipherKey(int Nk)
        {
            int len = 0;

            if (Nk == 4)
            {
                len = 128 / 8;
            }
            else if (Nk == 8)
            {
                len = 256 / 8;
            }
            else if (Nk == 6)
            {
                len = 192 / 8;
            }
            else
            {
                throw new Exception("Only 128, 192 and 256 are valid lengths!");
            }

            byte[] key = new byte[len]; // 16 bytes = 128 bits
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(key);
            }
            return key;
        }

        
        public byte[] MessageInBinary(string message, Encoding encoding)
        {
            return encoding.GetBytes(message);
        }

        public byte[] ConvertToByteArray(string str, Encoding encoding)
        {
            return encoding.GetBytes(str);
        }

        public String ToBinary(Byte[] data)
        {
            return string.Join("", data.Select(byt => Convert.ToString(byt, 2).PadLeft(8, '0')));
        }

        
        public byte[,] BlockToState(byte[] block)
        {
            byte[,] retValue = { { block[0], block[4], block[8], block[12] },
                             { block[1], block[5], block[9], block[13] },
                             { block[2], block[6], block[10], block[14] },
                             { block[3], block[7], block[11], block[15] } };

            return retValue;
        }

        public byte[] StateToBlock(byte[,] state)
        {
            byte[] retValue = {
                               state[0, 0], state[1, 0], state[2, 0], state[3, 0], state[0, 1], state[1, 1], state[2, 1], state[3, 1],
                               state[0, 2], state[1, 2], state[2, 2], state[3, 2], state[0, 3], state[1, 3], state[2, 3], state[3, 3]
                          };
            return retValue;
        }

        
        public void PrintByteArray(byte[] state)
        {
            Console.WriteLine(BitConverter.ToString(state));
        }


        public void AddRoundKey(ref byte[,] state, Word[] ks, int round)
        {
            int Nb = 4;
            int[] helper_array = new int[4];
            for (int c = 0; c < 4; c++)
            {
                helper_array[0] = (state[0, c] ^ ks[round * Nb + c].w[0]);
                helper_array[1] = (state[1, c] ^ ks[round * Nb + c].w[1]);
                helper_array[2] = (state[2, c] ^ ks[round * Nb + c].w[2]);
                helper_array[3] = (state[3, c] ^ ks[round * Nb + c].w[3]);

                for (int r = 0; r < 4; r++)
                {
                    state[r, c] = (byte)(helper_array[r]);
                }
            }
        }

        public byte GF256MUL(byte a, byte b)
        {
            byte retValue = 0;
            byte t;

            while (a != 0)
            {
                if ((a & 1) != 0)
                {
                    retValue = (byte)(retValue ^ b);
                }
                t = (byte)(b & 0x80);
                b = (byte)(b << 1);
                if (t != 0)
                {
                    b = (byte)(b ^ 0x1b);
                }
                a = (byte)((a & 0xff) >> 1);
            }

            return retValue;
        }
        //Substitution of singular bit according to S-box
        public byte GetSubstituteByte(byte s)
        {
            byte retValue = 0;                          // Byte retValue is literall byte - sequention of 8 binary values, in this case 0000 0000.
                                                        // Keep in mind that single hexadecimal digit (form 0 to F) can ALWAYS be represented using 4 bits.
                                                        // Thus 1 byte is comprised of 2 hexadeciaml numbers. 

            byte ColumnIndex = (byte)(s & 0x0F);        // We are writting 4 youngest (first from right) bits of input byte, to the variable ColumnIndex. 
                                                        // We are using logical AND operation on bites of input byte and 0x0F (0000 1111).
                                                        // This way we are zeroing 4 oldest bits and preserving 4 youngest.
            byte RowIndex = (byte)(s & 0xF0);           // Now we are accessing 4 oldest bits in the smae fashion. 
                                                        // Keep in mind that result of that operation zeroes 4 youngest bits and leaves us with 16 times bigger number. 
            RowIndex = (byte)(RowIndex >> 4);           // To combat this we are just simply bit-shiffting RowIndex 4 times to right. Which is equivalent to dividing by 2^4. 

            retValue = sbox[RowIndex, ColumnIndex];     // We access sbox and return value that passed state should be substituted with.

            return retValue;
        }

        public byte GetInvSubstituteByte(byte s)
        {
            byte retValue = 0;                          // Byte retValue is literall byte - sequention of 8 binary values, in this case 0000 0000.
                                                        // Keep in mind that single hexadecimal digit (form 0 to F) can ALWAYS be represented using 4 bits.
                                                        // Thus 1 byte is comprised of 2 hexadeciaml numbers. 

            byte ColumnIndex = (byte)(s & 0x0F);        // We are writting 4 youngest (first from right) bits of input byte, to the variable ColumnIndex. 
                                                        // We are using logical AND operation on bites of input byte and 0x0F (0000 1111).
                                                        // This way we are zeroing 4 oldest bits and preserving 4 youngest.
            byte RowIndex = (byte)(s & 0xF0);           // Now we are accessing 4 oldest bits in the smae fashion. 
                                                        // Keep in mind that result of that operation zeroes 4 youngest bits and leaves us with 16 times bigger number. 
            RowIndex = (byte)(RowIndex >> 4);           // To combat this we are just simply bit-shiffting RowIndex 4 times to right. Which is equivalent to dividing by 2^4. 

            retValue = inv_sbox[RowIndex, ColumnIndex];     // We access sbox and return value that passed state should be substituted with.

            return retValue;
        }


        public Word SubWord(Word w)
        {
            return new Word(GetSubstituteByte(w.w[0]), GetSubstituteByte(w.w[1]), GetSubstituteByte(w.w[2]), GetSubstituteByte(w.w[3]));
        }

        public Word RotWord(Word w)
        {
            return new Word(w.w[1], w.w[2], w.w[3], w.w[0]);
        }

        public Word Rcon(int i)
        {
            if (i < 9)
            {
                return new Word((byte)(Math.Pow(0x02, i - 1)), (byte)0x00, (byte)0x00, (byte)0x00);
            }
            else if (i == 9)
            {
                return new Word((byte)0x1b, (byte)0x00, (byte)0x00, (byte)0x00);
            }
            else if (i == 10)
            {
                return new Word((byte)0x36, (byte)0x00, (byte)0x00, (byte)0x00);
            }
            else
            {
                return new Word(0x00, 0x00, 0x00, 0x00);
            }
        }

        public Word[] KeyExpansion(byte[] K)
        {
            int Nb = 4;
            int Nk = K.Length / 4;
            int Nr = Nb + Nk + 2;
            Word[] w = new Word[Nb * (Nr + 1)];
            Word[] retValue = new Word[Nb * (Nr + 1)];

            for (int z = 0; z < w.Length; z++)
            {
                w[z] = new Word(0x00, 0x00, 0x00, 0x00);
                retValue[z] = new Word(0x00, 0x00, 0x00, 0x00);
            }
            Word temp;

            int i = 0;

            while (i < Nk)
            {
                w[i] = new Word(K[4 * i], K[4 * i + 1], K[4 * i + 2], K[4 * i + 3]);
                retValue[i] = new Word(w[i].w[0], w[i].w[1], w[i].w[2], w[i].w[3]); //it works.
                i++;
            }

            i = Nk;

            while (i < Nb * (Nr + 1))
            {
                temp = w[i - 1];
                if (i % Nk == 0)
                {
                    temp = RotWord(temp);
                    temp = SubWord(temp);
                    temp = temp ^ Rcon(i / Nk);
                }
                else if (Nk > 6 && i % Nk == 4)
                {
                    temp = SubWord(temp);
                }
                w[i] = w[i - Nk] ^ temp;
                retValue[i] = new Word(w[i].w[0], w[i].w[1], w[i].w[2], w[i].w[3]); //it works.
                i++;
            }

            return retValue;
        }

    }
}
