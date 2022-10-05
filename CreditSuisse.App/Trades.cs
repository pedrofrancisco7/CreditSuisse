using CreditSuisse.App.Models;
using System.Collections.Generic;

namespace CreditSuisse.App
{
    public class Trades
    {
        private CategoryBase _category;
        public List<string> _categories;


        public Trades(CategoryBase category)
        {
            _categories = new List<string>();           
            _category = category;

        }

        public void GetCategory(OperationModel operation, bool isPep = false)
        {
            foreach (var trade in operation.Trades)
            {
                _categories.Add(_category.CategorizeTrade(trade));
            }

             
        }
    }
}
