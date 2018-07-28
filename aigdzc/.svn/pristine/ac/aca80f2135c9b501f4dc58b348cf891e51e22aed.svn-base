using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CCITU.Common
{
    public class CryptoUtils
    {
        private static Encoding DefaultEncoding = Encoding.UTF8;

        #region Hash

        private static string DefaultHashName = "md5";

        /// <summary>
        /// 计算指定字符串的哈希值，默认hash方法为md5
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Hash(string str)
        {
            return Hash(str, DefaultHashName, DefaultEncoding);
        }

        /// <summary>
        /// 计算指定字符串的哈希值
        /// </summary>
        /// <param name="str"></param>
        /// <param name="hashName">hash名称，如sha1,sha256,md5等</param>
        /// <param name="e"></param>
        /// <returns></returns>
        public static string Hash(string str, string hashName, Encoding e)
        {
            HashAlgorithm algorithm = HashAlgorithm.Create(hashName);

            byte[] bytes = e.GetBytes(str);
            byte[] newBytes = algorithm.ComputeHash(bytes);
            algorithm.Clear();

            return EncryptedBytesToString(newBytes);
        }

        #endregion

        #region Asymmetric

        public static bool AsyPaddingMehtod = false;
        public static StoreName StoreName = StoreName.My;
        public static StoreLocation StoreLocation = StoreLocation.LocalMachine;
        public static string SubjectName = "ccitu.com";


        public static string AsyEncrypt(string str)
        {
            return AsyEncrypt(str, DefaultEncoding);
        }

        public static string AsyEncrypt(string str, Encoding e)
        {
            byte[] bytes = e.GetBytes(str);
            byte[] ebytes = AsyEncrypt(bytes);
            return EncryptedBytesToString(ebytes);
        }

        public static byte[] AsyEncrypt(byte[] bytes)
        {
            if (bytes.Length > 117)
            {
                throw new Exception("sorry,bytes more than 117 bytes");
            }

            RSACryptoServiceProvider rsa = CreateRSA(true);


            byte[] ebytes = rsa.Encrypt(bytes, AsyPaddingMehtod);
            rsa.Clear();
            return ebytes;
        }

        public static string AsyDecrypt(string str)
        {
            return AsyDecrypt(str, DefaultEncoding);
        }

        public static string AsyDecrypt(string str, Encoding e)
        {
            byte[] ebytes = StringToEncryptedBytes(str);
            byte[] bytes = AsyDecrypt(ebytes);
            return e.GetString(bytes);
        }

        public static byte[] AsyDecrypt(byte[] ebytes)
        {
            RSACryptoServiceProvider rsa = CreateRSA(false);
            byte[] bytes = rsa.Decrypt(ebytes, AsyPaddingMehtod);
            rsa.Clear();
            return bytes;
        }

        private static X509Certificate2 GetX509Certificate()
        {
            X509Store x509Store = new X509Store(StoreName, StoreLocation);
            x509Store.Open(OpenFlags.ReadOnly);

            X509Certificate2Collection certCol = x509Store.Certificates;
            certCol = certCol.Find(X509FindType.FindBySubjectName, SubjectName, false);

            if (certCol.Count == 0)
            {
                throw new Exception("The X.509 Spalanding certificate could not be found.");
            }

            X509Certificate2 cert = certCol[0];
            x509Store.Close();

            return cert;
        }

        private static RSACryptoServiceProvider CreateRSA(bool isPublicKey)
        {
            RSACryptoServiceProvider rsa;
            X509Certificate2 cert = GetX509Certificate();

            if (isPublicKey)
            {
                rsa = (RSACryptoServiceProvider)cert.PublicKey.Key;
            }
            else
            {
                rsa = (RSACryptoServiceProvider)cert.PrivateKey;
            }

            return rsa;
        }

        #endregion

        #region Symmetirc

        public static byte[] IV = new byte[] { 211, 34, 37, 184, 231, 80, 90, 60, 54, 83, 45, 215, 73, 88, 195, 168 };
        public static byte[] SymEncryptedKey;
        public static PaddingMode SymPaddingMode = PaddingMode.PKCS7;
        public static string SymmetircName = "RijnDael";

        public static string SymEncrypt(string str)
        {
            return SymEncrypt(str, DefaultEncoding);
        }

        public static string SymEncrypt(string str, Encoding e)
        {
            byte[] bytes = e.GetBytes(str);
            byte[] ebytes = SymEncrypt(bytes);
            return EncryptedBytesToString(ebytes);
        }

        public static byte[] SymEncrypt(byte[] bytes)
        {
            SymmetricAlgorithm sym = CreateSymmetric();
            ICryptoTransform ict = sym.CreateEncryptor();
            sym.Clear();

            byte[] ebytes = Transform(bytes, ict);
            ict.Dispose();

            return ebytes;
        }


        public static string SymDecrypt(string str)
        {
            return SymDecrypt(str, DefaultEncoding);
        }

        public static string SymDecrypt(string str, Encoding e)
        {
            byte[] ebytes = StringToEncryptedBytes(str);
            byte[] bytes = SymDecrypt(ebytes);
            return e.GetString(bytes);
        }

        public static byte[] SymDecrypt(byte[] ebytes)
        {
            SymmetricAlgorithm sym = CreateSymmetric();
            ICryptoTransform ict = sym.CreateDecryptor();
            sym.Clear();

            byte[] bytes = Transform(ebytes, ict);
            ict.Dispose();

            return bytes;
        }

        private static SymmetricAlgorithm CreateSymmetric()
        {
            SymmetricAlgorithm sym = SymmetricAlgorithm.Create(SymmetircName);
            sym.IV = IV;
            //byte[] key = AsyDecrypt(SymEncryptedKey);
            byte[] key = new byte[] { 198, 182, 78, 106, 211, 21, 121, 191, 196, 34, 17, 187, 251, 182, 3, 45 }; //todo
            sym.Key = key;
            sym.Padding = SymPaddingMode;

            return sym;
        }

        private static byte[] Transform(byte[] bytes, ICryptoTransform ict)
        {
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, ict, CryptoStreamMode.Write);
            cs.Write(bytes, 0, bytes.Length);
            cs.Flush();
            cs.FlushFinalBlock();

            int length = (int)ms.Length;
            byte[] ebytes = new byte[length];
            ms.Position = 0;
            ms.Read(ebytes, 0, length);

            ms.Dispose();
            cs.Dispose();

            return ebytes;
        }

        #endregion

        #region Help Method

        private static string EncryptedBytesToString(byte[] encryptedBytes)
        {
            return BitConverter.ToString(encryptedBytes).Replace("-", "");
        }

        private static byte[] StringToEncryptedBytes(string str)
        {
            int length = str.Length / 2;

            byte[] bytes = new byte[length];

            for (int i = 0; i < length; i++)
            {
                byte b = Convert.ToByte(str.Substring(i * 2, 2), 16);
                bytes[i] = b;
            }
            return bytes;
        }

        /// <summary>
        /// 生成6位盐值
        /// </summary>
        /// <returns></returns>
        public static string CreateSalt()
        {
            return CreateRandomString(6);
        }

        const string Ss = "123456789abcdefghijklmnopqrstuvwxyz";

        /// <summary>
        /// 生成指定位数的随机字符串
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string CreateRandomString(int length)
        {
            StringBuilder sb = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                int index = CreateRandomNumber(0, Ss.Length - 1);
                sb.Append(Ss[index]);
            }
            return sb.ToString();
        }

        /// <summary>
        /// 生成指定位数的数字
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int CreateRandomNumber(int min, int max)
        {
            RandomNumberGenerator random = RandomNumberGenerator.Create();
            byte[] bytes = new byte[1];
            random.GetBytes(bytes);

            Random r = new Random(bytes[0]);
            return r.Next(min, max);
        }

        #endregion
    }
}
