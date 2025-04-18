using Company1.Ecommerce.Application.DTO;
using Company1.Ecommerce.Transverse.Common;

namespace Company1.Ecommerce.Application.Interface.UseCases;

public interface ICategoriesApplication
{
    Task<Response<IEnumerable<CategoryDTO>>> GetAllAsync();
}
