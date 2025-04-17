using Company1.Ecommerce.Domain.Entities;

namespace Company1.Ecommerce.Application.Interface.Persistence;

public interface ICategoriesRepository
{
    Task<IEnumerable<Category>> GetAllAsync();
}
