using CryptoE.Data.Entitys;
using CryptoE.Data.API;
using Microsoft.AspNetCore.Mvc;
using Quartz;
using Quartz.Impl;

namespace CryptoE.Controllers
{
    public class TelegramController : Controller
    {
        //exchangerseender@gmail.com
        //qmortdoipszfxfuj
        //Crypto Exchanger

        
        public static async void APItest()
        {
            IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();
            await scheduler.Start();

            IJobDetail job = JobBuilder.Create<Data.API.CoinGecko>().Build();

            ITrigger trigger = TriggerBuilder.Create()  // создаем триггер
                .WithIdentity("trigger1", "group1")     // идентифицируем триггер с именем и группой
                .StartNow()                            // запуск сразу после начала выполнения
                .WithSimpleSchedule(x => x            // настраиваем выполнение действия
                    .WithIntervalInMinutes(1)          // через 1 минуту
                    .RepeatForever())                   // бесконечное повторение
                .Build();                               // создаем триггер

            await scheduler.ScheduleJob(job, trigger);        // начинаем выполнение работы
        }
        [HttpGet("/TESTUPDATE")]
        public static async Task UPDATECOIN(string namecoin, decimal mincoin, decimal maxcoin, decimal corect)
        {
            if(Singleton.WhatCoinList(namecoin)==Singleton.Coins.CoinsStaibel)
            {
                
                Coin coin = Singleton.FindCoin(namecoin);
                coin.corecting = corect;
                coin.minAmount = Convert.ToDecimal(mincoin);
                coin.maxAmount = Convert.ToDecimal(maxcoin);
                
                await Task.Run(() => Singleton.UpdateStable(coin));

                JsonManager.RecCoins(Singleton.Coins.CoinsStaibel);
            }
            if (Singleton.WhatCoinList(namecoin) == Singleton.Coins.CoinsCrypta)
            {
                Coin coin = Singleton.FindCoin(namecoin);
                coin.corecting = corect;
                coin.minAmount = Convert.ToDecimal(mincoin);
                coin.maxAmount = Convert.ToDecimal(maxcoin);
                
                await Task.Run(() => Singleton.UpdateCripto(coin));
                JsonManager.RecCoins(Singleton.Coins.CoinsCrypta);
            }

        }
        public static async Task<string> UpdateWallet(string nameCOIN, string newWallet)
        {
            try
            {
                string temp = Singleton.Coins.WalletsCrypto[nameCOIN];
                Singleton.Coins.WalletsCrypto[nameCOIN] = newWallet;
                JsonManager.RecWallet(Singleton.Coins.WalletsCrypto);
                return $"Updata {nameCOIN} \nWallet=>({temp}) |\nNew=>{newWallet}\n Done.";
            }
            catch
            {
                return $"Неудача не найдено: {nameCOIN}";
            }
            
        }
        public static async Task<string> UpdateProcent(decimal procent)
        {
            decimal temp = Singleton.Coins.Commission;
            Singleton.Coins.Commission = procent;
            JsonManager.RecCommission(Singleton.Coins.Commission);
            return $"Updata Commission {temp}=>{procent}";
        }
        public static async Task<string>Autorization(long id, string username)
        {
            AdminUser AU = new AdminUser
            {
                Id = id,
                Name = username,
            };
            JsonManager.RecAcaunt(AU);
            return"";
        }
        
        public static async Task<string> CompleteZauvka()
        {
            return "Должен быть код";
        }
    }
}
