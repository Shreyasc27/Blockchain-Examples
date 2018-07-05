using BlockChain.SingleTransaction;
using System;

namespace BlockChain
{
    class Program
    {
        static void Main(string[] args)
        {

            Blockchain chain = new Blockchain();

            IBlock block1 = new Block(1, 1111, "In the End", "Hybrid Theory", "Linkin Park", "Warner Bros Records", 16, DateTime.Now, null);
            IBlock block2 = new Block(2, 2222, "Faint", "Meteora", "Linkin Park", "Warner Bros Records", 16, DateTime.Now, block1);
            IBlock block3 = new Block(3, 3333, "Black or White", "Disc one: History Begins", "Michael Jackson", "MJJ Productions", 100, DateTime.Now, block2);
            IBlock block4 = new Block(4, 4444, "Smells Like Teen Spirit", "Nevermind", "Kurt Gobain", "DGC", 33, DateTime.Now, block3);
            IBlock block5 = new Block(5, 5555, "Comfortably Numb", "Pink Floyd Discography", "David Gilmour", "Harvest", 12, DateTime.Now, block4);
            IBlock block6 = new Block(6, 6666, "Stairway to Heaven", "Led Zepplin IV", "Jimmy Page", "Atlantic", 25, DateTime.Now, block5);

            chain.acceptBlockInChain(block1);
            chain.acceptBlockInChain(block2);
            chain.acceptBlockInChain(block3);
            chain.acceptBlockInChain(block4);
            chain.acceptBlockInChain(block5);
            chain.acceptBlockInChain(block6);

            chain.verifyIfChainIsValid();

            block4.ArtistOrBand = "Nirvana";

            chain.verifyIfChainIsValid();

            Console.WriteLine();
            
        }
    }
}
