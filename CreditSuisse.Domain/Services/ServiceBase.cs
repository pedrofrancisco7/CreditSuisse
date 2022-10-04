using CreditSuisse.Domain.Interfaces.Repository;
using CreditSuisse.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CreditSuisse.Domain.Services
{
    public class ServiceBase<T> : IDisposable, IServiceBase<T> where T : class
    {
        private readonly IRepositoryBase<T> _repositoryBase;
        public ServiceBase(IRepositoryBase<T> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }
        public void Dispose()
        {
            _repositoryBase.Dispose();
        }

        public Task<IEnumerable<T>> GetAll()
        {
            return _repositoryBase.GetAll();
        }

        public Task<T> GetById(int id)
        {
            return _repositoryBase.GetById(id);
        }

        public Task<IEnumerable<T>> GetByName(string name)
        {
            return _repositoryBase.GetByName(name);
        }

        public Task<T> Insert(T obj)
        {
            return _repositoryBase.Insert(obj);
        }
    }
}
