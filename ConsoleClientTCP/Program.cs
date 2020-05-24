using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClientTCP
{
    class Program
    {
        static void Main(string[] args)
        {
            const string ip = "127.0.0.1";
            const int port = 8080;

            // конечная точка, куда можно подключаться, у сервера может быть много таких точек подключения
            var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

            // сокет для соединения, открывает соединение и получает данные
            var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            Console.WriteLine("input message");
            var message = Console.ReadLine();

            var data = Encoding.UTF8.GetBytes(message);

            tcpSocket.Connect(tcpEndPoint);
            tcpSocket.Send(data);

            var buffer = new byte[256];  // буфер для приема сообщений
            var size = 0;  /// реальный размер сообщения

            var answer = new StringBuilder();  // собираем сообщение

            do  // собираем все сообщение по кускам размерам не больше буфера
            {
                size = tcpSocket.Receive(buffer);
                answer.Append(Encoding.UTF8.GetString(buffer, 0, size)); // раскодируем сообщение в строку определенной кодировки

            } while (tcpSocket.Available > 0);

            Console.WriteLine(answer.ToString()); // выводим на экран

            tcpSocket.Shutdown(SocketShutdown.Both);
            tcpSocket.Close();

            message = Console.ReadLine();
        }
    }
}
