using AutoMapper;
using Company1.Ecommerce.Application.DTO;
using Company1.Ecommerce.Application.Interface;
using Company1.Ecommerce.Domain.Entity;
using Company1.Ecommerce.Domain.Interface;
using Company1.Ecommerce.Transverse.Common;

namespace Company1.Ecommerce.Application.Main;

public class CustomersApplication : ICustomersApplication
{
    private readonly ICustomersDomain _customerDomain;
    private readonly IMapper _mapper;
    private readonly IAppLogger<CustomersApplication> _logger;

    public CustomersApplication(ICustomersDomain customerDomain, IMapper mapper, IAppLogger<CustomersApplication> logger)
    {
        _customerDomain = customerDomain;
        _mapper = mapper;
        _logger = logger;
    }

    #region Sinchronous Methods
    public Response<bool> Insert(CustomersDTO customerDTO)
    {
        var response = new Response<bool>();
        try
        {
            var customer = _mapper.Map<Customers>(customerDTO);
            response.Data = _customerDomain.Insert(customer);

            if(response.Data)
            {
                response.IsSuccess = true;
                response.Message = "Customer inserted successfully";
            }
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
        }

        return response;
    }

    public Response<bool> Update(CustomersDTO customer)
    {
        var response = new Response<bool>();
        try
        {
            var customerEntity = _mapper.Map<Customers>(customer);
            response.Data = _customerDomain.Update(customerEntity);
            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = "Customer updated successfully";
            }
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
        }

        return response;
    }

    public Response<bool> Delete(string customerId)
    {
        var response = new Response<bool>();
        try
        {
            response.Data = _customerDomain.Delete(customerId);
            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = "Customer deleted successfully";
            }
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
        }

        return response;
    }

    public Response<CustomersDTO> Get(string customerId)
    {
        var response = new Response<CustomersDTO>();
        try
        {
            var customer = _customerDomain.Get(customerId);
            response.Data = _mapper.Map<CustomersDTO>(customer);
            response.IsSuccess = true;
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
        }

        return response;
    }

    public Response<IEnumerable<CustomersDTO>> GetAll()
    {
        var response = new Response<IEnumerable<CustomersDTO>>();
        try
        {
            var customers = _customerDomain.GetAll();
            response.Data = _mapper.Map<IEnumerable<CustomersDTO>>(customers);
            response.IsSuccess = true;
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
        }

        return response;
    }
    #endregion

    #region Asynchronous Methods
    public async Task<Response<bool>> InsertAsync(CustomersDTO customerDTO)
    {
        var response = new Response<bool>();
        try
        {
            var customer = _mapper.Map<Customers>(customerDTO);
            response.Data = await _customerDomain.InsertAsync(customer);

            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = "Customer inserted successfully";
            }
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
        }

        return response;
    }
    public async Task<Response<bool>> UpdateAsync(CustomersDTO customerDTO)
    {
        var response = new Response<bool>();
        try
        {
            var customer = _mapper.Map<Customers>(customerDTO);
            response.Data = await _customerDomain.UpdateAsync(customer);
            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = "Customer updated successfully";
            }
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
        }
        return response;
    }

    public async Task<Response<bool>> DeleteAsync(string customerId)
    {
        var response = new Response<bool>();
        try
        {
            response.Data = await _customerDomain.DeleteAsync(customerId);
            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = "Customer deleted successfully";
            }
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
        }
        return response;
    }

    public async Task<Response<CustomersDTO>> GetAsync(string customerId)
    {
        var response = new Response<CustomersDTO>();
        try
        {
            var customer = await _customerDomain.GetAsync(customerId);
            response.Data = _mapper.Map<CustomersDTO>(customer);
            response.IsSuccess = true;
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
        }
        return response;
    }

    public async Task<Response<IEnumerable<CustomersDTO>>> GetAllAsync()
    {
        var response = new Response<IEnumerable<CustomersDTO>>();
        try
        {
            var customers = await _customerDomain.GetAllAsync();
            response.Data = _mapper.Map<IEnumerable<CustomersDTO>>(customers);
            if (response.Data is not null)
            {
                response.IsSuccess = true;
                response.Message = "Customers found";
                _logger.LogInformation(response.Message);
            }
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
            _logger.LogError(response.Message);
        }
        return response;
    }

    public async Task<ResponsePagination<IEnumerable<CustomersDTO>>> GetAllAsync(int pageIndex, int pageSize)
    {
        var response = new ResponsePagination<IEnumerable<CustomersDTO>>();
        try
        {
            var count = await _customerDomain.CountAsync();

            var customers = await _customerDomain.GetAllAsync(pageIndex, pageSize);
            response.Data = _mapper.Map<IEnumerable<CustomersDTO>>(customers);

            if (response.Data is not null)
            {
                response.TotalPages = (int)Math.Ceiling((double)count / pageSize);
                response.TotalRecords = count;
                response.PageIndex = pageIndex;
                response.PageSize = pageSize;
                response.IsSuccess = true;
                response.Message = "Customers found";
            }

        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
        }

        return response;
    }

    #endregion
}
