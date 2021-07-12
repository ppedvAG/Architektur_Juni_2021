using System;

namespace HalloSingelton
{
    class Logger
    {
        static Logger _instance = null;
        static object _lock = new object();
        public static Logger Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new Logger();

                    return _instance;
                }
            }
        }

        static int instanceCounter = 0;
        private Logger()
        {
            Console.WriteLine("New instance of Logger");
            instanceCounter++;
        }

        public void Log(string msg)
        {
            Console.WriteLine($"({instanceCounter}) [{DateTime.Now}] {msg}");
        }
    }
}
