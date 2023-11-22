using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBotAgenta.Data;
using TelegramBotAgenta.Models;

namespace TelegramBotAgenta
{
    public class ServicesHandler : IUpdateHandler
    {

        

        public Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            bool user1 = await StaticServicesBot.SearchUserAsync(update.Message.From.Username);
            if (! user1 )
            {
                var user = new Users()
                {
                    UserName = update.Message.From.Username,
                    ChatId = update.Message.MessageId,

                };
                var u = await StaticServicesBot.AddUserAsync(user);

            }
            if (update.Message.Text == "/start")
            {


                Message sentMessage = await botClient.SendTextMessageAsync(
                    chatId: update.Message.Chat.Id,
                    text: " Qo`llanma (\n/newtodo dan so`ng eslatma yozsangiz szga yangi todo qoshiladi ,\n /todos ni yuborsangiz barcha todolaringizni korishingiz mumkin)",

                    cancellationToken: cancellationToken);

            }
            else if (update.Message.Text.StartsWith("/newtodo") && update.Message.Text.Replace("/newtodo", " ").Trim().Count()>0)
            {

                var todo = new Todos()
                {
                    UsersId = await StaticServicesBot.GetUserByIdAsync(update.Message.From.Username),
                    Description = update.Message.Text.Replace("/newtodo", " "),



                };

                bool res = await StaticServicesBot.AddTodoAsync(todo);
                if (res)
                {

                    Message sentMessage = await botClient.SendTextMessageAsync(
                        chatId: update.Message.Chat.Id,
                        text: " Yangi todo qoshildi",

                        cancellationToken: cancellationToken);

                }
                else
                {

                    Message sentMessage = await botClient.SendTextMessageAsync(
                        chatId: update.Message.Chat.Id,
                        text: " Todo qoshilmadi .",

                        cancellationToken: cancellationToken);
                }
            }
            else if (update.Message.Text.StartsWith("/todos"))
            {

                var userid = await StaticServicesBot.GetUserByIdAsync(update.Message.From.Username);

                var res = await StaticServicesBot.getAlltodos(userid);
                if (res != null)
                {
                    
                    Message sentMessage = await botClient.SendTextMessageAsync(
                        chatId: update.Message.Chat.Id,
                        text: String.Join(",\n",res.Select(x=>x.Description)),

                        cancellationToken: cancellationToken);

                }
                else
                {

                    Message sentMessage = await botClient.SendTextMessageAsync(
                        chatId: update.Message.Chat.Id,
                        text: " Todolar topilmadi .",

                        cancellationToken: cancellationToken);
                }
            }


            else
            {
                
               

                Message message1 = await botClient.SendStickerAsync(
                chatId: update.Message.Chat.Id,
                sticker: InputFile.FromUri("https://github.com/TelegramBots/book/raw/master/src/docs/sticker-fred.webp"),
                cancellationToken: cancellationToken);


            }


        }
    }
}
