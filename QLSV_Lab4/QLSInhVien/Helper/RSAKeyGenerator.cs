using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace QLSInhVien.Helper
{

    public class RSAKeyGenerator
    {
        public static (string publicKey, string privateKey) GenerateKeys()
        {
            using (var rsa = new RSACryptoServiceProvider(512))
            {
                // Lấy public key và private key dưới dạng chuỗi XML
                string publicKey = rsa.ToXmlString(false); // Chỉ lấy public key
                string privateKey = rsa.ToXmlString(true); // Lấy cả public và private key
                return (publicKey, privateKey);
            }
        }


        public static string GeneratePublicKey(string secretKey)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(512))
            {
                string publicKey = rsa.ToXmlString(false); 
                return publicKey;
            }
        }
    }

}
