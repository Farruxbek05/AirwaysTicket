/*using Airways.DataAccess.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Quartz;

namespace Airways.Application.Services
{
    public class MonthlyPaymnet : IJob
    {
        private readonly DataBaseContext _dbContext;
        private readonly ILogger<MonthlyPaymnet> _logger;
        private readonly IPayment_HistoryRepository _payment_HistoryRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly ICardsRepository _cardsRepository;

        // Constructor with dependency injection
        public MonthlyPaymnet(
            DataBaseContext dbContext,
            IPayment_HistoryRepository payment_HistoryRepository,
            ILogger<MonthlyPaymnet> logger,
            IAccountRepository accountRepository,
            ICardsRepository cardsRepository)
        {
            _dbContext = dbContext;
            _logger = logger;
            _payment_HistoryRepository = payment_HistoryRepository;
            _accountRepository = accountRepository;
            _cardsRepository = cardsRepository;
        }

        // Main method that Quartz will call
        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                _logger.LogInformation($"Starting monthly payment processing at {DateTime.UtcNow}");

                // Get all active accounts with their tariffs
                var accounts = await _dbContext.Account
                    .Include(a => a.TarifId)  // Include tariff information
                    .Where(a => !a.IsDeleted) // Only process active accounts
                    .ToListAsync();

                foreach (var account in accounts)
                {
                    await ProcessAccountPayment(account);
                }

                await _dbContext.SaveChangesAsync();
                _logger.LogInformation($"Completed monthly payment processing at {DateTime.UtcNow}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during monthly payment job execution");
                throw; // Rethrow to let Quartz know the job failed
            }
        }

        // Helper method to process individual account payments
        private async Task ProcessAccountPayment(Account account)
        {
            try
            {
                var card = await _cardsRepository.GetFirstAsync(u => u.UserId == account.UserId);

                var paymentHistory = new Payment_History()
                {
                    AccountId = account.Id,

                    TarrifType = account.TarifId,
                    Tarrif_TypeId = account.Tarrif_TypeId,
                    CardTypeId = card.CardTypeId, // Set appropriate default or get from configuration
                    IsPaid = true, // Default to false, will set to true if payment succeeds
                    CreatedOn = DateTime.UtcNow,
                    CreatBy = "System"
                };

                // Check if account has sufficient balance
                if (account.Balance >= account.TarifId.Amount)
                {
                    // Process payment
                    account.Balance -= account.TarifId.Amount;
                    paymentHistory.IsPaid = true;
                    await _accountRepository.UpdateAsync(account);

                    _logger.LogInformation(
                        "Successfully processed payment for account {AccountId}. " +
                        "Amount: {Amount}, New Balance: {NewBalance}",
                        account.Id, account.TarifId.Amount, account.Balance);
                    await _payment_HistoryRepository.AddAsync(paymentHistory);
                }
                else
                {
                    _logger.LogWarning(
                        "Insufficient balance for account {AccountId}. " +
                        "Required: {Required}, Available: {Available}",
                        account.Id, account.TarifId.Amount, account.Balance);
                }

                // Record the payment attempt
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Error processing payment for account {AccountId}",
                    account.Id);
            }
        }



        // Extension method to configure Quartz scheduling
        public static class QuartzJobSchedulerExtensions
        {
            public static IServiceCollection AddMonthlyPaymentJob(this IServiceCollection services)
            {
                services.AddQuartz(q =>
                {
                    // Define the job
                    var jobKey = new JobKey("MonthlyPaymentJob");
                    q.AddJob<MonthlyPaymnet>(opts => opts.WithIdentity(jobKey));

                    // Create a trigger
                    q.AddTrigger(opts => opts
                        .ForJob(jobKey)
                        .WithIdentity("MonthlyPaymentTrigger")
                        .WithCronSchedule("0 0 0 1 * ?")); // Runs at midnight on the 1st day of every month
                });

                // Add the Quartz hosted service
                services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

                return services;
            }
        }
    }

}
*/