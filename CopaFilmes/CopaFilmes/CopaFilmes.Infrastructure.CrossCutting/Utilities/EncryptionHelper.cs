using Microsoft.Extensions.Options;
using System;
using System.Security.Cryptography;
using System.Text;

namespace CopaFilmes.Infrastructure.CrossCutting.Utilities
{
    public class EncryptionHelper
    {
        private readonly IOptions<KeysConfig> ChaveConfiguracao;
        DESCryptoServiceProvider encryptionProvider = null;

        public EncryptionHelper(IOptions<KeysConfig> chaveConfiguracao)
        {
            ChaveConfiguracao = chaveConfiguracao;

            encryptionProvider = new DESCryptoServiceProvider();
            encryptionProvider.KeySize = 64;

            encryptionProvider.IV = Convert.FromBase64String(ChaveConfiguracao.Value.CryptoVector);
            encryptionProvider.Key = Convert.FromBase64String(ChaveConfiguracao.Value.CryptoKey);
        }

        public string Criptografar(string text)
        {
            StringBuilder returnText = new StringBuilder();

            char[] convertContent = text.ToCharArray();
            byte[] convertedContent = new byte[convertContent.Length];

            int indexAC = 0;
            foreach (char symbol in convertContent) {
                convertedContent[indexAC] = Convert.ToByte(symbol);
                indexAC++;
            }

            byte[] returnContent = encryptionProvider.CreateEncryptor().TransformFinalBlock(convertedContent, 0, convertedContent.Length);

            return Convert.ToBase64String(returnContent);
        }

        public string Descriptografar(string text)
        {
            byte[] encryptedContent = Convert.FromBase64String(text);

            byte[] convertContent = encryptionProvider.CreateDecryptor().TransformFinalBlock(encryptedContent, 0, encryptedContent.Length);
            StringBuilder convertedContent = new StringBuilder();

            foreach (byte symbol in convertContent) {
                convertedContent.Append(Convert.ToChar(symbol));
            }

            return convertedContent.ToString();
        }
    }
}
