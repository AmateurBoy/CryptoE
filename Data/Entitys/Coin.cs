namespace CryptoE.Data.Entitys
{
    
    public class Coin
    {        
        public string name { get; set; }
        public string label { get; set; }
        public decimal value { get; set; }
        public decimal corecting { get; set; }    
        public decimal minAmount { get; set; }
        public decimal maxAmount { get; set; }
        public decimal defAmount { get; set; }   
    }
}
