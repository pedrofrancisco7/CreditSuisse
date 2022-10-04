using System;

namespace CreditSuisse.App.Models
{
    public class TradeModel
    {
        public int ID { get; set; }
        public double Value { get; set; }        
        public string ClientSector { get; set; }        
        public DateTime NextPaymentDate { get; set; }
    }
}
