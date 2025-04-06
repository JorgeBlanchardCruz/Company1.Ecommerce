using Company1.Ecommerce.Domain.Entity;

namespace Company1.Ecommerce.Infrastructure.Interface;

public interface ICategoriesRepository
{
    Task<IEnumerable<Categories>> GetAllAsync();
}
