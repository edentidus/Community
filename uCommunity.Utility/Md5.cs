using System;
using System.Security.Cryptography;
using System.Text;

namespace uCommunity.Utility
{
    public class Md5
    {
        public static String GetMD5Hash(String str)
        {
            MD5 md5 = MD5.Create();

            byte[] bs = Encoding.UTF8.GetBytes(str);
            byte[] hs = md5.ComputeHash(bs);
            StringBuilder sb = new StringBuilder();

            foreach (byte b in hs)
            {
                sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }
    }
}
