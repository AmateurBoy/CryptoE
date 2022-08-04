using Newtonsoft.Json;
using CoinGecko.Clients;
using Quartz;
using System.Threading.Tasks;
using CryptoE.Controllers;
using CryptoE.Data.Entitys;

namespace CryptoE.Data.API
{
    
    public class CoinGecko : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            await Test();
            JsonManager.RecCoins(Singleton.Coins.CoinsCrypta);
            JsonManager.RecCoins(Singleton.Coins.CoinsStaibel);
        }
        public async Task Test()
        {
            HttpClient httpClient = new HttpClient();
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings();


            PingClient pingClient = new PingClient(httpClient, serializerSettings);
            SimpleClient simpleClient = new SimpleClient(httpClient, serializerSettings);

            // Check CoinGecko API status
            if ((await pingClient.GetPingAsync()).GeckoSays != string.Empty)
            {

                // Getting current price of tether in usd
                List<string> Coins = new()
                {
                    "bitcoin",
                    "ethereum",
                    "tezos",
                    "stellar",
                    "dogecoin",
                    "tron",
                    "ripple",
                    "cardano",
                    "litecoin",
                    "tether",
                    "usd",
                    "busd"
                };
                
                string vsCurrencies = "usd";
                foreach (var item in Coins)
                {
                    string resultcoin = "";
                    string BTC = "BTC";
                    string ETH = "ETH";
                    string XTZ = "XTZ";
                    string XLM = "XLM";
                    string DOGE = "DOGE";
                    string TRX = "TRX";
                    string XRP = "XRP";
                    string ADA = "ADA";
                    string LTC = "LTC";
                    string USDT = "USDT";
                    string USDC = "USDC";
                    string BUSD = "BUSD";
                    if (item == "bitcoin")
                    {
                        resultcoin = BTC;
                    }
                    if (item == "ethereum")
                    {
                        resultcoin=ETH; 
                    }
                    if (item == "tezos")
                    {
                        resultcoin=XTZ;
                    }
                    if (item == "stellar")
                    {
                        resultcoin = XLM;
                    }
                    if (item == "dogecoin")
                    {
                        resultcoin = DOGE;

                    }
                    if (item == "tron")
                    {
                        resultcoin = TRX;
                    }
                    if (item == "ripple")
                    {
                        resultcoin = XRP;
                    }
                    if (item == "cardano")
                    {
                        resultcoin = ADA;
                    }
                    if (item == "litecoin")
                    {
                        resultcoin = LTC;
                    }

                    if (item == "tether")
                    {
                        resultcoin = USDT;
                    }
                    if (item == "usd")
                    {
                        resultcoin = USDC;
                    }
                    if (item == "busd")
                    {
                        resultcoin = BUSD;
                    }
                    
                    
                    if(Singleton.WhatCoinList(resultcoin)==Singleton.Coins.CoinsStaibel)
                    {
                        Coin coin = Singleton.FindCoin(resultcoin);
                        
                        string valees =Convert.ToString((await simpleClient.GetSimplePrice(new[] {item}, new[] { vsCurrencies }))[$"{item}"]["usd"]);
                        
                        coin.value = Convert.ToDecimal(valees);
                        Singleton.UpdateStable(coin);
                        

                    }
                    if (Singleton.WhatCoinList(resultcoin) == Singleton.Coins.CoinsCrypta)
                    {
                        Coin coin = Singleton.FindCoin(resultcoin);
                        string valees = Convert.ToString((await simpleClient.GetSimplePrice(new[] { item }, new[] { vsCurrencies }))[$"{item}"]["usd"]);
                        coin.value = Convert.ToDecimal(valees);
                        
                        await Task.Run(() => Singleton.UpdateCripto(coin));
                        
                    }
                    
                    


                }
                
                
            }
        }
        

        
    }
}
