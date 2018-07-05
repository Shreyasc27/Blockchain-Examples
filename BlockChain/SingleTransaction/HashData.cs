using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace BlockChain.SingleTransaction
{
    public class HashData
    {
        public static byte[] ComputeHashSha256(byte[] toBeHashed)
        {
            using (var sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(toBeHashed);
            }
        }

        /*Hash Message Authentication Codes*/
        public static string ComputeAuthenticatedHashSha256(string toBeHashed, string key)
        {
            
            var keyToBeUsed = Encoding.UTF8.GetBytes(key);
            var messageToHash = Encoding.UTF8.GetBytes(toBeHashed);

            using (var hmac = new HMACSHA256(keyToBeUsed))
            {

                return Convert.ToBase64String(hmac.ComputeHash(messageToHash));

            }

        }

    }
}
