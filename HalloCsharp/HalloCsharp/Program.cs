using System;
using System.Collections.Generic;

using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        File.ReadAllBytes("");

        HttpClient client = new HttpClient();

        var client2 = new HttpClient();

        HttpClient client3 = new();


        //var client4 = new ();


        string text = string.Empty;


        string? nullText = null;


        HalloYield();
        Console.WriteLine("Ende");
        Console.ReadKey();
        return;
        var anoTyp = new { Text = "Hallo", zahl = 6_000_000 };


        //Parallel.For(0, 1000000, i => Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: {i}"));
        //Parallel.Invoke(Zähle, Zähle, Zähle, Zähle);


        Task t1 = new Task(() =>
        {
            Console.WriteLine("T1 start");
            Thread.Sleep(1000);
            //throw new OutOfMemoryException();
            Console.WriteLine("T1 Ende");
        });

        t1.ContinueWith(t => { Console.WriteLine("T1 continue (always)"); });
        t1.ContinueWith(t => { Console.WriteLine("T1 continue (good)"); }, TaskContinuationOptions.OnlyOnRanToCompletion);
        t1.ContinueWith(t => { Console.WriteLine($"T1 continue (ERROR):{t.Exception.InnerException.Message}"); }, TaskContinuationOptions.OnlyOnFaulted);

        t1.Start();



        Console.WriteLine("Ende");
        Console.ReadKey();
    }

    private static async void HalloYield()
    {
        await foreach (var item in GetTextsAAA())
        {
            Console.WriteLine(item);
        }
    }


    static async IAsyncEnumerable<string> GetTextsAAA()
    {
        yield return "Hallo";
        await Task.Delay(1000);
        yield return "Welt";
        await Task.Delay(1000);
        yield return "was";
        await Task.Delay(1000);
        yield return "ist";
        await Task.Delay(1000);
        yield return "los?";
    }

    static List<string> GetTexts()
    {
        var list = new List<string>();
        list.Add("Hallo");
        list.Add("Welt");
        list.Add("was");
        list.Add("ist");
        list.Add("los?");
        return list;
    }




    static void Zähle()
    {
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: {i}");
        }
    }
}