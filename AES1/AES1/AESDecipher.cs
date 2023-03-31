namespace Cipher
{
    public class AESDecipher
    {
        private Utils slh;

        public AESDecipher(Utils slh)
        {
            this.slh = slh;
        }

        public void InvSubBytes(ref byte[,] state)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    state[i, j] = slh.GetInvSubstituteByte(state[i, j]);
                }
            }
        }

        public void InvShiftRows(ref byte[,] state)
        {
            byte s0 = state[1, 0];
            byte s1 = state[1, 1];
            byte s2 = state[1, 2];
            byte s3 = state[1, 3];

            state[1, 0] = s3;
            state[1, 1] = s0;
            state[1, 2] = s1;
            state[1, 3] = s2;

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

            state[3, 0] = s1;
            state[3, 1] = s2;
            state[3, 2] = s3;
            state[3, 3] = s0;
        }

        public void InvMixColumns(ref byte[,] state)
        {
            int[] help_arr = new int[4];
            for (int c = 0; c < 4; c++)
            {
                help_arr[0] = slh.GF256MUL(0x0e, state[0, c]) ^ slh.GF256MUL(0x0b, state[1, c]) ^ slh.GF256MUL(0x0d, state[2, c]) ^ slh.GF256MUL(0x09, state[3, c]);
                help_arr[1] = slh.GF256MUL(0x09, state[0, c]) ^ slh.GF256MUL(0x0e, state[1, c]) ^ slh.GF256MUL(0x0b, state[2, c]) ^ slh.GF256MUL(0x0d, state[3, c]);
                help_arr[2] = slh.GF256MUL(0x0d, state[0, c]) ^ slh.GF256MUL(0x09, state[1, c]) ^ slh.GF256MUL(0x0e, state[2, c]) ^ slh.GF256MUL(0x0b, state[3, c]);
                help_arr[3] = slh.GF256MUL(0x0b, state[0, c]) ^ slh.GF256MUL(0x0d, state[1, c]) ^ slh.GF256MUL(0x09, state[2, c]) ^ slh.GF256MUL(0x0e, state[3, c]);

                for (int r = 0; r < 4; r++)
                {
                    state[r, c] = (byte)(help_arr[r]);
                }
            }
        }

        public byte[,] InvCipher(byte[,] input, Word[] KeyScheadule, int Nk)
        {
            byte[,] state = input;
            int Nb = 4;

            int Nr = Nk + Nb + 2;

            slh.AddRoundKey(ref state, KeyScheadule, Nr);

            for (int round = Nr - 1; round > 0; round--)
            {
                InvShiftRows(ref state);
                InvSubBytes(ref state);
                slh.AddRoundKey(ref state, KeyScheadule, round);
                InvMixColumns(ref state);
            }

            InvShiftRows(ref state);
            InvSubBytes(ref state);
            slh.AddRoundKey(ref state, KeyScheadule, 0);

            return state;
        }
    }
}
