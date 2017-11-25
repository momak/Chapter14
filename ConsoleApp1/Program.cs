using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(WriteY);          // Kick off a new thread 
            t.Name = "Y";
            t.Start();                               // running WriteY()
                                                     // Simultaneously, do something on the main thread. 
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine(Thread.CurrentThread.Name);
                //Console.WriteLine("X"+ i.ToString());
            }

            Console.ReadLine();
        }

        static void WriteY()
        {
            for (int i = 0; i < 1000; i++)
            {
                //Console.WriteLine("Y"+ i.ToString());
                Console.WriteLine(Thread.CurrentThread.Name);
            }
        }
    }
}
