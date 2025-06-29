using Company1.Ecommerce.Domain.Common;
using Company1.Ecommerce.Domain.Entities;

namespace Company1.Ecommerce.Domain.Specifications;

public class CountryinBlackListSpecification : ISpecification<Customer>
{
    private readonly List<string> _blacklistedCountries = [
        "Argentina",
        "Brazil",
        "Chile",
        "Colombia",
        "Ecuador",
        "Mexico",
        "España",
        "Portugal",
        "Estados Unidos",
        "Canadá",
        "Uruguay",
        "Alemania",
    ];

    public bool IsSatisfiedBy(Customer entity)
    {
        return !_blacklistedCountries.Contains(entity.Country, StringComparer.OrdinalIgnoreCase);
    }
}
