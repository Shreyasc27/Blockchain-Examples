using System;
using System.Collections.Generic;
using System.Text;

namespace TransactionPool
{
    public class TransactionPool
    {

        private readonly Queue<ITransaction> queue;

        public TransactionPool()
        {
            queue = new Queue<ITransaction>();
        }

        public void AddTransaction(ITransaction transaction)
        {
            queue.Enqueue(transaction);
        }

        public ITransaction GetTransaction()
        {
            return queue.Dequeue();
        }

    }

}
