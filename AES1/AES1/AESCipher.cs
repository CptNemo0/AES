using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AES1
{
    public class AESCipher
    {
        public Utils slh;

        public AESCipher(Utils slh)
        {
            this.slh = slh;
        }

        public void SubBytes(ref byte[,] state)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    state[i, j] = slh.GetSubstituteByte(state[i, j]);
                }
            }
        }

        public void ShiftRows(ref byte[,] state)
        {
            byte s0 = state[1, 0];
            byte s1 = state[1, 1];
            byte s2 = state[1, 2];
            byte s3 = state[1, 3];

            state[1, 0] = s1;
            state[1, 1] = s2;
            state[1, 2] = s3;
            state[1, 3] = s0;

            s0 = state[2, 0];
            s1 = state[2, 1];
            s2 = state[2, 2];
            s3 = state[2, 3];

            state[2, 0] = s2;
            state[2, 1] = s3;
            state[2, 2] = s0;
            state[2, 3] = s1;

            s0 = state[3, 0];
            s1 = state[3, 1];
            s2 = state[3, 2];
            s3 = state[3, 3];

            state[3, 0] = s3;
            state[3, 1] = s0;
            state[3, 2] = s1;
            state[3, 3] = s2;
        }

        public void MixColumns(ref byte[,] state)
        {
            int[] helper_array = new int[4];
            for (int c = 0; c < 4; c++)
            {
                helper_array[0] = (slh.GF256MUL(0x02, state[0, c])) ^ (slh.GF256MUL(0x03, state[1, c])) ^ (state[2, c]) ^ (state[3, c]);
                helper_array[1] = (state[0, c]) ^ (slh.GF256MUL(0x02, state[1, c])) ^ (slh.GF256MUL(0x03, state[2, c])) ^ (state[3, c]);
                helper_array[2] = (state[0, c]) ^ (state[1, c]) ^ (slh.GF256MUL(0x02, state[2, c])) ^ (slh.GF256MUL(0x03, state[3, c]));
                helper_array[3] = (slh.GF256MUL(0x03, state[0, c])) ^ (state[1, c]) ^ (state[2, c]) ^ (slh.GF256MUL(0x02, state[3, c]));

                for (int r = 0; r < 4; r++)
                {
                    state[r, c] = (byte)(helper_array[r]);
                }
            }
        }
        
        public byte[,] Cipher(byte[,] input, Word[] KeyScheadule, int Nk)
        {
            byte[,] state = input;
            int Nb = 4;
            int lastRound = 0;
            slh.AddRoundKey(ref state, KeyScheadule, 0);

            for (int round = 1; round < (Nb + Nk + 2); round++)
            {
                SubBytes(ref state);
                ShiftRows(ref state);
                MixColumns(ref state);
                slh.AddRoundKey(ref state, KeyScheadule, round);
                lastRound = round;
            }

            SubBytes(ref state);
            ShiftRows(ref state);
            slh.AddRoundKey(ref state, KeyScheadule, lastRound + 1);

            return state;
        }
    }
}
