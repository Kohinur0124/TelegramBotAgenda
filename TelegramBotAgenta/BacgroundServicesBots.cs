
using Telegram.Bot;

namespace TelegramBotAgenta
{
    public class BacgroundServicesBots : BackgroundService
    {
        private TelegramBotClient client;

        public BacgroundServicesBots(TelegramBotClient client)
        {
            this.client = client;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine("Botimiz sh");
            client.StartReceiving<ServicesHandler>(null,stoppingToken);
            return Task.CompletedTask;
        }
    }
}
