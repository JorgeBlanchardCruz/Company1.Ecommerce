using Company1.Ecommerce.Application.DTO;
using Company1.Ecommerce.Application.Interface.UseCases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace Company1.Ecommerce.Service.WebApi.Controllers.v2;

//[Authorize]
[EnableRateLimiting("fixedWindow")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("2.0")]
public class DiscountsController : Controller
{
    private readonly IDiscountsApplication _discountsApplication;

    public DiscountsController(IDiscountsApplication discountsApplication)
    {
        _discountsApplication = discountsApplication;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(DiscountDTO request)
    {
        if (request is null)
            return BadRequest();

        var response = await _discountsApplication.CreateAsync(request);
        if (response.IsSuccess)
            return Ok(response);

        return BadRequest(response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] int id, DiscountDTO request)
    {
        //Esto no debería ser así, tendría que estar en la capa de aplicación
        var discountDtoExists = await _discountsApplication.GetAsync(id);

        if (discountDtoExists.Data is null)
            return NotFound(discountDtoExists.Message);

        if (request is null)
            return BadRequest();

        var response = await _discountsApplication.UpdateAsync(request);
        if (response.IsSuccess)
            return Ok(response);

        return BadRequest(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var response = await _discountsApplication.DeleteAsync(id);
        if (response.IsSuccess)
            return Ok(response);

        return BadRequest(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(int id)
    {
        var response = await _discountsApplication.GetAsync(id);
        if (response.IsSuccess)
            return Ok(response);

        return BadRequest(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var response = await _discountsApplication.GetAllAsync();
        if (response.IsSuccess)
            return Ok(response);

        return BadRequest(response.Message);
    }


}
