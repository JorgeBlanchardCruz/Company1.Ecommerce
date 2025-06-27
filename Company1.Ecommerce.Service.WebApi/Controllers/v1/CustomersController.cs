using Asp.Versioning;
using Company1.Ecommerce.Application.UseCases.Customers.Commands.CreateCustomerCommand;
using Company1.Ecommerce.Application.UseCases.Customers.Commands.DeleteCustomerCommand;
using Company1.Ecommerce.Application.UseCases.Customers.Commands.UpdateCustomerCommand;
using Company1.Ecommerce.Application.UseCases.Customers.Queries.GetAllCustomerQuery;
using Company1.Ecommerce.Application.UseCases.Customers.Queries.GetAllWithPaginationCustomerQuery;
using Company1.Ecommerce.Application.UseCases.Customers.Queries.GetCustomerQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Company1.Ecommerce.Service.WebApi.Controllers.v3;

//[Authorize]
[Route("api/v{version:apiVersion}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public class CustomersController : Controller
{
    private readonly IMediator _mediator;

    public CustomersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync(string customerId)
    {
        var response = await _mediator.Send(new GetCustomerQuery() { CustomerId = customerId });
        return Ok(response);
    }

    [HttpGet("Paginated")]
    public async Task<IActionResult> GetAllAsync(int pageIndex, int pageSize)
    {
        var response = await _mediator.Send(new GetAllWithPaginationCustomerQuery()
        {
            PageIndex = pageIndex,
            PageSize = pageSize
        });

        if (response.IsSuccess)
            return Ok(response);

        return BadRequest(response.Message);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var response = await _mediator.Send(new GetAllCustomerQuery());
        if (response.IsSuccess)
            return Ok(response);

        return BadRequest(response.Message);
    }

    [HttpPost]
    public async Task<IActionResult> InsertAsync(CreateCustomerCommand command)
    {
        if (command is null)
            return BadRequest();

        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut("{customerId}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] string customerId, UpdateCustomerCommand command)
    {
        var customerDto = await _mediator.Send(new GetCustomerQuery() { CustomerId = customerId });

        if (customerDto.Data is null)
            return NotFound(customerDto.Message);

        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(DeleteCustomerCommand command)
    {
        var response = await _mediator.Send(command);
        return Ok(response);
    }
}
