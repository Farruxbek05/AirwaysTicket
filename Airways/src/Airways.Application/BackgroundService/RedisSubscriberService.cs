using Airways.Application.DTO;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace Airways.Application.BackgroundServices
{
    public class ScheduledBackgroundService : BackgroundService
    {
        private readonly ILogger<ScheduledBackgroundService> _logger;
        private readonly IServiceProvider _serviceProvider;
        private Timer? _timer;

        public ScheduledBackgroundService(ILogger<ScheduledBackgroundService> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Scheduled Background Service is starting.");

            var now = DateTime.Now;

            var nextRun = now.AddMinutes(1);

            var initialDelay = nextRun - now;

            // Timerni boshlash: initialDelay - boshlang'ich kechikish va har 1 minutda qayta ishga tushadi
            _timer = new Timer(async _ =>
            {
                await DoWork();
            }, null, initialDelay, TimeSpan.FromMinutes(1));

            return Task.CompletedTask;
        }


        private async Task DoWork()
        {
            try
            {
                _logger.LogInformation($"Task executed at: {DateTime.Now}");

                await ProcessTask();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while executing the scheduled task.");
            }
        }

        private async Task ProcessTask()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var _redis = scope.ServiceProvider.GetRequiredService<IConnectionMultiplexer>();
                var db = _redis.GetDatabase();

                // Barcha kalitlarni olish (bu katta ma'lumotlar uchun samarali emas, chunki barcha kalitlarni qidirish qimmatga tushishi mumkin)
                var keys = _redis.GetServer("127.0.0.1", 6379).Keys();  // Redis server manzilingizni moslashtiring (localhost va 6379)

                foreach (var key in keys)
                {
                    // Har bir kalitning qiymatini olish
                    var value = await db.StringGetAsync(key);

                    var JsonData = JsonConvert.DeserializeObject<RedisValues>(value);



                    if (JsonData != null)
                    {
                        _logger.LogInformation($"Key: {key} has value: {value}");

                        if (JsonData.OrderTime.AddMinutes(15) <= DateTime.UtcNow)
                        {
                            await db.KeyDeleteAsync(key);
                        }
                    }
                    else
                    {
                        _logger.LogWarning($"Key: {key} not found.");
                    }
                }
            }

            _logger.LogInformation("Processing task...");
        }

    }
}

