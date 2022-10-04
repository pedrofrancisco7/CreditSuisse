using System.Collections.Generic;
using System.Threading.Tasks;

namespace CreditSuisse.Domain.Interfaces.Repository
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<IEnumerable<T>> GetByName(string name);
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        void Dispose();

    }
}
