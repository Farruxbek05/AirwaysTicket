using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;

namespace Airways.API
{
    public class RabbitMqConsumer
    {
        private readonly string _queueName;

        public RabbitMqConsumer(string queueName)
        {
            _queueName = queueName;
        }

        public List<string> ReadMessagesFromQueue()
        {
            var messages = new List<string>();

            var factory = new ConnectionFactory() { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: _queueName,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            var manualResetEvent = new ManualResetEvent(false);

            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                messages.Add(message);
            };

            channel.BasicConsume(queue: _queueName,
                                 autoAck: true,
                                 consumer: consumer);

            Console.WriteLine("Waiting for messages...");
            manualResetEvent.WaitOne(TimeSpan.FromSeconds(10)); 
            return messages;
        }
    }


}

