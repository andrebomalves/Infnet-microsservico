
namespace Infnet.Ecommerce.Pagamento.API.Jobs
{
    public class TesteBackground : BackgroundService
    {
        private readonly ILogger<TesteBackground> logger;
        private int executionCount;

        public TesteBackground(ILogger<TesteBackground> logger)
        {
            this.logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            logger.LogInformation("Timed Hosted Service running.");

            // When the timer should have no due-time, then do the work once now.
            DoWork();

            using PeriodicTimer timer = new(TimeSpan.FromSeconds(5));

            try
            {
                while (await timer.WaitForNextTickAsync(stoppingToken))
                {
                    DoWork();
                }
            }
            catch (OperationCanceledException)
            {
                logger.LogInformation("Timed Hosted Service is stopping.");
            }
        }

        private void DoWork()
        {
            int count = Interlocked.Increment(ref executionCount);

            logger.LogInformation("Timed Hosted Service is working. Count: {Count}", count);
        }
    }
}
