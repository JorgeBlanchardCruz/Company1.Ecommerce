using Company1.Ecommerce.Application.DTO.Enums;

namespace Company1.Ecommerce.Application.DTO;

public sealed record DiscountDTO
{
    public string Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public decimal Percentage { get; init; }
    public DiscountStatusDTO Status { get; init; }
}
