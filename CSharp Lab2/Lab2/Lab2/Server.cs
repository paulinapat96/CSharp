using System;
using System.IO;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Sockets;

namespace Lab2
{
    public class Server
    {
        private TcpListener _server;

        private const int _DEFAULT_PORT = 8000;
        private int _port;
        private string _fileDirectory;

        private int Port
        {
            get
            {
                return _DEFAULT_PORT + _port;
            }
        }

        public Server(int port, string fileDirectory)
        {
            _port = port;
            _fileDirectory = fileDirectory;

            Console.WriteLine($"Will read files from: {fileDirectory}");
        }

        public void StartServer()
        {
            _server = null;

            try
            {
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");
                _server = new TcpListener(localAddr, Port);
                _server.Start();

                StartServerListener(_server);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                _server.Stop();
            }
        }


        public void StopServer()
        {
            _server.Stop();
            Console.WriteLine("Server close.");
        }

        private void StartServerListener(TcpListener server)
        {
            Byte[] bytes = new Byte[2048];
            String dataRequest = null;

            try
            {
                //Listening loop
                while (true)
                {

                    Console.Write("Waiting for a connection... ");
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Connected!");

                    dataRequest = null;


                    int i;
                    NetworkStream stream = client.GetStream();
                    StreamWriter writer = new System.IO.StreamWriter(client.GetStream());

                    try
                    {
                        // Loop to receive all the data sent by the client.
                        while (stream.CanRead && (i = stream.Read(bytes, 0, bytes.Length)) != 0)
                        {
                            string content = GenerateContent(AppDomain.CurrentDomain.BaseDirectory + "/index.html");
                            string header = GenerateHeader(content.Length);

                            dataRequest = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                            Console.WriteLine("Received: {0}", dataRequest);

                            string[] requestParams = dataRequest.Split(' ');

                            if (requestParams[0].Equals("GET") && requestParams[1].Contains("html"))
                            {
                                content = GenerateContent(_fileDirectory + requestParams[1].Substring(1).Split(' ')[0]);
                                header = GenerateHeader(content.Length);
                            }

                            writer.Write(header);
                            writer.Write(content);

                            writer.Flush();
                            writer.Close();

                            Console.WriteLine($"Sent: {header} \n {content}");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);

                        string content = "Error 500";
                        string header = GenerateHeader(content.Length);
                        writer.Write(header);
                        writer.Write(content);

                        writer.Flush();
                        writer.Close();

                    }

                    stream.Flush();
                    client.Close();

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private string GenerateHeader(int lengthOfContent)
        {
            return
                "HTTP/1.0 200 OK" + Environment.NewLine +
                "Expires: -1" + Environment.NewLine +
                "Date: " + DateTime.Now + Environment.NewLine +
                "Access -Control -Allow -Origin: *" + Environment.NewLine +
                "Server: meinheld/0.6.1" + Environment.NewLine +
                "x-xss-protection: 1; mode=block" + Environment.NewLine +
                "Content-Type: text/html; charset=UTF-8" + Environment.NewLine +
                "Content-Length: " + lengthOfContent + Environment.NewLine + Environment.NewLine;
        }

        private string GenerateContent(string path)
        {
            
            if (File.Exists(path)) return File.ReadAllText(path);
            return File.ReadAllText("404");
        }

    }
}