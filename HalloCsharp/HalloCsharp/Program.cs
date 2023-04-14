using System;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        var anoTyp = new { Text = "Hallo", zahl = 6_000_000 };


        //Parallel.For(0, 1000000, i => Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: {i}"));
        //Parallel.Invoke(Zähle, Zähle, Zähle, Zähle);


        Task t1 = new Task(() =>
        {
            Console.WriteLine("T1 start");
            Thread.Sleep(1000);
            throw new OutOfMemoryException();
            Console.WriteLine("T1 Ende");
        });

        t1.ContinueWith(t => { Console.WriteLine("T1 continue (always)"); });
        t1.ContinueWith(t => { Console.WriteLine("T1 continue (good)"); }, TaskContinuationOptions.OnlyOnRanToCompletion);
        t1.ContinueWith(t => { Console.WriteLine($"T1 continue (ERROR):{t.Exception.InnerException.Message}"); }, TaskContinuationOptions.OnlyOnFaulted);

        t1.Start();



        Console.WriteLine("Ende");
        Console.ReadKey();
    }

    static void Zähle()
    {
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: {i}");
        }
    }
}