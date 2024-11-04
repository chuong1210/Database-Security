using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace QLSInhVien.Helper
{

    public class RSAKeyGenerator
    {


        UnicodeEncoding ByteConverter = new UnicodeEncoding();
        RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
        byte[] plaintext;
        byte[] encryptedtext;


        public static byte[] EncryptPrivateKey(string privateKey, string password)
        {
            using (Aes aes = Aes.Create())
            {
                // Thiết lập key và IV dựa trên password
                byte[] key = new Rfc2898DeriveBytes(password, new byte[16]).GetBytes(32);
                aes.Key = key;
                aes.IV = new byte[16];

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        byte[] privateKeyBytes = Encoding.UTF8.GetBytes(privateKey);
                        cs.Write(privateKeyBytes, 0, privateKeyBytes.Length);
                    }
                    return ms.ToArray();
                }
            }
        }



  
        public static (RSAParameters,RSAParameters) GenerateKeys()
        {
            string base64PublicKey = "";
            RSAParameters publicKey; RSAParameters privateKey;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(512)) // Adjust key size as needed
            {
                publicKey = rsa.ExportParameters(false);
                privateKey = rsa.ExportParameters(true);
                // base64PublicKey = Convert.ToBase64String(RSAKeyGenerator.SerializeRSAParameters(publicKey));
                //publicKey = DeserializeRSAParameters(SerializeRSAParameters(publicKey));
            }
            return (publicKey,privateKey);
        }
        public static string RSAParametersToXmlString(RSAParameters parameters, bool includePrivateParameters)
        {
            using (var rsa = new RSACryptoServiceProvider(512))
            {
                rsa.ImportParameters(parameters);
                return rsa.ToXmlString(includePrivateParameters);
            }
        }
        public static RSAParameters XmlStringToRSAParameters(string xmlString, bool includePrivateParameters)
        {
            using (var rsa = new RSACryptoServiceProvider(512))
            {
                rsa.FromXmlString(xmlString);
                return rsa.ExportParameters(includePrivateParameters);
            }
        }
        public static byte[] SerializeRSAParameters(RSAParameters parameters)
        {
            using (var ms = new MemoryStream())
            {
                try
                {
                    // Important: Use a suitable serialization library like BinaryFormatter
                    // or Protobuf for more complex scenarios and security.
                    // For simple scenarios, a straightforward approach is better.


                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(ms, parameters);
                    return ms.ToArray();
                }
                catch (SerializationException ex)
                {
                    // Log or handle the error
                    Console.WriteLine("Serialization error: " + ex.Message);
                    return null;
                }
                catch (Exception ex)
                {
                    //Log or handle generic error
                    Console.WriteLine("Error during serialization: " + ex.Message);
                    return null;
                }
            }
        }
        public static RSAParameters DeserializeRSAParameters(byte[] parametersBytes)
        {
            using (var ms = new MemoryStream(parametersBytes))
            {
                var bf = new BinaryFormatter();
                return (RSAParameters)bf.Deserialize(ms);
            }
        }


        static public byte[] Encryption(byte[] Data, RSAParameters RSAKey, bool DoOAEPPadding)
        {
            try
            {
                byte[] encryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(RSAKey);
                    encryptedData = RSA.Encrypt(Data, DoOAEPPadding);
                }
                return encryptedData;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);

                return null;
            }

        }

        static public byte[] Decryption(byte[] Data, RSAParameters RSAKey, bool DoOAEPPadding)
        {
            try
            {
                byte[] decryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(RSAKey);
                    decryptedData = RSA.Decrypt(Data, DoOAEPPadding);
                }
                return decryptedData;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.ToString());

                return null;
            }

        }


    }


}
