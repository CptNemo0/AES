namespace Tests
{
    [TestClass]
    public class AESCipherTest
    {
        //--------------- AESCipher Tests ---------------\\
        [TestMethod]
        public void TestSubBytes()
        {
            Utils slh = new Utils();
            AESCipher cipher = new AESCipher(slh);
            byte[,] initial =
            {
                { 0x19, 0x3d, 0xe3, 0xbe},
                { 0xa0, 0xf4, 0xe2, 0x2b},
                { 0x9a, 0xc6, 0x8d, 0x2a},
                { 0xe9, 0xf8, 0x48, 0x08},
            };

            byte[,] after =
            {
                { 0xd4, 0x27, 0x11, 0xae},
                { 0xe0, 0xbf, 0x98, 0xf1},
                { 0xb8, 0xb4, 0x5d, 0xe5},
                { 0x1e, 0x41, 0x52, 0x30},
            };

            cipher.SubBytes(ref initial);

            int a = 0;

            for(int i = 0; i < 4; i ++)
            {
                for(int j = 0; j < 4; j ++)
                {
                    if (initial[i,j] == after[i,j])
                    {
                        a++;
                    }
                }
            }

            Assert.AreEqual(a, 16);
        }

        [TestMethod]
        public void TestShiftRows()
        {
            byte[] input = { 0xd4, 0x27, 0x11, 0xae, 0xe0, 0xbf, 0x98, 0xf1, 0xb8, 0xb4, 0x5d, 0xe5, 0x1e, 0x41, 0x52, 0x30 };
            byte[] output = { 0xd4, 0xbf, 0x5d, 0x30, 0xe0, 0xb4, 0x52, 0xae, 0xb8, 0x41, 0x11, 0xf1, 0x1e, 0x27, 0x98, 0xe5 };
            Utils slh = new Utils();
            AESCipher cipher = new AESCipher(slh);

            byte[,] initial = slh.BlockToState(input);
            
            byte[,] after = slh.BlockToState(output);
            

            cipher.ShiftRows(ref initial);

            int a = 0;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (initial[i, j] == after[i, j])
                    {
                        a++;
                    }
                }
            }

            Assert.AreEqual(a, 16);
        }

        [TestMethod]
        public void TestMixColumns()
        {
            byte[] input = { 0xd4, 0xbf, 0x5d, 0x30, 0xe0, 0xb4, 0x52, 0xae, 0xb8, 0x41, 0x11, 0xf1, 0x1e, 0x27, 0x98, 0xe5 };
            byte[] output = { 0x04, 0x66, 0x81, 0xe5, 0xe0, 0xcb, 0x19, 0x9a, 0x48, 0xf8, 0xd3, 0x7a, 0x28, 0x06, 0x26, 0x4c };
            Utils slh = new Utils();
            AESCipher cipher = new AESCipher(slh);

            byte[,] initial = slh.BlockToState(input);

            byte[,] after = slh.BlockToState(output);

            cipher.MixColumns(ref initial);

            int a = 0;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (initial[i, j] == after[i, j])
                    {
                        a++;
                    }
                }
            }

            Assert.AreEqual(a, 16);
        }

        [TestMethod]
        public void TestCipher()
        {
            Utils slh = new Utils();
            AESCipher cipher = new AESCipher(slh);

            byte[] block =  { 0x32, 0x43, 0xf6, 0xa8, 0x88, 0x5a, 0x30, 0x8d, 0x31, 0x31, 0x98, 0xa2, 0xe0, 0x37, 0x07, 0x34 };
            byte[] key =    { 0x2b, 0x7e, 0x15, 0x16, 0x28, 0xae, 0xd2, 0xa6, 0xab, 0xf7, 0x15, 0x88, 0x09, 0xcf, 0x4f, 0x3c };
            byte[] output = { 0x39, 0x25, 0x84, 0x1d, 0x02, 0xdc, 0x09, 0xfb, 0xdc, 0x11, 0x85, 0x97, 0x19, 0x6a, 0x0b, 0x32 };

            byte[,] expectedState = slh.BlockToState(output);
            Word[] KeyScheadule = slh.KeyExpansion(key);
            byte[,] outputState = cipher.Cipher(slh.BlockToState(block), KeyScheadule, 4);
            int a = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (outputState[i, j] == expectedState[i, j])
                    {
                        a++;
                    }
                }
            }

            Assert.AreEqual(a, 16);
        }


        //--------------- AESDecipher Tests ---------------\\
        [TestMethod]
        public void TestInvSubBytes()
        {
            Utils slh = new Utils();
            AESDecipher cipher = new AESDecipher(slh);
            byte[,] after =
            {
                { 0x19, 0x3d, 0xe3, 0xbe},
                { 0xa0, 0xf4, 0xe2, 0x2b},
                { 0x9a, 0xc6, 0x8d, 0x2a},
                { 0xe9, 0xf8, 0x48, 0x08},
            };

            byte[,] initial =
            {
                { 0xd4, 0x27, 0x11, 0xae},
                { 0xe0, 0xbf, 0x98, 0xf1},
                { 0xb8, 0xb4, 0x5d, 0xe5},
                { 0x1e, 0x41, 0x52, 0x30},
            };

            cipher.InvSubBytes(ref initial);

            int a = 0;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (initial[i, j] == after[i, j])
                    {
                        a++;
                    }
                }
            }

            Assert.AreEqual(a, 16);
        }

        [TestMethod]
        public void TestInvShiftRows()
        {
            byte[] input = { 0xd4, 0x27, 0x11, 0xae, 0xe0, 0xbf, 0x98, 0xf1, 0xb8, 0xb4, 0x5d, 0xe5, 0x1e, 0x41, 0x52, 0x30 };
            byte[] output = { 0xd4, 0xbf, 0x5d, 0x30, 0xe0, 0xb4, 0x52, 0xae, 0xb8, 0x41, 0x11, 0xf1, 0x1e, 0x27, 0x98, 0xe5 };
            Utils slh = new Utils();
            AESDecipher cipher = new AESDecipher(slh);

            byte[,] after = slh.BlockToState(input);

            byte[,] initial = slh.BlockToState(output);


            cipher.InvShiftRows(ref initial);

            int a = 0;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (initial[i, j] == after[i, j])
                    {
                        a++;
                    }
                }
            }

            Assert.AreEqual(a, 16);
        }

        [TestMethod]
        public void TestInvMixColumns()
        {
            byte[] input = { 0xd4, 0xbf, 0x5d, 0x30, 0xe0, 0xb4, 0x52, 0xae, 0xb8, 0x41, 0x11, 0xf1, 0x1e, 0x27, 0x98, 0xe5 };
            byte[] output = { 0x04, 0x66, 0x81, 0xe5, 0xe0, 0xcb, 0x19, 0x9a, 0x48, 0xf8, 0xd3, 0x7a, 0x28, 0x06, 0x26, 0x4c };
            Utils slh = new Utils();
            AESDecipher cipher = new AESDecipher(slh);

            byte[,] after = slh.BlockToState(input);

            byte[,] initial = slh.BlockToState(output);

            cipher.InvMixColumns(ref initial);

            int a = 0;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (initial[i, j] == after[i, j])
                    {
                        a++;
                    }
                }
            }

            Assert.AreEqual(a, 16);
        }

        [TestMethod]
        public void TestInvCipher()
        {
            Utils slh = new Utils();
            AESDecipher cipher = new AESDecipher(slh);

            byte[] output = { 0x32, 0x43, 0xf6, 0xa8, 0x88, 0x5a, 0x30, 0x8d, 0x31, 0x31, 0x98, 0xa2, 0xe0, 0x37, 0x07, 0x34 };
            byte[] key = { 0x2b, 0x7e, 0x15, 0x16, 0x28, 0xae, 0xd2, 0xa6, 0xab, 0xf7, 0x15, 0x88, 0x09, 0xcf, 0x4f, 0x3c };
            byte[] block = { 0x39, 0x25, 0x84, 0x1d, 0x02, 0xdc, 0x09, 0xfb, 0xdc, 0x11, 0x85, 0x97, 0x19, 0x6a, 0x0b, 0x32 };

            byte[,] expectedState = slh.BlockToState(output);
            Word[] KeyScheadule = slh.KeyExpansion(key);
            byte[,] outputState = cipher.InvCipher(slh.BlockToState(block), KeyScheadule, 4);
            int a = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (outputState[i, j] == expectedState[i, j])
                    {
                        a++;
                    }
                }
            }

            Assert.AreEqual(a, 16);
        }

        //--------------- Utils Tests ---------------\\
        [TestMethod]
        public void TestBlockToState()
        {
            Utils slh = new Utils();
            byte[] block = { 0x32, 0x43, 0xf6, 0xa8, 0x88, 0x5a, 0x30, 0x8d, 0x31, 0x31, 0x98, 0xa2, 0xe0, 0x37, 0x07, 0x34 };
            byte[,] state =
            {
                { 0x32, 0x88, 0x31, 0xe0},
                { 0x43, 0x5a, 0x31, 0x37},
                { 0xf6, 0x30, 0x98, 0x07},
                { 0xa8, 0x8d, 0xa2, 0x34}
            };

            byte[,] output = slh.BlockToState(block);

            int a = 0;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (output[i, j] == state[i, j])
                    {
                        a++;
                    }
                }
            }

            Assert.AreEqual(a, 16);
        }

        [TestMethod]
        public void TestStateToBlock()
        {
            Utils slh = new Utils();
            byte[,] initial =
            {
                { 0x19, 0x3d, 0xe3, 0xbe},
                { 0xa0, 0xf4, 0xe2, 0x2b},
                { 0x9a, 0xc6, 0x8d, 0x2a},
                { 0xe9, 0xf8, 0x48, 0x08},
            };
            byte[] output = { 0x19, 0xa0, 0x9a, 0xe9, 0x3d, 0xf4, 0xc6, 0xf8, 0xe3, 0xe2, 0x8d, 0x48, 0xbe, 0x2b, 0x2a, 0x08 };
            byte[] after = slh.StateToBlock(initial);

            int a = 0;
            for(int i = 0; i < after.Length; i++)
            {
                if (output[i] == after[i])
                {
                    a++;
                }
            }

            Assert.AreEqual(a, 16);
        }

        [TestMethod]
        public void TestGF256()
        {
            Utils slh = new Utils();
            Assert.AreEqual(80, slh.GF256MUL(12, 12));
        }
    }
}