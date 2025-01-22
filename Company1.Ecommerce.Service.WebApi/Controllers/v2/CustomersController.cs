using Company1.Ecommerce.Application.DTO;
using Company1.Ecommerce.Application.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Company1.Ecommerce.Service.WebApi.Controllers.v2;

//[Authorize]
[Route("api/v{version:apiVersion}/[controller]/[action]")]
[ApiController]
[ApiVersion("2.0")]
public class CustomersController : Controller
{
    private readonly ICustomersApplication _customerApplication;

    public CustomersController(ICustomersApplication customerApplication)
    {
        _customerApplication = customerApplication;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync(string customerId)
    {
        var response = await _customerApplication.GetAsync(customerId);
        return Ok(response);
    }

    [HttpGet("Paginated")]
    public async Task<IActionResult> GetAllAsync(int pageIndex, int pageSize)
    {
        var response = await _customerApplication.GetAllAsync(pageIndex, pageSize);
        if (response.IsSuccess)
            return Ok(response);

        return BadRequest(response.Message);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var response = await _customerApplication.GetAllAsync();
        if (response.IsSuccess)
            return Ok(response);

        return BadRequest(response.Message);
    }

    [HttpPost]
    public async Task<IActionResult> InsertAsync(CustomersDTO customer)
    {
        var response = await _customerApplication.InsertAsync(customer);
        return Ok(response);
    }

    [HttpPut("{customerId}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] string customerId, CustomersDTO customer)
    {
        var customerDto = await _customerApplication.GetAsync(customerId);

        if (customerDto.Data is null)
            return NotFound(customerDto.Message);

        var response = await _customerApplication.UpdateAsync(customer);
        return Ok(response);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(string customerId)
    {
        var response = await _customerApplication.DeleteAsync(customerId);
        return Ok(response);
    }
}
