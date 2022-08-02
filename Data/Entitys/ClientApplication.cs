namespace CryptoE.Data.Entitys
{
    public class ClientApplication
    {
        public int Id { get; set; }
        public string from { get; set; }
        public string to { get; set; }  
        public string amount { get; set; }
        public string result { get; set; }
        public string wallend { get; set; }
        public string email { get; set; }
        public string? telegram { get; set; }
    }
}
