using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Locking
{
    class Program
    {
        #region Lock
        //private static bool _done;
        //static readonly  object _locker = new object();
        //static void Main(string[] args)
        //{
        //    new Thread(Go).Start();
        //    Go();

        //    Console.ReadLine();
        //}

        //private static void Go()
        //{
        //    lock (_locker)
        //    {
        //        if (!_done)
        //        {
        //            Console.WriteLine("Done");
        //            _done = true;

        //        }
        //    }
        //} 
        #endregion

        #region PassDataToThread

        //static void Main()
        //{
        //    Thread t = new Thread(()=> Print("Hello from thread t"));
        //    t.Start();

        //    Console.ReadLine();
        //}

        //private static void Print(string message)
        //{
        //    Console.WriteLine(message);
        //}

        #endregion

        #region PassDataToThread 2

        //static void Main()
        //{
        //    Thread t = new Thread(Print);
        //    t.Start("Something");

        //    Console.ReadLine();
        //}

        //static void Print(object messageObj)
        //{
        //    string message = (string) messageObj;
        //    Console.WriteLine(message);
        //}

        #endregion

        #region Lambda

        //static void Main()
        //{

        //    for (int i = 0; i < 10; i++)
        //    {
        //        int temp = i;
        //        new Thread(() => Console.Write(temp)).Start();
        //    }


        //    Console.ReadLine();
        //}

        #endregion

        static void Main(string[] args)
        {
            Thread worker = new Thread(()=>Console.ReadLine());

            if (args.Length > 0)
                worker.IsBackground = true;
            worker.Start();
        }
    }
}
