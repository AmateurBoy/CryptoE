using CryptoE.Data.Entitys;
using Microsoft.AspNetCore.Mvc;

namespace CryptoE.Controllers
{
    public class TelegramController : Controller
    {
        [HttpGet("/TESTUPDATE")]
        public void UPDATECOIN(string namecoin, decimal mincoin, decimal maxstring, decimal values)
        {
            Coin coin = Singleton.FindCoin(namecoin);
            coin.minAmaut = Convert.ToDecimal(mincoin);
            coin.maxAmaut = Convert.ToDecimal(maxstring);
            coin.value = Convert.ToDecimal(values);
             Singleton.UpdateStable(coin);
        }
    }
}
