using CreditSuisse.Data.Context;
using CreditSuisse.Data.Interfaces.Repository;
using CreditSuisse.Domain.Entities;

namespace CreditSuisse.Data.Repository
{
    public class RepositoryTrade : RepositoryBase<Trade>, IRepositoryTrade
    {
        private readonly CreditSuisseContext _context;
        public RepositoryTrade(CreditSuisseContext context) : base(context)
        {
            _context = context;
        }
    }
}
