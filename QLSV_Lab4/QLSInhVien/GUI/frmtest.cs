using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using QLSInhVien.Helper;
namespace QLSInhVien.GUI
{
    public partial class frmtest : Form
    {
        public frmtest()
        {
            InitializeComponent();
            GenerateKeys();
        }

        private RSAParameters publicKey;
        private RSAParameters privateKey;
        private byte[] SerializeRSAParameters(RSAParameters parameters)
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


        private RSAParameters DeserializeRSAParameters(byte[] parametersBytes)
        {
            using (var ms = new MemoryStream(parametersBytes))
            {
                var bf = new BinaryFormatter();
                return (RSAParameters)bf.Deserialize(ms);
            }
        }
        private void GenerateKeys()
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(512)) // Adjust key size as needed
            {
                publicKey = rsa.ExportParameters(false);
                privateKey = rsa.ExportParameters(true);
              //  string base64PublicKey = Convert.ToBase64String(SerializeRSAParameters(publicKey));
                //publicKey = DeserializeRSAParameters(SerializeRSAParameters(publicKey));
             

            }
        }

        static public byte[] Encryption(byte[] Data, RSAParameters RSAKey, bool DoOAEPPadding)
        {
            try
            {
                byte[] encryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(512))
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
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(512))
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


        UnicodeEncoding ByteConverter = new UnicodeEncoding();
        RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(512 );
        byte[] plaintext;
        byte[] encryptedtext;

        private void button1_Click(object sender, EventArgs e)
        {
            plaintext = ByteConverter.GetBytes(txtplain.Text);

            string publicKeyXml = RSAParametersToXmlString(publicKey, false);
            RSAParameters publicKeyFromXml = XmlStringToRSAParameters(publicKeyXml, false);

            encryptedtext = Encryption(plaintext, publicKey, false);
            txtencrypt.Text = ByteConverter.GetString(encryptedtext);
        }

        public string RSAParametersToXmlString(RSAParameters parameters, bool includePrivateParameters)
        {
            using (var rsa = new RSACryptoServiceProvider(512))
            {
                rsa.ImportParameters(parameters);
                return rsa.ToXmlString(includePrivateParameters);
            }
        }
        public RSAParameters XmlStringToRSAParameters(string xmlString, bool includePrivateParameters)
        {
            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(xmlString);
                return rsa.ExportParameters(includePrivateParameters);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string privateKeyXml = RSAParametersToXmlString(privateKey, true);
            RSAParameters privateKey2 = XmlStringToRSAParameters(privateKeyXml,true);

            byte[] decryptedtex = Decryption(encryptedtext, privateKey2, false);
            txtdecrypt.Text = ByteConverter.GetString(decryptedtex);
        }
    }
}
