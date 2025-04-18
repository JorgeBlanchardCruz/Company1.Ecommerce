﻿using Company1.Ecommerce.Application.DTO;
using Company1.Ecommerce.Application.Interface.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Company1.Ecommerce.Service.WebApi.Controllers.v1;

[Authorize]
[Route("api/v{version:apiVersion}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0", Deprecated = true)]
public class CustomersController : Controller
{
    private readonly ICustomersApplication _customerApplication;

    public CustomersController(ICustomersApplication customerApplication)
    {
        _customerApplication = customerApplication;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync(int customerId)
    {
        var response = await _customerApplication.GetAsync(customerId);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var response = await _customerApplication.GetAllAsync();
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> InsertAsync(CustomerDTO customer)
    {
        var response = await _customerApplication.InsertAsync(customer);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(CustomerDTO customer)
    {
        var response = await _customerApplication.UpdateAsync(customer);
        return Ok(response);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(int customerId)
    {
        var response = await _customerApplication.DeleteAsync(customerId);
        return Ok(response);
    }
}
