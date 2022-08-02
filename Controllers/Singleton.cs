using CryptoE.Data.DTO;
using CryptoE.Data.Entitys;

namespace CryptoE.Controllers
{
    public static class Singleton
    {
        
        public static CoinsDTO Coins = new();
        public static void UpdateStable(List<Coin> Stable)
        {
            Coins.CoinsStaibel = Stable;
        }
        public static void UpdateCripto(List<Coin> Cripto)
        {
            Coins.CoinsCrypta = Cripto;
        }
        public static Coin FindCoin(string name, List<Coin> FindsCoins)
        {
            Coin coin = new();
            foreach (Coin item in FindsCoins)
            {
                if (item.name == name)
                {
                    coin = item;
                }
            }
            return coin;
        }
    }
}
