using System.Collections.Generic;
using System.Threading.Tasks;

namespace CreditSuisse.Application.Interfaces
{
    public interface IAppServiceBase<T> where T : class
    {
        Task<T> Insert(T obj);
        Task<IEnumerable<T>> GetByName(string name);
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();        
        void Dispose();
    }
}
