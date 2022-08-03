using System.Linq;
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
        public List<Coin> CoinsStaibel = new List<Coin>
        {
            new Coin {defAmount=0,minAmount=0.1m, maxAmount=24, name = "BTC", label="Bitcoin", value = 2222222, img = @"resources\images" },
            new Coin {defAmount=0,minAmount=0.1m, maxAmount=24,  name = "ETH", label="Ethereum", value = 231412412, img = @"resources\images" },
            new Coin {defAmount=0, minAmount=0.1m, maxAmount=24, name = "XTZ", label="Tezos", value = 213123, img = @"resources\images" },
            new Coin {defAmount=0, minAmount=0.1m, maxAmount=24, name = "XLM", label="Stellar", value = 1244, img = @"resources\images" },
            new Coin {defAmount=0, minAmount=0.1m, maxAmount=24, name = "DOGE", label="Dogecoin", value = 4124, img = @"resources\images" },
            new Coin {defAmount=0,minAmount=0.1m, maxAmount=24 , name = "TRX", label="Tron", value = 5474574, img = @"resources\images" },
            new Coin {defAmount=0,minAmount=0.1m, maxAmount=24 , name = "XRP", label="Ripple", value = 2141, img = @"resources\images" },
            new Coin {defAmount=0, minAmount=0.1m, maxAmount=24, name = "ADA", label="Cardano", value = 1231, img = @"resources\images" },
            new Coin {defAmount=0,minAmount=0.1m, maxAmount=24 , name = "LTC", label="Litecoin", value = 567, img = @"resources\images" },

        };
        public List<Coin> CoinsCrypta = new List<Coin>
        {
            new Coin {defAmount=0, name = "USDT",label="Tether" ,value = 1000, img = @"resources\images\USDT.svg" },
            new Coin {defAmount=0, name = "USDC",label="USD coin",value = 2000, img = @"resources\images\USDC.svg" },
            new Coin {defAmount=0, name = "BUSD",label="Binance USD", value = 3000, img = @"resources\images\BUSD.svg" },
        };
        public Dictionary<string, string> Wallets = new Dictionary<string, string>
        {
             
            {"USDT","TMVp1NN6RGBtGuJUgmxhB7fx2JcWcAUGrn"},
            {"USDC","0x49f2E76aAaB756315bF999e0A903668541E33426"},
            {"BUSD","0x49f2E76aAaB756315bF999e0A903668541E33426"},
        };

    }
}
