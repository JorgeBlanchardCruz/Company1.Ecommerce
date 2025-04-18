using Company1.Ecommerce.Domain.Enums;

namespace Company1.Ecommerce.Domain.Events;

public class DiscountCreatedEvent
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Percentage { get; set; }
    public DiscountStatus Status { get; set; }
}
