using BlockChain.SingleTransaction;
using Clifton.Blockchain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultipleTransaction
{
    public class Block : IBlock
    {

        public List<ITransaction> Transaction;

        public int BlockNumber { get; set; }
        public DateTime BlockCreationDate { get; set; }
        public string CurrentBlockHash { get; set; }
        public string PreviousBlockHash { get; set; }
        public IBlock NextBlock { get; set; }

        public MerkleTree merkleTreeObj = new MerkleTree();

        List<ITransaction> IBlock.Transaction => throw new NotImplementedException();

        public Block(int blockNumber)
        {

            BlockNumber = blockNumber;

            BlockCreationDate = DateTime.Now;
            Transaction = new List<ITransaction>();

        }

        public void addTransactionToChain(ITransaction transaction)
        {

            Transaction.Add(transaction);

        }

        public string calculateBlockHash(string previousBlockHash)
        {

            string blockHeaderHash = BlockNumber + BlockCreationDate.ToString() + previousBlockHash;
            string finalBlockHash = merkleTreeObj.RootNode + blockHeaderHash;

            return Convert.ToBase64String(HashData.ComputeHashSha256(Encoding.UTF8.GetBytes(finalBlockHash)));

        }

        public bool isValidChain(string parentBlockHash, bool verbose)
        {

            bool isValid = true;

            BuildMerkleTree();

            string newBlockHash = calculateBlockHash(parentBlockHash);

            if (newBlockHash != CurrentBlockHash)
            {

                isValid = false;

            }
            else
            {

                isValid = true;
                PreviousBlockHash = parentBlockHash;

            }

            displayBlockValidity(verbose, isValid);

            if (NextBlock != null)
            {

                return NextBlock.isValidChain(newBlockHash, verbose);

            }

            return isValid;

        }

        public void setblockHashOfBlock(IBlock parentBlock)
        {

            if (parentBlock != null)
            {

                PreviousBlockHash = parentBlock.CurrentBlockHash;
                parentBlock.NextBlock = this;

            }
            else
            {

                PreviousBlockHash = null;

            }

            BuildMerkleTree();

            CurrentBlockHash = calculateBlockHash(PreviousBlockHash);

        }

        public void BuildMerkleTree()
        {

            merkleTreeObj = new MerkleTree();

            foreach (ITransaction transaction in Transaction)
            {
                merkleTreeObj.AppendLeaf(MerkleHash.Create(transaction.CalculateTransactionHash()));
            }

            merkleTreeObj.BuildTree();

        }

        private void displayBlockValidity(bool verbose, bool isValid)
        {

            if (verbose)
            {

                if (isValid)
                {

                    Console.WriteLine("Block [" + BlockNumber + "] : Valid block on the chain!");

                }
                else
                {

                    Console.WriteLine("Block [" + BlockNumber + "] : Invalid block on the chain!");

                }

            }

        }

    }

}
