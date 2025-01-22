using Company1.Ecommerce.Application.DTO;
using Company1.Ecommerce.Transverse.Common;

namespace Company1.Ecommerce.Application.Interface;

public interface ICustomersApplication
{
    #region Sinchronous Methods
    Response<bool> Insert(CustomersDTO customer);
    Response<bool> Update(CustomersDTO customer);
    Response<bool> Delete(string customerId);
    Response<CustomersDTO> Get(string customerId);
    Response<IEnumerable<CustomersDTO>> GetAll();
    #endregion

    #region Asynchronous Methods
    Task<Response<bool>> InsertAsync(CustomersDTO customer);
    Task<Response<bool>> UpdateAsync(CustomersDTO customer);
    Task<Response<bool>> DeleteAsync(string customerId);
    Task<Response<CustomersDTO>> GetAsync(string customerId);
    Task<Response<IEnumerable<CustomersDTO>>> GetAllAsync();
    Task<ResponsePagination<IEnumerable<CustomersDTO>>> GetAllAsync(int pageIndex, int pageSize);
    #endregion
}
