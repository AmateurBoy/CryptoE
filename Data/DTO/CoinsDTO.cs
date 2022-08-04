using System.Linq;
using CryptoE.Controllers;
using CryptoE.Data;
using CryptoE.Data.Entitys;

namespace CryptoE.Data.DTO
{
    public class CoinsDTO
    {
        private static CoinsDTO instance;
        private static object syncRoot = new Object();
        private CoinsDTO()
        { }

        public static CoinsDTO getInstance()
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                        instance = new CoinsDTO();
                }
            }

            return instance;
        }

       
              
        
        

        public List<Coin> CoinsStaibel = JsonManager.ReadCoins(@"JSON/CoinsStaibel.json").Result;
        public List<Coin> CoinsCrypta = JsonManager.ReadCoins(@"JSON/CoinsCrypta.json").Result;

        public decimal Commission = JsonManager.ReadCommission().Result;

        public Dictionary<string, string> WalletsStaibel = new Dictionary<string, string>
        {
             
            {"USDT","TMVp1NN6RGBtGuJUgmxhB7fx2JcWcAUGrn"},
            {"USDC","0x49f2E76aAaB756315bF999e0A903668541E33426"},
            {"BUSD","0x49f2E76aAaB756315bF999e0A903668541E33426"},
        };
        public Dictionary<string, string> WalletsCrypto = JsonManager.ReadWallet().Result;
        

    }
}
