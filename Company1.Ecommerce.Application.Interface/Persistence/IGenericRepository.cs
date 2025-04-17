using Company1.Ecommerce.Domain.Entities;

namespace Company1.Ecommerce.Application.Interface.Persistence;

public interface IGenericRepository<T> where T : class
{
    #region Sinchronous Methods
    bool Insert(T entity);
    bool Update(T entity);
    bool Delete(string entity);
    Customer Get(string id);
    IEnumerable<Customer> GetAll();
    #endregion

    #region Asynchronous Methods
    Task<bool> InsertAsync(T entity);
    Task<bool> UpdateAsync(T entity);
    Task<bool> DeleteAsync(string id);
    Task<Customer> GetAsync(string id);
    Task<IEnumerable<T>> GetAllAsync();

    Task<IEnumerable<T>> GetAllAsync(int page, int recordsPerPage);
    Task<int> CountAsync();
    #endregion
}
