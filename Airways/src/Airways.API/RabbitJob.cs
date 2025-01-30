using Dapper;
using Npgsql;
using Quartz;

namespace Airways.API
{
    public class RabbitJob : IJob
    {
        private readonly RabbitMqConsumer _consumer;
        private readonly string _connectionString;
        private readonly ILogger<RabbitJob> _logger;

        public RabbitJob(IConfiguration configuration, RabbitMqConsumer consumer, ILogger<RabbitJob> logger)
        {
          
            _consumer = consumer;

            _connectionString = configuration.GetValue<string>("Database:ConnectionString");

            _logger = logger;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation("Starting RabbitMQ message processing...");

            try
            {
                var messages = _consumer.ReadMessagesFromQueue();

                if (messages.Count == 0)
                {
                    _logger.LogInformation("No messages to process.");
                    return;
                }

                _logger.LogInformation($"Processing {messages.Count} messages...");

                foreach (var message in messages)
                {
                    await SaveToDatabase(message);
                }

                _logger.LogInformation("All messages processed successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing RabbitMQ messages.");
            }
        }
        private async Task SaveToDatabase(string message)
        {
            await using var connection = new NpgsqlConnection(_connectionString);

            var query = "INSERT INTO apilog (Message) VALUES (@Message)";

            var parameters = new
            {
                Message = message,
                CreatedAt = DateTime.UtcNow
            };

            await connection.ExecuteAsync(query, parameters);

            _logger.LogInformation($"Saved to database: {message}");
        }
    }
}

