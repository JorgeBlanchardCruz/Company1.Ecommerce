using Company1.Ecommerce.Application.DTO;
using Company1.Ecommerce.Transverse.Common;
namespace Company1.Ecommerce.Application.Interface.UseCases;

public interface IDiscountsApplication
{
    Task<Response<bool>> CreateAsync(DiscountDTO discount, CancellationToken cancellationToken = default);
    Task<Response<bool>> UpdateAsync(DiscountDTO discount, CancellationToken cancellationToken = default);
    Task<Response<bool>> DeleteAsync(int id, CancellationToken cancellationToken = default);
    Task<Response<DiscountDTO>> GetAsync(int id, CancellationToken cancellationToken = default);
    Task<Response<IEnumerable<DiscountDTO>>> GetAllAsync(CancellationToken cancellationToken = default);
}
