using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Security.Cryptography;
using BlockChain.SingleTransaction;

namespace BlockChain.ProofOfWork
{
    public class ProofOfWork
    {

        public string InputToHash { get; private set; }

        public int ComplexityLevel { get; private set; }

        public int Nonce { get; private set; }

        public ProofOfWork(string inputToHash, int complexityLevel)
        {

            InputToHash = inputToHash;
            ComplexityLevel = complexityLevel;

        }

        private String numberOfStartingZeroes()
        {

            string numberOfZeroes = string.Empty;

            for (int count=0; count<ComplexityLevel; count++)
            {

                numberOfZeroes = numberOfZeroes + "0";

            }

            return numberOfZeroes;
            
        }

        public string computeProofOfWork()
        {

            string numberOfZeroes = numberOfStartingZeroes();

            Stopwatch stopWatchObj = new Stopwatch();
            stopWatchObj.Start();

            while (true)
            {

                string hashedData = Convert.ToBase64String(HashData.ComputeHashSha256(Encoding.UTF8.GetBytes(Nonce + InputToHash)));

                if (hashedData.StartsWith(numberOfZeroes, StringComparison.Ordinal))
                {

                    stopWatchObj.Stop();

                    TimeSpan timeSpanObj = stopWatchObj.Elapsed;
                    
                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", timeSpanObj.Hours, timeSpanObj.Minutes, timeSpanObj.Seconds, timeSpanObj.Milliseconds / 10);

                    Console.WriteLine("Complexity Level : [" + numberOfZeroes.Length + " Zeroes] ~ Nonce : [" + Nonce + "] ~ Elapsed : [" + elapsedTime + "] ~ [" + hashedData + "]");

                    return hashedData;

                }

                Nonce++;

            }

        }

    }
}
