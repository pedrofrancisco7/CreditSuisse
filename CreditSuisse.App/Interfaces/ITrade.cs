using CreditSuisse.App.Models;
using System.Collections.Generic;

namespace CreditSuisse.App.Interfaces
{
    public interface ITrade
    {
        IEnumerable<CategoryModel> GetCategoryByTrade(TradeModel trade);
    }
}
