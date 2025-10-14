using Azure.Messaging.ServiceBus;

namespace Worker.Service
{
    public class ServiceBusSenderService
    {
        private readonly string _connectionString;
        private readonly string _queueName;

        public ServiceBusSenderService(string connectionString, string queueName)
        {
            _connectionString = connectionString;
            _queueName = queueName;
        }

        public async Task SendMessageAsync(string messageBody)
        {
            await using var client = new ServiceBusClient(_connectionString);
            ServiceBusSender sender = client.CreateSender(_queueName);

            ServiceBusMessage message = new ServiceBusMessage(messageBody);

            await sender.SendMessageAsync(message);
        }
    }
}
