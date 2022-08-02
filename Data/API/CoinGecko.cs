using Newtonsoft.Json;
using CoinGecko.Clients;

namespace CryptoE.Data.API
{
    
    public static class CoinGecko
    {
        public async static void Test()
        {
            HttpClient httpClient = new HttpClient();
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings();


            PingClient pingClient = new PingClient(httpClient, serializerSettings);
            SimpleClient simpleClient = new SimpleClient(httpClient, serializerSettings);

            // Check CoinGecko API status
            if ((await pingClient.GetPingAsync()).GeckoSays != string.Empty)
            {
                // Getting current price of tether in usd
                string ids = "tether";
                string vsCurrencies = "usd";
                Console.WriteLine((await simpleClient.GetSimplePrice(new[] { ids }, new[] { vsCurrencies }))["tether"]["usd"]);
            }
        }
        

        
    }
}
