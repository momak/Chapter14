using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(Go);
            t.Name = "Go thread";
            t.Start();
            t.Join();
            Console.WriteLine("thread go has finished");

            Console.ReadLine();
        }

        private static void Go()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine(Thread.CurrentThread.Name);
                Console.WriteLine(Thread.CurrentThread.ThreadState);
                Console.WriteLine(ThreadState.WaitSleepJoin);
            }
        }
    }
}
