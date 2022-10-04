using CreditSuisse.Domain.Entities;
using CreditSuisse.Domain.Interfaces.Repository;
using CreditSuisse.Domain.Interfaces.Services;

namespace CreditSuisse.Domain.Services
{
    public class ServiceCategory : ServiceBase<Category>, IServiceCategory
    {
        private readonly IRepositoryCategory _repositoryCategory;

        public ServiceCategory(IRepositoryCategory repositoryCategory) : base(repositoryCategory)
        {
            _repositoryCategory = repositoryCategory;
        }
    }
}
