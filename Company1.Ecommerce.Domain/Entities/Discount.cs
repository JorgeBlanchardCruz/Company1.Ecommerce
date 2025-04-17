using Company1.Ecommerce.Domain.Common;
using Company1.Ecommerce.Domain.Enums;

namespace Company1.Ecommerce.Domain.Entities;

public class Discount : BaseAuditableEntity
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Percentage { get; private set; }
    public DiscountStatus Status { get; private set; }
}
