using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPooling
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task.Run(() => Console.WriteLine("Hello from the thread pool"));//4.5 framework
            Task.Factory.StartNew(() => Console.WriteLine("Hello from the thread pool"));
            ThreadPool.QueueUserWorkItem(notUserd => Console.WriteLine("Hello from the thread pool"));

        }
    }
}
