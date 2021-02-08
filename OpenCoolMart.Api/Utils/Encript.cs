using System.Security.Cryptography;
using System.Text;

namespace OpenCoolMart.Api.Utils
{
    public class Encript
    {
        
        public static string GetSHA256(string str)
        {
            var sha256 = SHA256Managed.Create();
            var encoding = new ASCIIEncoding();
            byte[] stream = null;
            var sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
    }
}