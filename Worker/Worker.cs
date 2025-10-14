using Azure.Messaging.ServiceBus;

namespace PermissionWorker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConfiguration _configuration;
        private ServiceBusProcessor? _processor;

        public Worker(ILogger<Worker> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            var connectionString = _configuration["ServiceBus:ConnectionString"];
            var queueName = _configuration["ServiceBus:QueueName"];

            var client = new ServiceBusClient(connectionString);
            _processor = client.CreateProcessor(queueName, new ServiceBusProcessorOptions());

            _processor.ProcessMessageAsync += MessageHandler;

           
            _processor.ProcessErrorAsync += ErrorHandler;

            await _processor.StartProcessingAsync(cancellationToken);

            await base.StartAsync(cancellationToken);
        }

        private async Task MessageHandler(ProcessMessageEventArgs args)
        {
            string body = args.Message.Body.ToString();
            _logger.LogInformation($"Received message: {body}");

            // TODO: Process the message (e.g., add permission logic)

            await args.CompleteMessageAsync(args.Message);
        }

        private Task ErrorHandler(ProcessErrorEventArgs args)
        {
            _logger.LogError(args.Exception, "Message handler encountered an exception");
            return Task.CompletedTask;
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            if (_processor != null)
            {
                await _processor.StopProcessingAsync(cancellationToken);
                await _processor.DisposeAsync();
            }
            await base.StopAsync(cancellationToken);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken) => Task.CompletedTask;
    }
}
