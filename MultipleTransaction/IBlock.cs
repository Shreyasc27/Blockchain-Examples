using System;
using System.Collections.Generic;
using System.Text;

namespace MultipleTransaction
{
    public interface IBlock
    {

        List<ITransaction> Transaction { get; }

        /*Block details*/
        int BlockNumber { get; set; }
        DateTime BlockCreationDate { get; set; }
        string CurrentBlockHash { get; set; }
        string PreviousBlockHash { get; set; }

        /*Transaction details*/
        void addTransactionToChain(ITransaction transaction);
        string calculateBlockHash(string previousBlockHash);
        void setblockHashOfBlock(IBlock parent);
        IBlock NextBlock { get; set; }
        bool isValidChain(string prevBlockHash, bool verbose);

    }

}
