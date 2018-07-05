using System;
using System.Collections.Generic;
using System.Text;

namespace BlockChain.ProofOfWork
{
    public class Program
    {

        static void Main(string[] args)
        {

            ProofOfWork pow0 = new ProofOfWork("Just Keep Livin *douchebag* !!!", 0);
            ProofOfWork pow1 = new ProofOfWork("Just Keep Livin *douchebag* !!!", 1);
            ProofOfWork pow2 = new ProofOfWork("Just Keep Livin *douchebag* !!!", 2);
            ProofOfWork pow3 = new ProofOfWork("Just Keep Livin *douchebag* !!!", 3);
            ProofOfWork pow4 = new ProofOfWork("Just Keep Livin *douchebag* !!!", 4);
            ProofOfWork pow5 = new ProofOfWork("Just Keep Livin *douchebag* !!!", 5);
            ProofOfWork pow6 = new ProofOfWork("Just Keep Livin *douchebag* !!!", 6);

            pow0.computeProofOfWork();
            pow1.computeProofOfWork();
            pow2.computeProofOfWork();
            pow3.computeProofOfWork();
            pow4.computeProofOfWork();
            pow5.computeProofOfWork();
            pow6.computeProofOfWork();

            Console.WriteLine("Done!!!");

        }

    }
}
