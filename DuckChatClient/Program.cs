using System;

namespace DuckChatClient
{
    class Program
    {
        static void Main(string[] args)
        {
            tcpClient client = new tcpClient();
            bool quit = false;
            while(!quit)
            {
                Console.WriteLine("send a message here:");
                string message = Console.ReadLine();
                client.Connect("127.0.0.1", message);
            }
        }
    }
}
