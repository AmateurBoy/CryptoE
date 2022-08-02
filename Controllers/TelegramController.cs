using CryptoE.Data.Entitys;
using Microsoft.AspNetCore.Mvc;

namespace CryptoE.Controllers
{
    public class TelegramController : Controller
    {
        [HttpGet("/TESTUPDATE")]
        public void UPDATECOIN(string namecoin, string mincoin, string maxstring, string values)
        {
            Coin coin = Singleton.FindCoin(namecoin);
            coin.minAmaut = mincoin;
            coin.maxAmaut = maxstring;
            coin.value = Convert.ToDecimal(values);
             Singleton.UpdateStable(coin);
        }
    }
}
