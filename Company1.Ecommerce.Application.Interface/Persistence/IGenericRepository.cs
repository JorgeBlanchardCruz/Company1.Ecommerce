﻿using Company1.Ecommerce.Domain.Entities;

namespace Company1.Ecommerce.Application.Interface.Persistence;

public interface IGenericRepository<T> where T : class
{
    #region Sinchronous Methods
    bool Insert(T entity);
    bool Update(T entity);
    bool Delete(int id);
    Customer Get(int id);
    IEnumerable<Customer> GetAll();
    #endregion

    #region Asynchronous Methods
    Task<bool> InsertAsync(T entity);
    Task<bool> UpdateAsync(T entity);
    Task<bool> DeleteAsync(int id);
    Task<Customer> GetAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();

    Task<IEnumerable<T>> GetAllAsync(int page, int recordsPerPage);
    Task<int> CountAsync();
    #endregion
}
