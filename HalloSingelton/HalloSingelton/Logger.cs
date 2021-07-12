using System;

namespace HalloSingelton
{
    class Logger
    {
        static Logger _instance = null;

        public static Logger Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Logger();

                return _instance;
            }
        }

        static int instanceCounter = 0;
        private Logger()
        {
            instanceCounter++;
        }

        public void Log(string msg)
        {
            Console.WriteLine($"({instanceCounter}) [{DateTime.Now}] {msg}");
        }
    }
}
