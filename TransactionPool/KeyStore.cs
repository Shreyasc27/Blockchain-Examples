using System;
using System.Collections.Generic;
using System.Text;

namespace TransactionPool
{
    class KeyStore : IKeyStore
    {
        private DigitalSignature DigitalSignature { get; set; }
        public byte[] AuthenticatedHashKey { get; set; }
        
        public KeyStore(byte[] authenticatedHashKey)
        {

            AuthenticatedHashKey = authenticatedHashKey;
            DigitalSignature = new DigitalSignature();
            DigitalSignature.AssignNewKey();

        }

        public string signBlock(string blockHashToSign)
        {

            return Convert.ToBase64String(DigitalSignature.SignData(Convert.FromBase64String(blockHashToSign)));
            
        }

        public bool verifyBlock(string blockHashToSign, string signature)
        {

            return DigitalSignature.VerifySignature(Convert.FromBase64String(blockHashToSign), Convert.FromBase64String(signature));

        }

    }

}
