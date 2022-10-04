using CreditSuisse.Data.Context;
using CreditSuisse.Data.Interfaces.Repository;
using CreditSuisse.Domain.Entities;

namespace CreditSuisse.Data.Repository
{
    public class RepositoryCategory : RepositoryBase<Category>, IRepositoryCategory
    {
        private readonly CreditSuisseContext _context;
        public RepositoryCategory(CreditSuisseContext context) : base(context)
        {
            _context = context;
        }
    }
}
