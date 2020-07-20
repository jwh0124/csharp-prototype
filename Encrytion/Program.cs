using System;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Encrytion
{
    public class Program
    {
        //static Crypto crypto = new Crypto();
        static void Main(string[] args)
        {
            string enc_value = "QOu2+UwzXrSx1MwrfW5ZsA==";
            /*
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider md = new MD5CryptoServiceProvider();
            byte[] value = Encoding.UTF8.GetBytes(enc_value);
            string keyString = "KEPCO_VERTX";
            byte[] key = md.ComputeHash(Encoding.UTF8.GetBytes("KEPCO_VERTX"));
            md.Clear();

            byte[] SALT_BYTES = new byte[] { 162, 27, 98, 1, 28, 239, 64, 30, 156, 102, 223 };
            Rfc2898DeriveBytes derivedBytes = new Rfc2898DeriveBytes(keyString, SALT_BYTES, 5);
            byte[] keyStream = derivedBytes.GetBytes(tdes.KeySize / 8);
            byte[] IV = new byte[tdes.BlockSize / 8];
            tdes.Key = keyStream;
            tdes.IV = IV;
            tdes.Padding = PaddingMode.None;
            tdes.Mode = CipherMode.CBC;

            var des_value = Encoding.UTF8.GetString(tdes.CreateDecryptor(keyStream, IV).TransformFinalBlock(value, 0, value.Length));
            tdes.Clear();
            Console.WriteLine(des_value);
           */
            string keyString = "KEPCO_VERTX";

            Crypto.EncryptionAlgorithm = Crypto.Algorithm.TripleDES;
            Crypto.Encoding = Crypto.EncodingType.BASE_64;

            Crypto.Key = "KEPCO_VERTX";
            Crypto.Content = enc_value;

            Crypto.DecryptString();
            string strDcText = Crypto.Content;

             Crypto.Clear();



        }
    }


}
