using CreditSuisse.Domain.Entities;
using CreditSuisse.Domain.Interfaces.Repository;
using CreditSuisse.Domain.Interfaces.Services;

namespace CreditSuisse.Domain.Services
{
    public class ServiceTrade : ServiceBase<Trade>, IServiceTrade
    {
        private readonly IRepositoryTrade _repositoryTrade;

        public ServiceTrade(IRepositoryTrade repositoryTrade) : base(repositoryTrade)
        {
            _repositoryTrade = repositoryTrade;
        }
    }
}
