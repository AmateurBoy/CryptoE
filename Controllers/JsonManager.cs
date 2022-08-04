using CryptoE.Data.Entitys;
using System.Text.Json;
namespace CryptoE.Controllers
{
    public static class JsonManager
    {        
        public static async void RecCoins(List<Coin> coins)
        {
            if (Singleton.Coins.CoinsStaibel[0].name == coins[0].name)
            {
                // сохранение данных
                using (FileStream fs = new FileStream(@"Data/JSON/CoinsStaibel.json", FileMode.Create))
                {
                    
                    await JsonSerializer.SerializeAsync<List<Coin>>(fs, coins);
                    Console.WriteLine("Data update json");
                }
            }
            if (Singleton.Coins.CoinsCrypta[0].name == coins[0].name)
            {
                // сохранение данных
                using (FileStream fs = new FileStream(@"Data/JSON/CoinsCrypta.json", FileMode.Create))
                {

                    await JsonSerializer.SerializeAsync<List<Coin>>(fs, coins);
                    Console.WriteLine("Data update Json");
                }
            }


        }
        public static async Task<List<Coin>> ReadCoins(string namejsonfile)
        {
            if (namejsonfile == "JSON/CoinsStaibel.json")
            {
                // чтение данных
                using (FileStream fs = new FileStream("Data/JSON/CoinsStaibel.json", FileMode.OpenOrCreate))
                {
                    List<Coin> Coins = await JsonSerializer.DeserializeAsync<List<Coin>>(fs);

                   
                    return Coins;
                }
            }
            else if(namejsonfile == "JSON/CoinsCrypta.json")
            {
                // чтение данных
                using (FileStream fs = new FileStream("Data/JSON/CoinsCrypta.json", FileMode.OpenOrCreate))
                {
                    List<Coin> Coins = await JsonSerializer.DeserializeAsync<List<Coin>>(fs);

                    return Coins;
                }
            }
            else
            {
                List<Coin> LC = new();
                return LC;
            }
            
            
        }
        public static async void RecWallet(Dictionary<string,string> Wallet)
        {
            // сохранение данных
            using (FileStream fs = new FileStream(@"Data/JSON/Wallet.json", FileMode.Create))
            {

                await JsonSerializer.SerializeAsync<Dictionary<string,string>>(fs, Wallet);
                Console.WriteLine("Data update json wallet");
            }
        }
        public static async Task<Dictionary<string,string>> ReadWallet()
        {
            // чтение данных
            using (FileStream fs = new FileStream("Data/JSON/Wallet.json", FileMode.OpenOrCreate))
            {
                Dictionary<string, string> Wallet = await JsonSerializer.DeserializeAsync<Dictionary<string,string>>(fs);

                
                return Wallet;
            }
        }
        public static async Task<decimal> ReadCommission()
        {
            // чтение данных
            using (FileStream fs = new FileStream("Data/JSON/Procent.json", FileMode.OpenOrCreate))
            {
                decimal Procent = await JsonSerializer.DeserializeAsync<decimal>(fs);
                
                return Procent;
            }
        }
        public static async void RecCommission(decimal newProcent)
        {
            // сохранение данных
            using (FileStream fs = new FileStream(@"Data/JSON/Procent.json", FileMode.Create))
            {

                await JsonSerializer.SerializeAsync(fs, newProcent);
                Console.WriteLine("Data update procent json");
            }
        }
        public static async Task<AdminUser> ReadAdminlist()
        {
            // чтение данных
            using (FileStream fs = new FileStream("Data/JSON/AdminUsers.json", FileMode.OpenOrCreate))
            {  
                
               return await JsonSerializer.DeserializeAsync<AdminUser>(fs);               
            }
        }
        public static async void RecAcaunt(AdminUser admin)
        {
            // сохранение данных
            using (FileStream fs = new FileStream(@"Data/JSON/AdminUsers.json", FileMode.Create))
            {

                await JsonSerializer.SerializeAsync<AdminUser>(fs, admin);
                Console.WriteLine("Data update Admin json");
            }
        }
        public static async void DelAcaunt()
        {
            // сохранение данных
            using (FileStream fs = new FileStream(@"Data/JSON/AdminUsers.json", FileMode.Create))
            {
                AdminUser admin = new AdminUser
                {
                    Id = 0,
                    Name = "NotAdmin"

                };
                await JsonSerializer.SerializeAsync<AdminUser>(fs, admin);
                Console.WriteLine("Data update Admin json");
            }
        }

    }
}
