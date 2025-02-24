using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Threading.Channels;

namespace WebApplication3.Services
{
    public class MessageService : IMessageService
    {
        private readonly ConnectionFactory _factory;

        public MessageService()
        {
            Console.WriteLine("about to connect to rabbit");

            _factory = new ConnectionFactory() { HostName = "rabbitmq", Port = 5672, UserName  =  "guest",  Password    =  "guest" };
            _factory.UserName = "guest";
            _factory.Password = "guest";
        }

        public async Task<bool> SendAsync(string messageString, Guid channelId)
        {
            using var connection = await _factory.CreateConnectionAsync();
            using var channel = await connection.CreateChannelAsync();

            var body = Encoding.UTF8.GetBytes(messageString);
            await channel.QueueDeclareAsync(channelId.ToString(), false, false, false, null);
            await channel.BasicPublishAsync(exchange: "", routingKey: "hello", body: body);
            Console.WriteLine(" [x] Published {0} to RabbitMQ", messageString);
            return true;
        }

        public async Task<IEnumerable<string>> ReceiveFromChannel(Guid channelId)
        {
            using var connection = await _factory.CreateConnectionAsync();
            using var channel = await connection.CreateChannelAsync();

            await channel.QueueDeclareAsync(channelId.ToString(), durable: false, exclusive: false, autoDelete: false,
                arguments: null);

            Console.WriteLine(" [*] Waiting for messages.");

            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.ReceivedAsync += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($" [x] Received {message}");
                return Task.CompletedTask;
            };

            await channel.BasicConsumeAsync(channelId.ToString(), autoAck: true, consumer: consumer);
            return new List<string>();
        }
    }
}
