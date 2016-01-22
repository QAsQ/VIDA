using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS
{
    static class VCode
    {
        const string biter = "r1AQaq0PpOoNnMmLlKk*JZjz9IYiy8HXhx7GWgw6FVfv5EUeu4DTdt#3CScs2BRb";
        static public bool isLegalVCode(string Vcode)
        {
            foreach (char c in Vcode)
            {
                if (VCharToInt(c) == -1)
                    return false;
            }
            return true;
        }
        public static string VCodetobit(string Vcode)
        {
            string ret = "";
            for (int i = 0; i < Vcode.Length; i++)
            {
                ret = ret + IntToBit(VCharToInt(Vcode[i]));
            }
            ret = deleteLeadZero(ret);
            return ret;
        }
        private static string deleteLeadZero(string bit)
        {
            while (bit.Length != 0 && bit[0] == '0')
            {
                bit = bit.Substring(1);
            }
            return bit;
        }
        public static string BitToVCode(string bit)
        {
            string code = "";
            bit = addLeadZero(bit);
            int len = bit.Length / 6;
            for (int i = 0; i < len; i++)
            {
                code = code + BitToVChar(bit.Substring(i * 6, 6));
            }
            return code;
        }

        private static string addLeadZero(string bit)
        {
            if (bit.Length % 6 != 0)
            {
                int zeroNeeded = 6 - bit.Length % 6;
                for (int i = 0; i < zeroNeeded; i++)
                    bit = "0" + bit;
            }
            return bit;
        }
        static int BitToInt(string bit)
        {
            int ret = 0;
            for (int i = 5; i >= 0; i--)
            {
                ret = ret * 2 + (bit[i] - '0');
            }
            return ret;
        }
        static char BitToVChar(string bit)
        {
            return biter[BitToInt(bit)];
        }
        static string IntToBit(int x)
        {
            string ret = "";
            for(int i=0;i<6;i++){
                ret += (x%2).ToString();
                x /= 2;
            }
            return ret;
        }
        static int VCharToInt(char c)
        {
            for (int i = 0; i < biter.Length; i++)
            {
                if (biter[i] == c)
                    return i;
            }
            return -1;
        }
    }
}
