using System.Net.Sockets;
using System.Text;

namespace Client
{
    class OurClient
    {
        private TcpClient client; // переменная для работы с клиентом
        private StreamWriter sWriter; // поток отправки с Клиента на Сервер
        private StreamReader sReader;

        public OurClient() // portnum(5555) куда именно отправлять с сервера, порт(место встречи) должен быть одинаков для клиента и для сервера 
        {
            client = new TcpClient("127.0.0.1", 5555); // 127.0.0.1 ip для своего компьютера, сервер отправляет на наш компьютер
            sWriter = new StreamWriter(client.GetStream(), Encoding.UTF8);
            sReader = new StreamReader(client.GetStream(), Encoding.UTF8);

            HandleCommunication();
        }

        void HandleCommunication()
        {
            while (true) // бесконечный цикл, будет все время держать соединение с сервером
            {
                Console.Write("> ");
                string message = Console.ReadLine();
                sWriter.WriteLine(message); // клиент отправляет на сервер сообщение
                sWriter.Flush();

                string answerServer = sReader.ReadLine();
                Console.WriteLine($"Сервер ответил - {answerServer}");
            }
        }
    }
}