using System;

namespace DuckChatServer
{
    class Program
    {
        static void Main(string[] args)
        {
            tcpListener listener = new tcpListener();

            listener.Listen();
        }
    }
}
