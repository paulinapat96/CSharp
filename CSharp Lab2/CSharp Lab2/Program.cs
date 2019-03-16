using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace CSharp_Lab2
{
    class Program
    {
        static void Main(string[] args)
        {

            TcpListener server = null;
            //  HttpListenerResponse response = new HttpListenerResponse();
            //                response.AddHeader("Expires", "-1");

            string header = "HTTP /1.1 200 OK\n" +
                            "Expires: -1\n" +
                            "Date: Wed , 18 Oct 2017 09:47:45 GMT\n" +
                            "Access - Control - Allow - Origin : *\n" +
                            "Content - Type : text / html; charset = utf - 8\n" +
                            "Server: meinheld / 0.6.1\n" +
                            "x - xss - protection : 1; mode = block\n" +
                            "Connection: close\n\n";



            try
            {
                Int32 port = 8000;
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");
                server = new TcpListener(localAddr, port);
                server.Start();

                // Buffer for reading data
                Byte[] bytes = new Byte[2048];
                String data = header + File.ReadAllText("index.html");

                // Enter the listening loop.
                while (true)
                {
                    Console.Write("Waiting for a connection... ");
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Connected!");

                    //data = 

                    NetworkStream stream = client.GetStream();

                    int i;

                    // Loop to receive all the data sent by the client.
                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                        Console.WriteLine("Received: {0}", data);

                        // Process the data sent by the client.
                        data = data.ToUpper();
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);
                        stream.Write(msg, 0, msg.Length);
                        Console.WriteLine("Sent: {0}", data);
                    }

                    stream.Flush();
                    client.Close();
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                // Stop listening for new clients.
                server.Stop();
            }

            Console.WriteLine("\nHit enter to continue...");
            Console.Read();
        }
    }
}
