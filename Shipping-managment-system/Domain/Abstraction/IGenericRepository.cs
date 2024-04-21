using Microsoft.AspNetCore.DataProtection.KeyManagement;

namespace Shipping_managment_system.Domain.Abstraction
{
    public interface IGenericRepository<T,Tkey>
    {
        Task<T> Add(T entity);
        Task Delete(T entity);
        Task<List<T>> GetAll();
        Task<T> GetById(Tkey id);
        Task<T> Update(T entity);
    }
}
