using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UDPMeasurementSender
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1"); //


            UdpClient udpSender = new UdpClient("192.168.6.138", 8080); //

            NameGenerator generator = new NameGenerator();

            while (true)
            {
                string measurment = generator.randomname();
                Byte[] sendBytes = Encoding.ASCII.GetBytes(measurment);
                try
                {

                    udpSender.Send(sendBytes, sendBytes.Length);//,RemoteIpEndPoint);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }


                Console.WriteLine(measurment);
                Thread.Sleep(300);
            }

        }
    }

}


