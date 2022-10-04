using System;

namespace CreditSuisse.Api.Models
{
    public class TradeModel
    {
        public int ID { get; set; }
        public double Value { get; set; }
        public string ClientSector { get; set; }
        public DateTime NextPaymentDate { get; set; }
        public string Category { get; set; }
    }
}
