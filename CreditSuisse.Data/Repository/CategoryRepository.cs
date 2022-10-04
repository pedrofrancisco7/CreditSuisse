using CreditSuisse.Domain.Entities;
using CreditSuisse.Data.Interfaces.Repository;
using CreditSuisse.Data.Context;

namespace CreditSuisse.Data.Repository
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        private readonly CreditSuisseContext _context;
        public CategoryRepository(CreditSuisseContext context) : base(context)
        {
            _context = context;
        }
    }
}
