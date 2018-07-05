using System;
using System.Collections.Generic;
using System.Text;

namespace MultipleTransaction
{
    public interface IBlockchain
    {

        void acceptBlockInChain(IBlock block);

        int NextBlockNumber { get;  }

        void verifyIfChainIsValid();

    }

}
