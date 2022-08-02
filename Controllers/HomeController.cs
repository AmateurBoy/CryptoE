﻿using CryptoE.Controllers;
using CryptoE.Data;
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

        [HttpPost(" ")]
        public IActionResult ываываы()
        {
            return Json("");
        }
        [HttpGet("/submit")]
        public IActionResult Froms(IFormCollection IFC)
        {
            Random random = new Random();            
            int r = random.Next(000000, 999999);
            ClientApplication clientApplication = new ClientApplication
            {
                
                Id = r,
                from = IFC["from"],
                to = IFC["to"],
                amount = IFC["amount"],
                result = IFC["result"],
                wallend = IFC["wallend"],
                email = IFC["email"],
                telegram = IFC["telegram"]
            };
            

            return Json(r);
        }

        [HttpGet("/token")]
        public IActionResult TockinSelect(string from ,string to)
        {
            Coin coin = Singleton.FindCoin(from);
            
            return Json(coin);
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
        public IActionResult gets(string from, string to, decimal amount, bool isBeck)
        {
            AllinfoCoinDTO DC = new();
            decimal result = 0;
            if (isBeck)
            {
                //Замена крипти
                Coin Ofcoin = Singleton.FindCoin(to);
                Coin ToCoin = Singleton.FindCoin(from);

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
