using System;
using System.Collections.Generic;

namespace TransactionPool
{
    class Program
    {

        static readonly TransactionPool transactionPool = new TransactionPool();

        static void Main(string[] args)
        {

            ITransaction transaction = SetupTransactions();
            IKeyStore keyStore = new KeyStore(Hmac.GenerateKey());

            IBlock b1 = new Block(0, keyStore, 3);
            IBlock b2 = new Block(1, keyStore, 3);
            IBlock b3 = new Block(2, keyStore, 3);
            IBlock b4 = new Block(3, keyStore, 3);

            List<IBlock> listOfBlock = new List<IBlock>();
            listOfBlock.Add(b1);
            listOfBlock.Add(b2);
            listOfBlock.Add(b3);
            listOfBlock.Add(b4);
                
            AddTransactionsToBlocksAndCalculateHashes(listOfBlock);

            Blockchain chain = new Blockchain();
            chain.acceptBlockInChain(b1);
            chain.acceptBlockInChain(b2);
            chain.acceptBlockInChain(b3);
            chain.acceptBlockInChain(b4);

            chain.verifyIfChainIsValid();
            
            transaction.ArtistOrBand = "Led Zepplin";

            chain.verifyIfChainIsValid();


            Console.WriteLine();

        }

        private static void AddTransactionsToBlocksAndCalculateHashes(List<IBlock> listOfBlock)
        {

            listOfBlock[0].addTransactionToChain(transactionPool.GetTransaction());
            listOfBlock[0].addTransactionToChain(transactionPool.GetTransaction());
            listOfBlock[1].addTransactionToChain(transactionPool.GetTransaction());
            listOfBlock[1].addTransactionToChain(transactionPool.GetTransaction());
            listOfBlock[2].addTransactionToChain(transactionPool.GetTransaction());
            listOfBlock[2].addTransactionToChain(transactionPool.GetTransaction());
            listOfBlock[3].addTransactionToChain(transactionPool.GetTransaction());
            listOfBlock[3].addTransactionToChain(transactionPool.GetTransaction());

            listOfBlock[0].setblockHashOfBlock(null);
            listOfBlock[1].setblockHashOfBlock(listOfBlock[0]);
            listOfBlock[2].setblockHashOfBlock(listOfBlock[1]);
            listOfBlock[3].setblockHashOfBlock(listOfBlock[2]);

        }

        private static ITransaction SetupTransactions()
        {

            ITransaction t1 = new Transaction(1, "In the End", "Hybrid Theory", "Linkin Park", "Warner Bros Records", 13);
            ITransaction t2 = new Transaction(2, "Faint", "Meteora", "Linkin Park", "Warner Bros Records", 13);
            ITransaction t3 = new Transaction(3, "Black or White", "Disc one: History Begins", "Michael Jackson", "MJJ Productions", 100);
            ITransaction t4 = new Transaction(4, "Smells Like Teen Spirit", "Nevermind", "Kurt Gobain", "DGC", 33);
            ITransaction t5 = new Transaction(5, "Comfortably Numb", "Pink Floyd Discography", "David Gilmour", "Harvest", 12);
            ITransaction t6 = new Transaction(6, "Stairway to Heaven", "Led Zepplin IV", "Jimmy Page", "Atlantic", 25);
            ITransaction t7 = new Transaction(7, "Ace of Spades", "Ace of Spades", "Motorhead", "Bronze Records", 100);
            ITransaction t8 = new Transaction(8, "Unnamed Feeling", "St. Anger", "Metallica", "Elektra", 25);

            transactionPool.AddTransaction(t1);
            transactionPool.AddTransaction(t2);
            transactionPool.AddTransaction(t3);
            transactionPool.AddTransaction(t4);
            transactionPool.AddTransaction(t5);
            transactionPool.AddTransaction(t6);
            transactionPool.AddTransaction(t7);
            transactionPool.AddTransaction(t8);

            return t6;

        }
        
    }

}
