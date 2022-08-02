using CryptoE.Controllers;
using CryptoE.Data;
using CryptoE.Data.DTO;
using CryptoE.Data.Entitys;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
namespace BitExchanger.Controllers
{
    
    public class DTOclass
    {
        public decimal result { get; set; }
        public decimal amount { get; set; }
        public string minAmout { get; set; }
        public string maxAmout { get; set; }
    }
    [ApiController]
    public class HomeController : Controller
    {
        
       
        
        
        [HttpGet("")]
        [HttpGet("/main")]
        public IActionResult Redirect()
        {
            return Redirect("/index.html");
        }

        
        [HttpGet("/send")]        
        public IActionResult sends(string from, string to, decimal amount, bool isForward)
        {
            DTOclass DC = new();
            decimal result = 0;
            if (isForward)
            {
                
                //Росщет
                //of - c to - в
                Coin Ofcoin = Singleton.FindCoin(to, Singleton.Coins.CoinsCrypta);
                Coin ToCoin = Singleton.FindCoin(from, Singleton.Coins.CoinsStaibel);
                
                decimal Result = ToCoin.value * amount;
                result = (Result / Ofcoin.value) * 0.99m;
                //1 BTS = 100 
                // res = 100*input
                //res/(1 ETH = 20)
                //res*0.99
                DC.result = result;
                DC.amount = amount;
                DC.maxAmout = ToCoin.maxAmaut;
                DC.minAmout = ToCoin.minAmaut;
                return Json(DC);
            }
            else
            {
                  return Ok();
            }


            
        }
        
        [HttpGet("/get")]
        public IActionResult gets(string from, string to, decimal amount, bool isForward)
        {
            DTOclass DC = new();
            decimal result = 0;
            if (isForward)
            {
                //Замена крипти
                Coin Ofcoin = Singleton.FindCoin(to, Singleton.Coins.CoinsCrypta);
                Coin ToCoin = Singleton.FindCoin(from, Singleton.Coins.CoinsStaibel);

                decimal Result = ToCoin.value * amount;
                result = (Result / Ofcoin.value) * 0.99m;
                //1 ETH = 100 
                // res = 100*input
                //res/(1 BTS = 20)
                //res*0.99

                DC.result = result;
                DC.amount = amount;
                DC.maxAmout = Ofcoin.maxAmaut;
                DC.minAmout = Ofcoin.minAmaut;

                return Json(DC);
            }
            else
            {
                return Ok();
            }
        }
        //[HttpGet("/resources/images")]
        //public IActionResult Images()
        //{
        //    return Images();
        //}
    }
    
}
