using System;
using System.Collections.Generic;
using System.Text;

namespace TransactionPool
{
    public interface IKeyStore
    {

        byte[] AuthenticatedHashKey { get; set; }
        string signBlock(string blockHash);
        bool verifyBlock(string blockHash, string signature);

    }
}
