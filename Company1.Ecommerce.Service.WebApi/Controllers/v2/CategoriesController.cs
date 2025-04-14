using Company1.Ecommerce.Application.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace Company1.Ecommerce.Service.WebApi.Controllers.v2;

//[Authorize]
[EnableRateLimiting("fixedWindow")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("2.0")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoriesApplication _categoriesApplication;

    public CategoriesController(ICategoriesApplication categoriesApplication)
    {
        _categoriesApplication = categoriesApplication;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAllAsync()
    {
        var response = await _categoriesApplication.GetAllAsync();
        if (response.IsSuccess)
            return Ok(response);

        return BadRequest(response.Message);
    }
}
