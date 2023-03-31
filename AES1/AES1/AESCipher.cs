namespace AES
{
    public class AESCipher
    {
        // santa's little helper :)
        private Utils slh;

        public AESCipher(Utils slh)
        {
            this.slh = slh;
        }

        // SubBytes() is a nonlionear transformation.
        // It uses Substitution box (S - box) to replace every byte in state. 
        // Further explaination in GetSubstituteByte() function.
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

        // ShiftRows() performs cyclic permutation on rows 1, 2, 3.
        // Let's imagine that each row is a queue.
        // We take 0 element in row 1 pop it, and than push it in the end, so that 1th element becomes new 0, 2nd new 1st, 3rd new 2nd.
        // For row 2 we do the same, but with first 2 elements, and for 3rd row analogicaly.
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

        // Transformation in the Cipher that takes all of the columns of the State and mixes their data (independently of one another) to produce new columns.
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
