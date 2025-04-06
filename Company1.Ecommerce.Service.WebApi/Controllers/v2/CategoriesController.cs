using Company1.Ecommerce.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Company1.Ecommerce.Service.WebApi.Controllers.v2;

//[Authorize]
[Route("api/v{version:apiVersion}/[controller]/[action]")]
[ApiController]
[ApiVersion("2.0")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoriesApplication _categoriesApplication;

    public CategoriesController(ICategoriesApplication categoriesApplication)
    {
        _categoriesApplication = categoriesApplication;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var response = await _categoriesApplication.GetAllAsync();
        if (response.IsSuccess)
            return Ok(response);

        return BadRequest(response.Message);
    }
}
