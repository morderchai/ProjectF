using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Threading.Channels;

namespace WebApplication3.Services
{
    public class MessageService : IMessageService
    {
        private readonly ConnectionFactory _factory;

        private IConnection? _connection;
        private IChannel _channel;

        public Task Initialization { get; private set; }

        public MessageService()
        {
            Console.WriteLine("about to connect to rabbit");

            _factory = new ConnectionFactory() { HostName = "rabbitmq", Port = 5672, UserName = "guest", Password = "guest" };

            Initialization = InitializeAsync();
        }

        public async Task<bool> SendAsync(string messageString, Guid channelId)
        {
            var body = Encoding.UTF8.GetBytes(messageString);
            await _channel.QueueDeclareAsync(channelId.ToString(), true, false, false, null);
            await _channel.BasicPublishAsync(exchange: "", routingKey: channelId.ToString(), body: body);
            Console.WriteLine(" [x] Published {0} to RabbitMQ", messageString);
            return true;
        }

        public async Task<IEnumerable<string>> ReceiveFromChannel(Guid channelId)
        {
            using var connection = await _factory.CreateConnectionAsync();

            await _channel.QueueDeclareAsync(channelId.ToString(), true, exclusive: false, autoDelete: false,
                arguments: null);

            Console.WriteLine(" [*] Waiting for messages.");

            var consumer = new AsyncEventingBasicConsumer(_channel);
            consumer.ReceivedAsync += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($" [x] Received {message}");
                return Task.CompletedTask;
            };

            await _channel.BasicConsumeAsync(channelId.ToString(), autoAck: true, consumer: consumer);
            return new List<string>();
        }

        private async Task InitializeAsync()
        {
            _connection = await _factory.CreateConnectionAsync();
            _channel = await _connection.CreateChannelAsync();
        }
    }
}
