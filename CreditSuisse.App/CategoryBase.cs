using CreditSuisse.App.Models;

namespace CreditSuisse.App
{
    public abstract class CategoryBase
    {
        public TradeModel TradeModel { get; set; }
        public abstract string CategorizeTrade(TradeModel trade);
    }
}
