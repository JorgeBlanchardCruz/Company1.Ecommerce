using Company1.Ecommerce.Domain.Entity;
using Company1.Ecommerce.Domain.Interface;
using Company1.Ecommerce.Infrastructure.Interface;

namespace Company1.Ecommerce.Domain.Core;

public class CustomersDomain : ICustomersDomain
{
    private readonly IUnitOfWork _unitOfWork;

    public CustomersDomain(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    #region Sinchronous Methods

    public bool Insert(Customers customer)
    {
        return _unitOfWork.Customers.Insert(customer);
    }

    public bool Update(Customers customer)
    {
        return _unitOfWork.Customers.Update(customer);
    }

    public bool Delete(string customerId)
    {
        return _unitOfWork.Customers.Delete(customerId);
    }

    public Customers Get(string customerId)
    {
        return _unitOfWork.Customers.Get(customerId);
    }

    public IEnumerable<Customers> GetAll()
    {
        return _unitOfWork.Customers.GetAll();
    }

    #endregion

    #region Asynchronous Methods

    public async Task<bool> InsertAsync(Customers customer)
    {
        return await _unitOfWork.Customers.InsertAsync(customer);
    }

    public async Task<bool> UpdateAsync(Customers customer)
    {
        return await _unitOfWork.Customers.UpdateAsync(customer);
    }

    public async Task<bool> DeleteAsync(string customerId)
    {
        return await _unitOfWork.Customers.DeleteAsync(customerId);
    }

    public async Task<Customers> GetAsync(string customerId)
    {
        return await _unitOfWork.Customers.GetAsync(customerId);
    }

    public async Task<IEnumerable<Customers>> GetAllAsync()
    {
        return await _unitOfWork.Customers.GetAllAsync();
    }

    #endregion
}
