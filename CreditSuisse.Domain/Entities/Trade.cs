using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CreditSuisse.Domain.Entities
{
    [Table("Trades")]
    public class Trade
    {
        [Key]
        public int ID { get; set; }
        public double Value { get; set; }
        public string ClientSector { get; set; }
        public DateTime NextPaymentDate { get; set; }

    }
}
