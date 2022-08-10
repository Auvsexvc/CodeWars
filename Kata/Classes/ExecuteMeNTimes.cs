using NUnit.Framework;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Kata.Classes
{
    public class ExecuteMeNTimes
    {
        public void Execute(Action a, int nTimes)
        {
            Action[] actions = new Action[nTimes];
            for (int i = 0; i < nTimes; i++)
            {
                actions[i] = a;
            }
            Parallel.Invoke(actions);
        }

        public void Execute2(Action a, int nTimes)
        {
            Parallel.For(0, nTimes, i => a());
        }

        public void Execute3(Action a, int nTimes)
        {
            Task.WaitAll(Enumerable.Repeat(1, nTimes).Select(i => Task.Factory.StartNew(a)).ToArray());
        }

    }

    [TestFixture]
    public class ExecuteMeNTimesTest
    {
        private readonly object monitor = new object();

        [Test]
        public void SampleTests()
        {
            ExecuteMeNTimes w = new ExecuteMeNTimes();
            Random rand = new Random();
            int counter = 20;
            int executionCounter = 0;
            Action a = () =>
            {
                Console.Write('.');
                Thread.Sleep(1000);
                lock (monitor) { executionCounter++; }
            };
            w.Execute(a, 20);
            if (counter != executionCounter)
                Console.WriteLine($"Action was executed {executionCounter} times instead of {counter} times");
            Assert.IsTrue(counter == executionCounter);
        }
    }
}