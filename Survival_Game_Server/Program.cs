using System;
using System.Threading;

namespace Survival_Game_Server
{
    internal class Program
    {
        private static Thread threadConsole;

        private static void Main(string[] args)
        {
            threadConsole = new Thread(new ThreadStart(ConsoleThread));
            threadConsole.Start();
            NetworkConfig.InitNetwork();
            NetworkConfig.socket.StartListening(5555, 4, 0);
            Console.WriteLine("Network Intialised.");
        }

        private static void ConsoleThread()
        {
            Console.ReadLine();
        }
    }
}