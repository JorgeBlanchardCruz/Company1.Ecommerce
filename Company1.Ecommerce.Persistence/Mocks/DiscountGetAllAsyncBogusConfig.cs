using Bogus;
using Company1.Ecommerce.Domain.Entities;
using Company1.Ecommerce.Domain.Enums;

namespace Company1.Ecommerce.Persistence.Mocks;

internal class DiscountGetAllAsyncBogusConfig : Faker<Discount>
{
    public DiscountGetAllAsyncBogusConfig()
    {
        RuleFor(x => x.Id, f => f.IndexFaker + 1);
        RuleFor(x => x.Name, f => f.Commerce.ProductName());
        RuleFor(x => x.Description, f => f.Commerce.ProductDescription());
        RuleFor(x => x.Percentage, f => f.Random.Int(70, 90));
        RuleFor(x => x.Status, f => f.PickRandom<DiscountStatus>());
    }
}
