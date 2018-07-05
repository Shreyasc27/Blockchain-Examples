using System;
using System.Collections.Generic;
using System.Text;

namespace TransactionPool
{
    public class Blockchain : IBlockchain
    {
        public IBlock CurrentBlock { get; set; }
        public IBlock PreviousBlock { get; set; }

        public List<IBlock> listOfBlocks { get; }

        public Blockchain()
        {

            listOfBlocks = new List<IBlock>();

        }

        public int NextBlockNumber
        {

            get
            {

                if (PreviousBlock == null)
                {
                    return 0;
                }

                return CurrentBlock.BlockNumber + 1;

            }

        }

        public void acceptBlockInChain(IBlock block)
        {

            if (PreviousBlock == null)
            {

                PreviousBlock = block;
                PreviousBlock.PreviousBlockHash = null;

            }

            CurrentBlock = block;
            listOfBlocks.Add(block);

        }

        public void verifyIfChainIsValid()
        {

            if (PreviousBlock == null)
            {

                throw new InvalidOperationException("Genesis block is not set.");

            }

            bool isValid = PreviousBlock.isValidChain(null, true);

            if (isValid)
            {

                Console.WriteLine("Blockchain is NOT tampered.\n\n\n");

            }
            else
            {

                Console.WriteLine("Blockchain is tampered.\n\n\n");

            }

        }

    }

}
