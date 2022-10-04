using CreditSuisse.Domain.Entities;
using CreditSuisse.Domain.Interfaces.Repository;
using CreditSuisse.Domain.Interfaces.Services;

namespace CreditSuisse.Domain.Services
{
    public class CategoryService : ServiceBase<Category>, ICategoryService
    {
        private readonly ICategoryRepository _panelRepository;

        public CategoryService(ICategoryRepository panelRepository) : base(panelRepository)
        {
            _panelRepository = panelRepository;
        }        

    }
}
