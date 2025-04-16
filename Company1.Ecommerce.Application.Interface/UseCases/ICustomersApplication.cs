using Company1.Ecommerce.Application.DTO;
using Company1.Ecommerce.Transverse.Common;

namespace Company1.Ecommerce.Application.Interface.UseCases;

public interface ICustomersApplication
{
    #region Sinchronous Methods
    Response<bool> Insert(CustomerDTO customer);
    Response<bool> Update(CustomerDTO customer);
    Response<bool> Delete(string customerId);
    Response<CustomerDTO> Get(string customerId);
    Response<IEnumerable<CustomerDTO>> GetAll();
    #endregion

    #region Asynchronous Methods
    Task<Response<bool>> InsertAsync(CustomerDTO customer);
    Task<Response<bool>> UpdateAsync(CustomerDTO customer);
    Task<Response<bool>> DeleteAsync(string customerId);
    Task<Response<CustomerDTO>> GetAsync(string customerId);
    Task<Response<IEnumerable<CustomerDTO>>> GetAllAsync();
    Task<ResponsePagination<IEnumerable<CustomerDTO>>> GetAllAsync(int pageIndex, int pageSize);
    #endregion
}
