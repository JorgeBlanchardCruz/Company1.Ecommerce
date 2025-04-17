using AutoMapper;
using Company1.Ecommerce.Application.DTO;
using Company1.Ecommerce.Application.Interface.Persistence;
using Company1.Ecommerce.Application.Interface.UseCases;
using Company1.Ecommerce.Domain.Entities;
using Company1.Ecommerce.Transverse.Common;

namespace Company1.Ecommerce.Application.UseCases.Customers;

public class CustomersApplication : ICustomersApplication
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IAppLogger<CustomersApplication> _logger;

    public CustomersApplication(IMapper mapper, IAppLogger<CustomersApplication> logger, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _logger = logger;

        _unitOfWork = unitOfWork;
    }

    #region Sinchronous Methods
    public Response<bool> Insert(CustomerDTO customerDTO)
    {
        var response = new Response<bool>();
        try
        {
            var customer = _mapper.Map<Customer>(customerDTO);
            response.Data = _unitOfWork.Customers.Insert(customer);

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

    public Response<bool> Update(CustomerDTO customer)
    {
        var response = new Response<bool>();
        try
        {
            var customerEntity = _mapper.Map<Customer>(customer);
            response.Data = _unitOfWork.Customers.Update(customerEntity);
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

    public Response<bool> Delete(int customerId)
    {
        var response = new Response<bool>();
        try
        {
            response.Data = _unitOfWork.Customers.Delete(customerId);
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

    public Response<CustomerDTO> Get(int customerId)
    {
        var response = new Response<CustomerDTO>();
        try
        {
            var customer = _unitOfWork.Customers.Get(customerId);
            response.Data = _mapper.Map<CustomerDTO>(customer);
            response.IsSuccess = true;
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
        }

        return response;
    }

    public Response<IEnumerable<CustomerDTO>> GetAll()
    {
        var response = new Response<IEnumerable<CustomerDTO>>();
        try
        {
            var customers = _unitOfWork.Customers.GetAll();
            response.Data = _mapper.Map<IEnumerable<CustomerDTO>>(customers);
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
    public async Task<Response<bool>> InsertAsync(CustomerDTO customerDTO)
    {
        var response = new Response<bool>();
        try
        {
            var customer = _mapper.Map<Customer>(customerDTO);
            response.Data = await _unitOfWork.Customers.InsertAsync(customer);

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
    public async Task<Response<bool>> UpdateAsync(CustomerDTO customerDTO)
    {
        var response = new Response<bool>();
        try
        {
            var customer = _mapper.Map<Customer>(customerDTO);
            response.Data = await _unitOfWork.Customers.UpdateAsync(customer);
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

    public async Task<Response<bool>> DeleteAsync(int customerId)
    {
        var response = new Response<bool>();
        try
        {
            response.Data = await _unitOfWork.Customers.DeleteAsync(customerId);
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

    public async Task<Response<CustomerDTO>> GetAsync(int customerId)
    {
        var response = new Response<CustomerDTO>();
        try
        {
            var customer = await _unitOfWork.Customers.GetAsync(customerId);
            response.Data = _mapper.Map<CustomerDTO>(customer);
            response.IsSuccess = true;
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
        }
        return response;
    }

    public async Task<Response<IEnumerable<CustomerDTO>>> GetAllAsync()
    {
        var response = new Response<IEnumerable<CustomerDTO>>();
        try
        {
            var customers = await _unitOfWork.Customers.GetAllAsync();
            response.Data = _mapper.Map<IEnumerable<CustomerDTO>>(customers);
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

    public async Task<ResponsePagination<IEnumerable<CustomerDTO>>> GetAllAsync(int pageIndex, int pageSize)
    {
        var response = new ResponsePagination<IEnumerable<CustomerDTO>>();
        try
        {
            var count = await _unitOfWork.Customers.CountAsync();

            var customers = await _unitOfWork.Customers.GetAllAsync(pageIndex, pageSize);
            response.Data = _mapper.Map<IEnumerable<CustomerDTO>>(customers);

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
