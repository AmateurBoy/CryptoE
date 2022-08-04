using CryptoE.Controllers;
using CryptoE.Data.Entitys;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace CryptoE.TelegramBot
{
    public class BotController
    {
        static ITelegramBotClient bot = new TelegramBotClient("5323370014:AAE74NvKoLfXn0Ye2PxJ7j5zdm19kZ5Wl5E");
        static string temp1 = "";
        static string temp0 = "";
        static string Login = "admin";
        static string Pass = "Mazasraka666";
        static string login = "";
        static string pass = "";
        
        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            AdminUser au =JsonManager.ReadAdminlist().Result;
            // Некоторые действия
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(update));
            if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
            {
                var message = update.Message;

                if (message.Text.ToLower() == "/start")
                {
                    await botClient.SendTextMessageAsync(message.Chat, "Удаленное управление активировано.\nВведите что бы узнать список команд: /help");
                    return;
                }
                else if(message.Text.ToLower() == "/help")
                {
                    await botClient.SendTextMessageAsync(message.Chat,
                        "/admin - подключение к управлению.\n" +
                        "/help - узнать все команды\n" +
                        "/exit - выход с акаунта управления,предоставит возможность авторизироваться комуто другому(Только админ)\n" +
                        "/coinsetting - настройка коина(Только админ)\n" +
                        "/updatawallet - обновить криптокошелек(Только админ)\n" +
                        "/allowance - надбавка к курсу крипты ЗНАЧЕНИЕ ФИКСИРОВАНОЕ(Только админ)\n" +
                        "/allowance% - надбавка к курсу крипты ПРОЦЕНТ(Только админ)");
                        
                    

                }
                
                else if (message.Text.ToLower() == "/admin")
                {
                    temp0 = "Login:";
                    await botClient.SendTextMessageAsync(message.Chat, "Login:");
                    return;
                }

                else if(temp0=="Login:")
                {
                    temp0 = "";
                    temp1 = "Pass:";
                    login = message.Text;
                    //удалять сообщение. пороля сразу
                    await botClient.SendTextMessageAsync(message.Chat,"Pass:");
                }
                else if(temp1=="Pass:"&&message.Text.ToLower()!=login)
                {
                    temp0 = "";
                    temp1 = "";
                    pass = message.Text;
                    if (Login == login && Pass == pass)
                    {
                        //переделать авторизацию.
                        TelegramController.Autorization(message.From.Id, message.From.Username);
                        await botClient.SendTextMessageAsync(message.Chat, "Доступ к командам предоставлен.");
                        login = "";
                        pass = "";
                    }
                    else
                    {
                        await botClient.SendTextMessageAsync(message.Chat, "В Доступе отказано.");
                        login = "";
                        pass = "";
                    }
                }
                else if(au.Id==message.From.Id&&au.Name==message.From.Username)
                {
                    if(message.Text.ToLower() == "/test")
                    {
                        await botClient.SendTextMessageAsync(message.Chat, "Удачный тест.");
                    }
                    else if(message.Text.ToLower() == "/exit")
                    {

                    }
                    
                }
                else
                {
                    await botClient.SendTextMessageAsync(message.Chat, "Not find commands /help");
                }
                
            }
        }

        public static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            // Некоторые действия
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
        }


        public static async void Main()
        {
            Console.WriteLine("Запущен бот " + bot.GetMeAsync().Result.FirstName);

            var cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { }, // receive all update types
            };
            bot.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                receiverOptions,
                cancellationToken
            );
            
        }
    }
}
