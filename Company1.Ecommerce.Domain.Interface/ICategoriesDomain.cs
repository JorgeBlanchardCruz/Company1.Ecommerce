using Company1.Ecommerce.Domain.Entity;

namespace Company1.Ecommerce.Domain.Interface;

public interface ICategoriesDomain
{
    Task<IEnumerable<Categories>> GetAllAsync();
}
