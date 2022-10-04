using CreditSuisse.Application.Interfaces;
using CreditSuisse.Domain.Entities;
using CreditSuisse.Domain.Interfaces.Services;

namespace CreditSuisse.Application.Services
{
    public class CategoryAppService : AppServiceBase<Category>, ICategoryAppService
    {
        private readonly ICategoryService _panelAppService;
        public CategoryAppService(ICategoryService panelAppService) : base(panelAppService)
        {
            _panelAppService = panelAppService;
        }
    }
}
