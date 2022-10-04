using CreditSuisse.Application.Interfaces;
using CreditSuisse.Domain.Entities;
using CreditSuisse.Domain.Interfaces.Services;

namespace CreditSuisse.Application.Services
{
    public class AppServiceCategory : AppServiceBase<Category>, IAppServiceCategory
    {
        private readonly IServiceCategory _categoryAppService;
        public AppServiceCategory(IServiceCategory categoryAppService) : base(categoryAppService)
        {
            _categoryAppService = categoryAppService;
        }        
    }
}
