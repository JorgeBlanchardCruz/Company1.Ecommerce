using Company1.Ecommerce.Domain.Entity;
using Company1.Ecommerce.Domain.Interface;
using Company1.Ecommerce.Infrastructure.Interface;

namespace Company1.Ecommerce.Domain.Core;

public class CategoriesDomain : ICategoriesDomain
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoriesDomain(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }   

    public async Task<IEnumerable<Categories>> GetAllAsync()
    {
        return await _unitOfWork.Categories.GetAllAsync();
    }
}
