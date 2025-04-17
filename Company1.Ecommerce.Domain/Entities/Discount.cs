using Company1.Ecommerce.Domain.Common;
using Company1.Ecommerce.Domain.Enums;

namespace Company1.Ecommerce.Domain.Entities;

public class Discount : BaseAuditableEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Percentage { get; set; }
    public DiscountStatus Status { get; set; }
}
