using CreditSuisse.App.Models;

namespace CreditSuisse.App.Categories
{
    public class Category : CategoryBase
    {
        public override string CategorizeTrade(TradeModel tradeModel)
        {

            if (tradeModel.ReferenceDate.AddDays(-30) > tradeModel.NextPaymentDate)
            {
                return "EXPIRED";
            }
            else if (tradeModel.Value > 1000000 && tradeModel.ClientSector?.ToUpper() == "PRIVATE")
            {
                return "HIGHRISK";
            }
            else if (tradeModel.Value > 1000000 && tradeModel.ClientSector?.ToUpper() == "PUBLIC")
            {
                return "MEDIUMRISK";
            }

            return null;
        }
    }
}
