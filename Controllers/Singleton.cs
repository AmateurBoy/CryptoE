using CryptoE.Data.DTO;
using CryptoE.Data.Entitys;

namespace CryptoE.Controllers
{
    public static class Singleton
    {
        
        public static CoinsDTO Coins = CoinsDTO.getInstance();
        public static void UpdateStable(Coin coinStable)
        {
            foreach (var item in Singleton.Coins.CoinsStaibel)
            {
                if(item.name==coinStable.name)
                {
                    Singleton.Coins.CoinsStaibel[Singleton.Coins.CoinsStaibel.IndexOf(item)]=coinStable;
                    break;
                }
            }
        }
        public static List<Coin> WhatCoinList(string NameCoin)
        {
            bool Crypto = false;
            bool Staibol = false;
            bool Undefaind = false;
            List<Coin> newCoins=new();
            
            
                foreach (var item in Coins.CoinsCrypta)
                {
                    if (item.name == NameCoin)
                    {
                        Crypto = true;
                        newCoins = Coins.CoinsCrypta;
                        break;
                    }
                }
            
            
            
            if(Crypto==false)
            {
                foreach (var item in Coins.CoinsStaibel)
                {
                    if (item.name == NameCoin)
                    {
                        Staibol = true;
                        newCoins= Coins.CoinsStaibel;
                        break;
                    }
                    
                }
            }
            return newCoins;
           

        }
        public static void UpdateCripto(Coin coinCrypto)
        {
            foreach (var item in Singleton.Coins.CoinsCrypta)
            {
                if (item.name == coinCrypto.name)
                {
                    Singleton.Coins.CoinsCrypta[Singleton.Coins.CoinsCrypta.IndexOf(item)] = coinCrypto;
                    break;
                }
            }
        }
        public static Coin FindCoin(string name)
        {
            Coin coin = new();
            foreach (Coin item in WhatCoinList(name))
            {
                if (item.name == name)
                {
                    coin = item;
                    break;
                }
            }
            
            return coin;
        }
        public static string GetWallet(string nameCoin)
        {
            return Coins.WalletsCrypto[nameCoin];
        }
        public static string GetAllCoin()
        {
            string res = "";
            foreach (var item in Coins.CoinsStaibel)
            {
                res += $"{item.name} Курс:{item.value} Корректировка курса{item.corecting}\n";
            }
            return res;
        }
        public static string GetAllWallet()
        {
            string res = "";
            foreach (var item in Coins.WalletsCrypto)
            {
                res += $"Валюта {item.Key} \n Кошелек => {item.Value}\n===============================\n";
            }
            return res;
        }
    }
}
