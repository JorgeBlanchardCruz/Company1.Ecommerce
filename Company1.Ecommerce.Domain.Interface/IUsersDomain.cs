using Company1.Ecommerce.Domain.Entity;

namespace Company1.Ecommerce.Domain.Interface;

public interface IUsersDomain
{
    Users Authenticate(string username, string password);
}
