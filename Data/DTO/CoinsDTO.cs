using System.Linq;
using CryptoE.Data;
using CryptoE.Data.Entitys;

namespace CryptoE.Data.DTO
{
    public class CoinsDTO
    {
        public List<Coin> CoinsStaibel = new List<Coin>
        {
            new Coin {defAmaunt="0",minAmaut="0", maxAmaut="0", name = "BTC", label="Bitcoin", value = 2222222, img = @"resources\images" },
            new Coin {defAmaunt="0",minAmaut="0", maxAmaut="0",  name = "ETH", label="Ethereum", value = 231412412, img = @"resources\images" },
            new Coin {defAmaunt="0", minAmaut="0", maxAmaut="0", name = "XTZ", label="Tezos", value = 213123, img = @"resources\images" },
            new Coin {defAmaunt="0", minAmaut="0", maxAmaut="0", name = "XLM", label="Stellar", value = 1244, img = @"resources\images" },
            new Coin {defAmaunt="0", minAmaut="0", maxAmaut="0", name = "DOGE", label="Dogecoin", value = 4124, img = @"resources\images" },
            new Coin {defAmaunt="0",minAmaut="0", maxAmaut="0" , name = "TRX", label="Tron", value = 5474574, img = @"resources\images" },
            new Coin {defAmaunt="0",minAmaut="0", maxAmaut="0" , name = "XRP", label="Ripple", value = 2141, img = @"resources\images" },
            new Coin {defAmaunt="0", minAmaut="0", maxAmaut="0", name = "ADA", label="Cardano", value = 1231, img = @"resources\images" },
            new Coin {defAmaunt="0",minAmaut="0", maxAmaut="0" , name = "LTC", label="Litecoin", value = 567, img = @"resources\images" },

        };
        public List<Coin> CoinsCrypta = new List<Coin>
        {
            new Coin {defAmaunt="0",minAmaut="0", maxAmaut="0" , name = "USDT",label="Tether" ,value = 1000, img = @"resources\images\USDT" },
            new Coin {defAmaunt="0", minAmaut="0", maxAmaut="0", name = "USDC",label="USD coin",value = 2000, img = @"resources\images\USDC" },
            new Coin {defAmaunt="0",minAmaut="0", maxAmaut="0" , name = "BUSD",label="Binance USD", value = 3000, img = @"resources\images\BUSD" },
        };
    }
}
