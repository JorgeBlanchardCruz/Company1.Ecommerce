//Incluso el namespace debe ser igual que el del Publisher
namespace Company1.Ecommerce.Domain.Events;

public class DiscountCreatedEvent
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Percentage { get; set; }
    public DiscountStatus Status { get; set; }
}
