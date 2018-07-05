using System;
using System.Collections.Generic;
using System.Text;

namespace BlockChain.SingleTransaction
{
    public interface IBlockchain
    {

        void acceptBlockInChain(IBlock block);

        void verifyIfChainIsValid();
        
    }
}
