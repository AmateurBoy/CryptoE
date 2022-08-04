using CryptoE.Controllers;
using CryptoE.Data.DTO;
using CryptoE.Data.Entitys;
using System.Collections.Generic;
using System.Text.Json;
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

        static string Login = "admin";
        static string Pass = "Mazasraka666";
        static string temp3 = "";
        static string temp2 = "";
        static string temp1 = "";
        static string temp0 = "";

        static string login = "";
        static string pass = "";
        static SerelazBotDTO SBDTO = new();
        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            


            

            
            AdminUser au = JsonManager.ReadAdminlist().Result;
            
            
            
            // Некоторые действия
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(update));
            if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
            {
                var message = update.Message;

                if (message.Text.ToLower() == "/start")
                {
                    await botClient.SendTextMessageAsync(message.Chat, "Удаленное управление активировано.Авторизируйтесь.\nУзнать список команд: /detail");
                    return;
                }
                else if(message.Text.ToLower() == "/detail")
                {
                    await botClient.SendTextMessageAsync(message.Chat,
                        "/admin - подключение к управлению.\n" +
                        "/detail - узнать все команды c подробностями.\n" +
                        "/exit - выход с акаунта управления,предоставит возможность авторизироваться кому-то другому(Только админ)\n" +
                        "/coinsetting - настройка коина [Максимальное значение крипти,Минимальное значение,Корректировка курса](Только админ)\n" +
                        "/updatawallet - обновить крипто кошелеки [Выбрать крипто валюту и ввести кошелек](Только админ)\n" +
                        "/allowance - Комисионные могут быть процентной надбавкой(Только админ)\n" + 
                        "/allcoins - вывод названий всех коинов и короткой информации.\n" +
                        "/allwallet - вывод всех кошельков не рекомендовано на телефоне.");
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
                    if(au.Id==0)
                    {
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
                    else
                    {
                        await botClient.SendTextMessageAsync(message.Chat, "В Доступе отказано.Администратор уже существует.");
                    }
                    
                }
                else if(au.Id==message.From.Id&&au.Name==message.From.Username)
                {

                    #region Updatecoin
                    if (temp0 == "Activ")
                    {
                        if(message.Text == "Yes")
                        {
                            TelegramController.UPDATECOIN(SBDTO.NameCoin, SBDTO.Min, SBDTO.Max, SBDTO.Corect);
                            await botClient.SendTextMessageAsync(message.Chat, $"Сохранено.");
                            temp0 = "";
                        }
                        else
                        {
                            SBDTO = new SerelazBotDTO();
                            temp0 = "";
                            temp1 = "";
                            await botClient.SendTextMessageAsync(message.Chat, $"Сохранение не удалось.");
                        }
                    }
                    else if(temp1 == "UpdateCoin4")
                    {
                        SBDTO.Corect = Convert.ToDecimal(message.Text);
                        await botClient.SendTextMessageAsync(message.Chat, $"Сохранить изменения для {SBDTO.NameCoin}?\nМинимальное значение:{SBDTO.Min}\nМаксимальное:{SBDTO.Max}\nКорректировка курса:{SBDTO.Corect}\nВведите: Yes или No");
                        temp1 = "";
                        temp0 = "Activ";
                        
                    }
                    else if(temp0 == "UpdateCoin3")
                    {
                        try
                        {
                            SBDTO.Max = Convert.ToDecimal(message.Text);
                            await botClient.SendTextMessageAsync(message.Chat, $"Введите коректировку курса для {SBDTO.NameCoin}:");
                            temp1 = "UpdateCoin4";
                            temp0 = "";
                        }
                        catch
                        {
                            await botClient.SendTextMessageAsync(message.Chat, $"Что то пошло не так попробуйте вместо '.' => ','\nОшибка с конвертацией данных ( замените . на , ) ");
                            temp0 = "";
                            temp1 = "";
                        }
                        
                    }
                    else if(temp1 == "UpdateCoin2")
                    {
                        try
                        {
                            SBDTO.Min = Convert.ToDecimal(message.Text);
                            await botClient.SendTextMessageAsync(message.Chat, $"Введите максимальное значение для {SBDTO.NameCoin}:");
                            temp0 = "UpdateCoin3";
                            temp1 = "";
                        }
                        catch
                        {
                            await botClient.SendTextMessageAsync(message.Chat, $"Что то пошло не так попробуйте вместо '.' => ','\n Ошибка с конвертацией данных ( замените . на , )");
                            temp0 = "";
                            temp1 = "";
                        }
                        
                    }
                    else if(temp0 == "UpdateCoin1")
                    {
                        SBDTO.NameCoin = message.Text;
                        await botClient.SendTextMessageAsync(message.Chat, $"Введите минимальное значение для {SBDTO.NameCoin}:");
                        temp1 = "UpdateCoin2";
                        temp0 = "";


                    }                    
                    else if (message.Text.ToLower() == "/coinsetting")
                    {
                        await botClient.SendTextMessageAsync(message.Chat, "Вы вошли в настройку коинов.\n" +
                            "Необходимо ввести каждую последовательность:\n" +
                            "Введите имя коина которий будете настраивать:");
                        temp0 = "UpdateCoin1";
                            
                        
                    }
                    #endregion
                    #region walletupdata
                    else if (temp0 == "walletupdate1")
                    {
                        temp3 = message.Text;
                        await botClient.SendTextMessageAsync(message.Chat, $"{TelegramController.UpdateWallet(temp2,temp3).Result}");
                        temp3 = "";
                        temp2 = "";
                        temp0 = "";
                    }
                    else if(temp0 == "walletupdate0")
                    {
                        temp2 = message.Text;
                        await botClient.SendTextMessageAsync(message.Chat, $"Введите новий кошелек для {temp2}");
                        temp0 = "walletupdate1";
                    }
                    else if(message.Text.ToLower() =="/updatawallet")
                    {
                        await botClient.SendTextMessageAsync(message.Chat, "Настрока кошелька.\nМожно посмотреть все доступные кошельки командой /allwallet\nВвведите имя коина к которому относиться кошелек:Format{btc(неправельно)=BTC(правельно)}");
                        temp0 = "walletupdate0";
                    }
                    #endregion
                    #region Allowance
                    else if (temp0 == "Allowance0")
                    {
                        try
                        {
                            TelegramController.UpdateProcent(Convert.ToDecimal(message.Text));
                            temp0 = "";
                        }
                        catch
                        {
                            await botClient.SendTextMessageAsync(message.Chat, "Некоректный ввод.");
                            temp0 = "";
                        }
                        
                    }
                    else if(message.Text.ToLower() == "/allowance")
                    {
                        await botClient.SendTextMessageAsync(message.Chat, "Ввведите комисионные:\n(Дефолтно стоит 1 = без комисии)\n(Пример: 0,99 = 1%)");
                        temp0 = "Allowance0";
                    }
                    #endregion
                    #region allcoins
                    else if(message.Text.ToLower()=="/allcoins")
                    {
                        await botClient.SendTextMessageAsync(message.Chat, "Витяжка коинов с базы...");
                        await botClient.SendTextMessageAsync(message.Chat, Singleton.GetAllCoin());
                    }
                    #endregion
                    #region AllWallet
                    else if (message.Text.ToLower() == "/allwallet")
                    {
                        await botClient.SendTextMessageAsync(message.Chat, Singleton.GetAllWallet());
                    }
                    #endregion
                    else if (message.Text.ToLower() == "/exit")
                    {
                        JsonManager.DelAcaunt();
                        await botClient.SendTextMessageAsync(message.Chat, "Вы больше не администратор.Права ограничены, теперь можно назначить нового администратора.");
                    }
                    else
                    {
                        await botClient.SendTextMessageAsync(message.Chat, "Вы админ,но команды не кто не отменял. /detail");
                    }
                    
                }
                else
                {
                    await botClient.SendTextMessageAsync(message.Chat, "Not find commands /detail");
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
        public static async void MessageTelegram(string messag)
        {
            try
            {


                AdminUser adminUser = JsonManager.ReadAdminlist().Result;
                await bot.SendTextMessageAsync(adminUser.Id, messag);
            }
            catch
            { }
             

            
        }
    }
}
