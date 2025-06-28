using Asp.Versioning;
using Company1.Ecommerce.Application.DTO;
using Company1.Ecommerce.Application.Interface.UseCases;
using Microsoft.AspNetCore.Http.Timeouts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace Company1.Ecommerce.Service.WebApi.Controllers.v1;

//[Authorize]
[EnableRateLimiting("fixedWindow")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1.0")]
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
    public async Task<IActionResult> UpdateAsync([FromRoute] string id, DiscountDTO request)
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
    public async Task<IActionResult> DeleteAsync(string id)
    {
        var response = await _discountsApplication.DeleteAsync(id);
        if (response.IsSuccess)
            return Ok(response);

        return BadRequest(response);
    }

    [HttpGet("{id}")]
    [RequestTimeout("CustomPolicy")]
    public async Task<IActionResult> GetAsync(string id)
    {
        //para que funcione el patron TimeOut, debes ejecutar la applicación SIN depuración (Botón de Play sin relleno)
        var response = await _discountsApplication.GetAsync(id, HttpContext.RequestAborted);
        if (response.IsSuccess)
            return Ok(response);

        return BadRequest(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        //para que funcione el patron TimeOut, debes ejecutar la applicación SIN depuración (Botón de Play sin relleno)
        var response = await _discountsApplication.GetAllAsync(HttpContext.RequestAborted);
        if (response.IsSuccess)
            return Ok(response);

        return BadRequest(response.Message);
    }

    [HttpGet("Paginated")]
    public async Task<IActionResult> GetAllAsync(int pageIndex, int pageSize)
    {
        var response = await _discountsApplication.GetAllAsync(pageIndex, pageSize);
        if (response.IsSuccess)
            return Ok(response);

        return BadRequest(response.Message);
    }

}