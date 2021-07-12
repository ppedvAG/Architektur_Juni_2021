using System;
using System.Threading.Tasks;

namespace HalloSingelton
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            for (int i = 0; i < 10; i++)
            {
                Task.Run(() => Logger.Instance.Log("App startet"));
            }

            Logger.Instance.Log("App Ende");

            Console.WriteLine("Ende");
            Console.ReadKey();
        }
    }
}
