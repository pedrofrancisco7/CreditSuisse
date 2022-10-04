using CreditSuisse.Domain.Entities;

namespace CreditSuisse.Data.Interfaces.Repository
{
    public interface ICategoryRepository : IRepositoryBase<Category>, Domain.Interfaces.Repository.ICategoryRepository
    {
    }
}
