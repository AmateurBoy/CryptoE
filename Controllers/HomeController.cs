using CryptoE.Controllers;
using CryptoE.Data;
using CryptoE.Data.API;
using CryptoE.Data.DTO;
using CryptoE.Data.Entitys;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace BitExchanger.Controllers
{
   
    
    [ApiController]
    public class HomeController : Controller
    {
        [HttpPost("/submit")]
        public async  Task<IActionResult> Froms(IFormCollection IFC)
        {
            Random random = new Random();            
            int r = random.Next(100000, 999999);
            ClientApplication clientApplication = new ClientApplication
            {

                Id = r,
                from = IFC["from"],
                to = IFC["to"],
                amount = IFC["amount"],
                result = IFC["result"],
                wallend = IFC["wallet"],
                email = IFC["email"],
                Network = IFC["Network"],
                telegram = IFC["telegram"]

            };
            GmailSeendler GS = new();
            await Task.Run(() => GS.Seend(clientApplication,false));
            

            return Json(r);
        }

        [HttpGet("/token")]
        public IActionResult TockinSelect(string from ,string to)
        {
            
            Coin coin = Singleton.FindCoin(from);

            DTOtoken dTOtoken = new() 
            {

                maxAmount = Convert.ToString(coin.maxAmount),
                minAmount = Convert.ToString(coin.minAmount),
                wallet = Singleton.GetWallet(from),
                value = Convert.ToString((coin.value * coin.corecting))
            };

            return Json(dTOtoken);
        }

        [HttpGet("")]
        [HttpGet("/main")]
        public IActionResult Redirect()
        {
            
            return Redirect("/index.html");
        }

        
        [HttpGet("/send")]        
        public IActionResult sends(string from, string to, decimal amount, bool isForward)
        {
            AllinfoCoinDTO DC = new();
            decimal result = 0;
            if (isForward)
            {
                //Росщет
                //of - c to - в
                Coin Ofcoin = Singleton.FindCoin(to);
                Coin ToCoin = Singleton.FindCoin(from);
                
                decimal Result = (ToCoin.value*ToCoin.corecting) * amount;
                result = (Result / Ofcoin.value);
                //1 BTS = 100 
                // res = 100*input
                //res/(1 ETH = 20)
                //res*0.99
                DC.result = result;
                DC.amount = Convert.ToDecimal(amount);
                DC.maxAmount = Convert.ToDecimal(ToCoin.maxAmount);
                DC.minAmount = Convert.ToDecimal(ToCoin.minAmount);
                return Json(DC);
            }
            else
            {
                  return Ok();
            }


            
        }
        
        [HttpGet("/get")]
        public IActionResult gets(string from, string to, decimal amount, bool isBeck)
        {
            AllinfoCoinDTO DC = new();
            decimal result = 0;
            if (isBeck)
            {
                //Замена крипти
                Coin Ofcoin = Singleton.FindCoin(to);
                Coin ToCoin = Singleton.FindCoin(from);
                
                decimal Result = (ToCoin.value/Ofcoin.corecting) * amount;
                result = (Result/Ofcoin.value);
                //1 ETH = 100 
                // res = 100*input
                //res/(1 BTS = 20)
                //res*0.99

                DC.result = result;
                DC.amount = amount;
                DC.maxAmount = Convert.ToDecimal(Ofcoin.maxAmount);
                DC.minAmount = Convert.ToDecimal(Ofcoin.minAmount);

                return Json(DC);
            }
            else
            {
                return Ok();
            }
        }
        
    }
    
}
