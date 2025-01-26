using RabbitMQ.Client;
using System.Text;
using System.Threading.Channels;

namespace WebApplication3.Services
{
    public class MessageService : IMessageService
    {
        //ConnectionFactory _factory;
        //IConnection _conn;
        //IModel _channel;
        //public MessageService()
        //{
        //    Console.WriteLine("about to connect to rabbit");

        //    _factory = new ConnectionFactory() { HostName = "localhost", Port=5672};
        //    _factory.UserName = "guest";
        //    _factory.Password = "guest";
        //    _conn = _factory.CreateConnection();
        //    _channel = _conn.CreateModel();
        //    _channel.QueueDeclare("hello", true, false, false, null);
        //    _channel.BasicQos(0, 1, false);
        //}

        public bool Enqueue(string messageString)
        {
            //var body = Encoding.UTF8.GetBytes(messageString);
            //var properties = _channel.CreateBasicProperties();
            //properties.Persistent = true;
            //_channel.BasicPublish("", "hello", null, body);
            //Console.WriteLine(" [x] Published {0} to RabbitMQ", messageString);
            return true;
        }
    }
}
