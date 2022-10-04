using CreditSuisse.Data.Context;
using CreditSuisse.Data.Interfaces.Repository;
using CreditSuisse.Domain.Entities;

namespace CreditSuisse.Data.Repository
{
    public class TradeRepository : RepositoryBase<Trade>, ITradeRepository
    {
        private readonly CreditSuisseContext _context;
        public TradeRepository(CreditSuisseContext context) : base(context)
        {
            _context = context;
        }
        
    }
}
