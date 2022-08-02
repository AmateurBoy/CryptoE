using CryptoE.Data.Entitys;
using CryptoE.Data.API;
using Microsoft.AspNetCore.Mvc;

namespace CryptoE.Controllers
{
    public class TelegramController : Controller
    {
        //exchangerseender@gmail.com
        //qmortdoipszfxfuj
        //Crypto Exchanger

        [HttpGet("/ApiTest123")]
        public void APItest()
        {
            CryptoE.Data.API.CoinGecko.Test();
        }
        [HttpGet("/TESTUPDATE")]
        public void UPDATECOIN(string namecoin, decimal mincoin, decimal maxstring, decimal values)
        {
            Coin coin = Singleton.FindCoin(namecoin);
            coin.minAmount = Convert.ToDecimal(mincoin);
            coin.maxAmount = Convert.ToDecimal(maxstring);
            coin.value = Convert.ToDecimal(values);
             Singleton.UpdateStable(coin);
        }
    }
}
