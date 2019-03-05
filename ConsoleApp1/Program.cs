using System;
using System.Net;
using System.Net.Sockets;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            TcpClient tcpclient = new TcpClient();
            tcpclient.Connect("127.0.0.1", 8888);
            try
            {
                Console.WriteLine("Введите число:");
                int message = Convert.ToInt32(Console.ReadLine());
                NetworkStream netStream = tcpclient.GetStream();
                byte[] data = System.Text.Encoding.UTF8.GetBytes(Convert.ToString(message));
                netStream.Write(data, 0, data.Length);


                byte[] data2 = new byte[256];
                int bytes = netStream.Read(data2, 0, data2.Length);
                string message2 = System.Text.Encoding.UTF8.GetString(data2, 0, bytes);
                Console.WriteLine(message2);

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            tcpclient.Close();
            Console.Read();
        }
    }
}
