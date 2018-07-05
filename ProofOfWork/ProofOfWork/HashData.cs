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

    }
}
