using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace DuckChatServer
{
    public class tcpListener
    {
        public tcpListener()
        {
        }

        public void Listen() { 
            TcpListener server = null;
            try
            {
                Int32 port = 13000;
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");
                server = new TcpListener(localAddr, port);

                server.Start();

                byte[] bytes = new byte[256];
                String data = null;

                while(true)
                {
                    Console.Write("waiting for connection");

                    using TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("accepted!");

                    data = null;

                    NetworkStream stream = client.GetStream();
                    int i;

                    while(( i=stream.Read(bytes,0,bytes.Length))!= 0)
                    {
                        data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                        Console.WriteLine("ReceivedL {0}", data);

                        data = data.ToUpper();

                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

                        stream.Write(msg, 0, msg.Length);
                        Console.WriteLine("Send: {0}", data);
                    }
                }

            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                server.Stop();
            }

            Console.WriteLine("\nHit enter to continue...");
            Console.Read();

        }
    }
}
