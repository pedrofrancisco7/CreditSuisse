using CreditSuisse.Application.Interfaces;
using CreditSuisse.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CreditSuisse.Application.Services
{
    public class AppServiceBase<T> : IAppServiceBase<T> where T : class
    {
        private readonly IServiceBase<T> _serviceBase;
        public AppServiceBase(IServiceBase<T> serviceBase)
        {
            _serviceBase = serviceBase;
        }
        public void Dispose()
        {
            _serviceBase.Dispose();
        }

        public Task<IEnumerable<T>> GetAll()
        {
            return _serviceBase.GetAll();
        }

        public Task<T> GetById(int id)
        {
            return _serviceBase.GetById(id);
        }

        public Task<IEnumerable<T>> GetByName(string name)
        {
            return _serviceBase.GetByName(name);
        }
    }
}
