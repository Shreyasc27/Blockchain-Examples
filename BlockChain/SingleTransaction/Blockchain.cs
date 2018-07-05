using System;
using System.Collections.Generic;
using System.Text;

namespace BlockChain.SingleTransaction
{
    public class Blockchain : IBlockchain
    {

        public IBlock CurrentBlock { get; set; }

        public IBlock PreviousBlock { get; set; }

        public List<IBlock> Blocks { get; }

        public Blockchain()
        {

            Blocks = new List<IBlock>();

        }

        public void acceptBlockInChain(IBlock block)
        {

            if (PreviousBlock == null)
            {

                PreviousBlock = block;
                PreviousBlock.PreviousBlockHash = null;

            }

            CurrentBlock = block;
            Blocks.Add(block);

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
