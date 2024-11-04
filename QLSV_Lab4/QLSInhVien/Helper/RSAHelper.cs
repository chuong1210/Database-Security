using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
namespace QLSInhVien.Helper
{
   
    public class RSAHelper
    {
   


 



        private byte[] HashPasswordMD5(string password)
        {
            using (MD5 md5 = MD5.Create())
            {
                return md5.ComputeHash(Encoding.ASCII.GetBytes(password));
            }
        }

        public static byte[] HashPasswordSHA1(string password)
        {
            using (SHA1 sha1 = SHA1.Create())
            {
                return sha1.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
        public static byte[] HashPasswordByteSHA1(byte[] password)
        {
            string passwordString = Encoding.UTF8.GetString(password);
            return HashPasswordSHA1(passwordString); 
        }

        //public static byte[] EncryptWithRSA(decimal luongCB, string publicKey)
        //{
        //    using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(512))
        //    {
        //        rsa.FromXmlString(publicKey);
        //        byte[] salaryBytes = Encoding.UTF8.GetBytes(luongCB.ToString());
        //        return rsa.Encrypt(salaryBytes, false);
        //    }
        //}

        public static RSACryptoServiceProvider GetRSAPublicKey(string publicKey)
        {
            var rsa = new RSACryptoServiceProvider(512);
            rsa.FromXmlString(publicKey);
            return rsa;
        }
        public static RSACryptoServiceProvider GetRSAPrivateKey(string privateKey)
        {
            var rsa = new RSACryptoServiceProvider(512);
            rsa.FromXmlString(privateKey);
            return rsa;
        }
        public static byte[] EncryptWithRSA(decimal luongCB, string publicKey)
        {
            using (var rsa = GetRSAPublicKey(publicKey))
            {
                byte[] salaryBytes = Encoding.UTF8.GetBytes(luongCB.ToString());
                return rsa.Encrypt(salaryBytes, RSAEncryptionPadding.Pkcs1); // Using PKCS1 padding
            }
        }

   
        public static byte[] EncryptScore(decimal score, string publicKey)
        {
            using (var rsa = GetRSAPublicKey(publicKey))
            {
                byte[] scoreBytes = Encoding.UTF8.GetBytes(score.ToString());
                byte[] encryptedScore = rsa.Encrypt(scoreBytes, RSAEncryptionPadding.Pkcs1);

                return encryptedScore;
            }
        }


        public static decimal DecryptSalary(byte[] salaryBytes, string privateKey)
        {
            using (var rsa = GetRSAPrivateKey(privateKey))
            {
                try
                {
                    // Ensure the same padding mode is used here
                    byte[] decryptedBytes = rsa.Decrypt(salaryBytes, RSAEncryptionPadding.Pkcs1); // Using PKCS1 padding
                    string decryptedSalary = Encoding.UTF8.GetString(decryptedBytes);
                    return decimal.Parse(decryptedSalary); 
                }
                catch (CryptographicException ex)
                {
                    Console.WriteLine($"Decryption failed: {ex.Message}");
                    throw;
                }
            }
        }

        public static byte[] EncryptScore(string score, string publicKey)
        {
            using (var rsa = new RSACryptoServiceProvider(512))
            {
                rsa.FromXmlString(publicKey);
                byte[] scoreBytes = Encoding.UTF8.GetBytes(score);
                return rsa.Encrypt(scoreBytes, false);
            }
        }

        public static string DecryptScore(byte[] dataToDecrypt, string privateKey)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(512))
            {
                rsa.FromXmlString(privateKey);
                byte[] decryptedBytes = rsa.Decrypt(dataToDecrypt, false);
                return Encoding.UTF8.GetString(decryptedBytes);
            }
        }
    }










}

