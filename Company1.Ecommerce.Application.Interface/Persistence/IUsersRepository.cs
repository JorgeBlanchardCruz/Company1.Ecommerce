using Company1.Ecommerce.Domain.Entity;

namespace Company1.Ecommerce.Application.Interface.Persistence;

public interface IUsersRepository : IGenericRepository<User>
{
    User Authenticate(string email, string password);

}
