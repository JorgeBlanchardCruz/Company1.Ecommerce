using Company1.Ecommerce.Domain.Entity;

namespace Company1.Ecommerce.Infrastructure.Interface;

public interface IUsersRepository
{
    Users Authenticate(string email, string password);

}
