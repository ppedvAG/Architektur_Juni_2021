using System;

namespace HalloSingelton
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Logger.Instance.Log("App startet");

            Logger.Instance.Log("App Ende");

            Console.WriteLine("Ende");
            Console.ReadKey();
        }
    }
}
