using Dapper;
using Microsoft.Data.SqlClient;
using Quartz;

namespace Airways.API
{
    public class DailyJob : IJob
    {
        private readonly RabbitMqConsumer _consumer;
        private readonly string _connectionString;

        public DailyJob(RabbitMqConsumer consumer, string connectionString)
        {
            _consumer = consumer;
            _connectionString = connectionString;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Starting RabbitMQ message processing...");

            // RabbitMQ xabarlarini o'qish
            var messages = _consumer.ReadMessagesFromQueue();

            if (messages.Count == 0)
            {
                Console.WriteLine("No messages to process.");
                return;
            }

            Console.WriteLine($"Processing {messages.Count} messages...");

            foreach (var message in messages)
            {
                await SaveToDatabase(message);
            }

            Console.WriteLine("All messages processed successfully.");
        }

        private async Task SaveToDatabase(string message)
        {
            using var connection = new SqlConnection(_connectionString);

            var query = "INSERT INTO ApiLogs (Message, CreatedAt) VALUES (@Message, @CreatedAt)";
            var parameters = new
            {
                Message = message,
                CreatedAt = DateTime.UtcNow
            };

            await connection.ExecuteAsync(query, parameters);

            Console.WriteLine($"Saved to database: {message}");
        }
    }


}

