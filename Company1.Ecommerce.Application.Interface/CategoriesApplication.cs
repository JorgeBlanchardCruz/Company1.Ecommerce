using Company1.Ecommerce.Application.DTO;
using Company1.Ecommerce.Transverse.Common;

namespace Company1.Ecommerce.Application.Interface;

public interface ICategoriesApplication
{
    Task<Response<IEnumerable<CategoriesDTO>>> GetAllAsync();
}
