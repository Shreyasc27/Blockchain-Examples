using System;
using System.Collections.Generic;
using System.Text;

namespace TransactionPool
{
    public interface IBlockchain
    {

        void acceptBlockInChain(IBlock block);
        int NextBlockNumber { get; }
        void verifyIfChainIsValid();

    }
}
