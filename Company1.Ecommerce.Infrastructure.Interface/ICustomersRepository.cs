﻿using Company1.Ecommerce.Domain.Entity;

namespace Company1.Ecommerce.Infrastructure.Interface;

public interface ICustomersRepository
{
    #region Sinchronous Methods
    bool Insert(Customers customer);
    bool Update(Customers customer);
    bool Delete(string customerId);
    Customers Get(string customerId);
    IEnumerable<Customers> GetAll();
    #endregion

    #region Asynchronous Methods
    Task<bool> InsertAsync(Customers customer);
    Task<bool> UpdateAsync(Customers customer);
    Task<bool> DeleteAsync(string customerId);
    Task<Customers> GetAsync(string customerId);
    Task<IEnumerable<Customers>> GetAllAsync();
    #endregion
}
