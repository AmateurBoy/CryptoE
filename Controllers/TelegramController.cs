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

        [HttpGet("/ApiTest123")]
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
        public async Task UPDATECOIN(string namecoin, decimal mincoin, decimal maxstring, decimal values)
        {
            if(Singleton.WhatCoinList(namecoin)==Singleton.Coins.CoinsStaibel)
            {
                Coin coin = Singleton.FindCoin(namecoin);
                coin.minAmount = Convert.ToDecimal(mincoin);
                coin.maxAmount = Convert.ToDecimal(maxstring);
                coin.value = Convert.ToDecimal(values);
                await Task.Run(() => Singleton.UpdateStable(coin));
            }
            if (Singleton.WhatCoinList(namecoin) == Singleton.Coins.CoinsCrypta)
            {
                Coin coin = Singleton.FindCoin(namecoin);
                coin.minAmount = Convert.ToDecimal(mincoin);
                coin.maxAmount = Convert.ToDecimal(maxstring);
                coin.value = Convert.ToDecimal(values);
                await Task.Run(() => Singleton.UpdateCripto(coin));
            }

        }
    }
}
