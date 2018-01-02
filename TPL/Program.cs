using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPL
{
    class Program
    {
        #region TPL

        //static void Main(string[] args)
        //{
        //    Task.Run(() => Console.WriteLine("Something"));

        //    Task task = Task.Run(() =>
        //    {
        //        Thread.Sleep(2000);
        //        Console.WriteLine("Foooo");

        //    });

        //    Console.WriteLine(task.IsCompleted);
        //    task.Wait();

        //    Task<int> t = Task.Run(() =>
        //    {
        //        Console.WriteLine("Starting task");
        //        Thread.Sleep(2000);
        //        Console.WriteLine("Wake up");
        //        return 3;
        //    });

        //    int result = t.Result;
        //    Console.WriteLine($"Result from task {result}");


        //    Task<int> tPrime = Task.Run(() =>
        //        Enumerable.Range(2, 3000000).Count(n =>
        //         Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)));


        //    Console.WriteLine("Task running ------");
        //    Console.WriteLine($"Prime numbers  {tPrime.Result}");

        //    Console.ReadLine(); 
        //   
        //}

        #endregion

        #region Continuation

        //static void Main(string[] args)
        //{
        //    Task<int> tPrime = Task.Run(() =>
        //            Enumerable.Range(2, 3000000).Count(n =>
        //             Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)));

        //    var awaiter = tPrime.ConfigureAwait(false).GetAwaiter();
        //    awaiter.OnCompleted(() =>
        //    {
        //        int result = awaiter.GetResult();
        //        Console.WriteLine(result);
        //    });

        //    tPrime.ContinueWith(antecedent =>
        //    {
        //        int r = antecedent.Result;
        //        Console.WriteLine(r);
        //    });


        //    Console.ReadLine();

        //}

        #endregion

        #region TaskCompletioSource

        //static void Main()
        //{
        //var tcs = new TaskCompletionSource<int>();

        //new Thread(() =>
        //{
        //    Thread.Sleep(5000);
        //    tcs.SetResult(42);
        //})
        //{ IsBackground = true }.Start();

        //Task<int> task = tcs.Task;
        //Console.WriteLine(task.Result);


        //    var awaiter = GetAnswersToLife().GetAwaiter();
        //    awaiter.OnCompleted(() => Console.WriteLine(awaiter.GetResult()));

        //    for (int i = 0; i < 10000; i++)
        //    {
        //        int temp = i;
        //        Delay(5000).GetAwaiter().OnCompleted(() => Console.WriteLine(temp));
        //    }



        //    Console.ReadLine();
        //}

        //static Task Delay(int miliseconds)
        //{
        //    var tsc = new TaskCompletionSource<object>();

        //    var timer = new System.Timers.Timer(miliseconds) { AutoReset = false };
        //    timer.Elapsed += delegate { timer.Dispose(); tsc.SetResult(null); };
        //    timer.Start();
        //    return tsc.Task;
        //}
        //static Task<int> GetAnswersToLife()
        //{
        //    var tsc = new TaskCompletionSource<int>();

        //    var timer = new System.Timers.Timer(5000)
        //    { AutoReset = false };
        //    timer.Elapsed += delegate { timer.Dispose(); tsc.SetResult(42); };
        //    timer.Start();
        //    return tsc.Task;
        //}
        #endregion


        #region Async

        //static void Main()
        //{
        //    Task.Run(() => DisplayPrimeCountsAsync());

        //    Console.ReadLine();
        //}

        //static int GetPrimesCount(int start, int count)
        //{
        //    return
        //        ParallelEnumerable.Range(start, count).Count(n =>
        //        Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0));
        //}

        //static Task<int> GetPrimesCountAsync(int start, int count)
        //{
        //    return Task.Run(() =>
        //        ParallelEnumerable.Range(start, count).Count(n =>
        //            Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)));
        //}


        //static void DisplayPrimeCounts()
        //{
        //    for (int i = 0; i < 10; i++)
        //    {
        //        Console.WriteLine(GetPrimesCount(i * 1000000 + 2, 1000000) +
        //            " primes between " + (i * 1000000) + " and " + ((i + 1) * 1000000 - 1));
        //    }
        //    Console.WriteLine("Done");
        //}

        //static void DisplayPrimeCountsAsync()
        //{
        //    for (int i = 0; i < 10; i++)
        //    {
        //        var awaiter = GetPrimesCountAsync(i * 1000000 + 2, 1000000).GetAwaiter();
        //        awaiter.OnCompleted(() =>
        //        Console.WriteLine(awaiter.GetResult() + " primes between " + (i * 1000000) + " and " + ((i + 1) * 1000000 - 1))
        //        );

        //    }
        //    Console.WriteLine("Done");
        //}

        #endregion

        #region AsyncReqursive


        //static void Main()
        //{
        //    Task.Run(DisplayPrimeCountsAsync);

        //    Console.ReadLine();
        //}

        //static async Task DisplayPrimeCountsAsync()
        //{
        //    for (int i = 0; i < 10; i++)
        //    {
        //        Console.WriteLine(await GetPrimesCountAsync(i * 1000000 + 2, 1000000) + " primes between " + (i + 1000000) + " and " + ((i + 1) * 1000000 - 1));
        //    }
        //    Console.WriteLine("Done");
        //}

        //private static Task<int> GetPrimesCountAsync(int start, int count)
        //{
        //    return Task.Run(() =>
        //    ParallelEnumerable.Range(start, count).Count(n =>
        //    Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)));
        //}

        #endregion

        #region AsyncReal


        static void Main()
        {

            DisplayPrimesCount();


            Console.ReadLine();
        }

        static void DisplatPrimesCount()
        {
            var awaiter = GetPrimesCountAsync(2, 1000000).GetAwaiter();
            awaiter.OnCompleted(() =>
            {
                int result = awaiter.GetResult();
                Console.WriteLine(result);
            });
        }

        static async void DisplayPrimesCount()
        {
            int result = await GetPrimesCountAsync(2, 1000000);
            Console.WriteLine(result);
        }

        static Task<int> GetPrimesCountAsync(int start, int count)
        {
            return Task.Run(() =>
                ParallelEnumerable.Range(start, count).Count(n =>
                    Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)));
        }

        #endregion

    }


}

