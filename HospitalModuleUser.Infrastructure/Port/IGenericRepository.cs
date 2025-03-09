
using System.Linq.Expressions;
using HospitalModuleUser.Domain.Common;
namespace HospitalModuleUser.Infra.Port
{
    internal interface IGenericRepository<T> where T : DomainEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        void UpdateAsync(T entity);
        Task<T> GetAsync(Guid id);
        void DeleteAsync(T entity);
        Task<IEnumerable<T>> GetFilteredAsync(Expression<Func<T, bool>> filter);
    }
}
