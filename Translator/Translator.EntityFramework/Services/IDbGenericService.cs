using System.Collections.Generic;
using System.Threading.Tasks;
using Translator.Domain.Models;

namespace Translator.EntityFramework.Services
{
    public interface IDbGenericService<T> where T : DomainObject
    {
        Task<T> Create(T entity);
        Task<bool> Delete(int id);
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
        Task<T> Update(int id, T entity);
    }
}