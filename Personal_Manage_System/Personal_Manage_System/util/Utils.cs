using System;
using System.Collections.Generic;
using System.Text;

namespace Util
{
    public static class Utils
    {
        /**
         * 
         * 判断字符串str是否为空或者null，是返回true，否则返回false
         * 
         * */
        public static bool isNullOrEmpty(string str)
        {
            return null == str || "".Equals(str.Trim());
        }


        //获取长度为length的随机数
        public static String random(int length)
        {
            String str = "";
            Random rd = new Random();
            for (int i = 0; i < length; i++)
            {
                str += rd.Next(10);
            }
            return str;

        }

        public static String getCurTime()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmss");

        }
        /**
         * 把整数num转化为4个长度的字符串，如果num不到4位，那么前面补0
         * 
         * */
        public static String int2Str(int num)
        {
            String str = num.ToString();
            int length = str.Length;
            if (length > 4)
                return str;
            else if (length == 4)
                return str;
            else
            {
                for (int i = 0; i < 4 - length; i++)
                {
                    str = "0" + str;
                }
                return str;
            }
        }

        public static String CountOne(String bitCount)
        {
            char[] bits = bitCount.ToCharArray();
            int i = 0;
            for (i = bits.Length - 1; i >= 0; i--)
            {
                if (bits[i] == '0')
                {
                    bits[i] = '1';
                    break;
                }
                else
                {
                    bits[i] = '0';
                    continue;
                }
            }
            if (i == 0)
                return "1" + bits.ToString();
            else
                return bits.ToString();

        }

        public static string hexToBit(string hexStr)
        {
            string bitStr = "";

            int num = int.Parse(hexStr, System.Globalization.NumberStyles.AllowHexSpecifier);

            string tempBit = Convert.ToString(num, 2);

            if (tempBit.Length < 16)
            {
                for (int i = 0; i < 16 - tempBit.Length; i++)
                {
                    bitStr += "0";
                }
                bitStr = bitStr + tempBit;
            }
            else
            {
                bitStr = tempBit;
            }



            return bitStr;
        }

    }
}
