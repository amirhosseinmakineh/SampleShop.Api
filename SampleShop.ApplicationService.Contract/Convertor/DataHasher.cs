using System.Security.Cryptography;
using System.Text;

namespace SampleShop.ApplicationService.Contract.Convertor
{
    public class DataHasher
    {
        private static string Generate(string plainText,string hashType)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(plainText);
            byte[] hash = HashAlgorithm.Create(hashType).ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
        public static string HashData(string plainText)
        {
            return Generate(plainText, nameof(HashType.MD5)) + Generate(plainText.Substring(0, plainText.Length / 2), nameof(HashType.SHA512));
        }
    }
}
