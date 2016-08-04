using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace InnoSoft.LS.Data.Access
{
    internal class Utils
    {
        /// <summary>
        /// DES解密字符串
        /// </summary>
        /// <param name="decryptString">待解密的字符串</param>
        /// <returns></returns>
        public static string DecryptDES(string decryptString)
        {
            byte[] Keys = { 0xAB, 0x84, 0xDF, 0x32, 0x09, 0x5C, 0xC7, 0xEF };
            try
            {
                byte[] inputByteArray = Convert.FromBase64String(decryptString);
                DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(Keys, Keys), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(mStream.ToArray());
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
