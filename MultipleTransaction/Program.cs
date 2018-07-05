using System;

namespace MultipleTransaction
{
    class Program
    {
        static void Main(string[] args)
        {

            ITransaction t1 = new Transaction(1, "In the End", "Hybrid Theory", "Linkin Park", "Warner Bros Records", 13);
            ITransaction t2 = new Transaction(2, "Faint", "Meteora", "Linkin Park", "Warner Bros Records", 13);
            ITransaction t3 = new Transaction(3, "Black or White", "Disc one: History Begins", "Michael Jackson", "MJJ Productions", 100);
            ITransaction t4 = new Transaction(4, "Smells Like Teen Spirit", "Nevermind", "Kurt Gobain", "DGC", 33);
            ITransaction t5 = new Transaction(5, "Comfortably Numb", "Pink Floyd Discography", "David Gilmour", "Harvest", 12);
            ITransaction t6 = new Transaction(6, "Stairway to Heaven", "Led Zepplin IV", "Jimmy Page", "Atlantic", 25);
            ITransaction t7 = new Transaction(7, "Ace of Spades", "Ace of Spades", "Motorhead", "Bronze Records", 100);
            ITransaction t8 = new Transaction(8, "Unnamed Feeling", "St. Anger", "Metallica", "Elektra", 25);

            IBlock b1 = new Block(0);
            IBlock b2 = new Block(1);
            IBlock b3 = new Block(2);
            IBlock b4 = new Block(3);

            b1.addTransactionToChain(t1);
            b1.addTransactionToChain(t2);
            b2.addTransactionToChain(t3);
            b2.addTransactionToChain(t4);
            b3.addTransactionToChain(t5);
            b3.addTransactionToChain(t6);
            b4.addTransactionToChain(t7);
            b4.addTransactionToChain(t8);

            b1.setblockHashOfBlock(null);
            b2.setblockHashOfBlock(b1);
            b3.setblockHashOfBlock(b2);
            b4.setblockHashOfBlock(b3);

            Blockchain blockchainObj = new Blockchain();
            blockchainObj.acceptBlockInChain(b1);
            blockchainObj.acceptBlockInChain(b2);
            blockchainObj.acceptBlockInChain(b3);
            blockchainObj.acceptBlockInChain(b4);

            blockchainObj.verifyIfChainIsValid();

            t7.SongName = "Love Me like a Reptile";

            blockchainObj.verifyIfChainIsValid();

            Console.WriteLine();
            
        }

    }

}
