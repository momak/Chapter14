using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Signaling
{
    class Program
    {
        static void Main(string[] args)
        {
            var signal = new ManualResetEvent(false);

            new Thread(() =>
            {
                Console.WriteLine($"Waiting for signal _ {DateTime.Now:T}");
                signal.WaitOne();
                Console.WriteLine($"Waiting Finished _ {DateTime.Now:T}");
                signal.Dispose();
                Console.WriteLine($"Got Signal _ {DateTime.Now:T}");
            }).Start();

            Console.WriteLine($"Main going to sleep {DateTime.Now:T}");
            Thread.Sleep(2000);
            Console.WriteLine($"Main wake up {DateTime.Now:T}");

            signal.Set();
            Console.WriteLine($"Main Signal Set {DateTime.Now:T}");

            Console.ReadLine();

        }
    }
}
