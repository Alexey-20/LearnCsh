using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleServTCP
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

            // связываем сокет с соединением, говорим ему какую точку слушать
            tcpSocket.Bind(tcpEndPoint);

            tcpSocket.Listen(5); // слушаем и ставим в очередь 5 соединений

            while(true)
            {
                var listener = tcpSocket.Accept(); // сокет для подключения конкретного клиента из очереди соединений
                var buffer = new byte[256];  // буфер для приема сообщений
                var size = 0;  /// реальный размер сообщения

                var data = new StringBuilder();  // собираем сообщение

                do  // собираем все сообщение по кускам размерам не больше буфера
                {
                    size = listener.Receive(buffer);
                    data.Append(Encoding.UTF8.GetString(buffer, 0, size)); // раскодируем сообщение в строку определенной кодировки

                } while (listener.Available > 0);

                Console.WriteLine(data); // выводим на экран

                listener.Send(Encoding.UTF8.GetBytes("Success")); // возвращаем ответ на принятые данные

                listener.Shutdown(SocketShutdown.Both);  // отключаем и клиента и сервер сокеты с обоих сторон
                listener.Close();    // закрываем соединение
            }


        }
    }
}
