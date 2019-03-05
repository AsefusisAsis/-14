using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace КонсольАпп14
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient tcpclient = new TcpClient();
            tcpclient.Connect("127.0.0.1", 8888);

            NetworkStream netStream = tcpclient.GetStream();
            byte[] data2 = new byte[256];
            int bytes = netStream.Read(data2, 0, data2.Length);
            int message = Convert.ToInt32(Encoding.UTF8.GetString(data2, 0, bytes));

            double z1 = Math.Sin((Math.PI / 2) + (3 * message)) / (1 - Math.Sin(3 * message - Math.PI));
            double z2 = Math.Sin((5 / 4) * Math.PI + (3 / 2) * message) / Math.Cos((5 / 4) * Math.PI + (3 / 2) * message);
            string finmessage = ("z1="+z1+"\n"+"z2="+z2);

            byte[] data = System.Text.Encoding.UTF8.GetBytes(Convert.ToString(finmessage));
            netStream.Write(data, 0, data.Length);


            



            tcpclient.Close();
            Console.ReadKey();
        }
    }
}
