using Company1.Ecommerce.Domain.Entity;

namespace Company1.Ecommerce.Application.Interface.Persistence;

public interface ICategoriesRepository
{
    Task<IEnumerable<Categories>> GetAllAsync();
}
