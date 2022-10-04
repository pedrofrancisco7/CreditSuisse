using System;
using System.Collections.Generic;

namespace CreditSuisse.App.Models
{
    public class OperationModel
    {
        public OperationModel()
        {
            Trades = new List<TradeModel>();
        }

        public DateTime ReferenceDate { get; set; }
        public int NumOfTrades { get; set; }

        public List<TradeModel> Trades { get; set; }
    }
}
