using AutoMapper;
using Company1.Ecommerce.Application.DTO;
using Company1.Ecommerce.Application.Interface;
using Company1.Ecommerce.Domain.Interface;
using Company1.Ecommerce.Transverse.Common;

namespace Company1.Ecommerce.Application.Main;

public class CategoriesApplication : ICategoriesApplication
{
    private readonly ICategoriesDomain _categoriesDomain;
    private readonly IMapper _mapper;

    public CategoriesApplication(ICategoriesDomain categoriesDomain, IMapper mapper)
    {
        _categoriesDomain = categoriesDomain;
        _mapper = mapper;
    }

    public async Task<Response<IEnumerable<CategoriesDTO>>> GetAllAsync()
    {
        var response = new Response<IEnumerable<CategoriesDTO>>();
        try
        {
            var categories = await _categoriesDomain.GetAllAsync();
            response.Data = _mapper.Map<IEnumerable<CategoriesDTO>>(categories);
            if (response.Data is not null)
            {
                response.IsSuccess = true;
                response.Message = "Categories retrieved successfully.";
            }
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Message = ex.Message;
        }

        return response;
    }
}
