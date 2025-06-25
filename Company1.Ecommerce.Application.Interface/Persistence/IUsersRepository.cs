using Company1.Ecommerce.Domain.Entities;

namespace Company1.Ecommerce.Application.Interface.Persistence;

public interface IUsersRepository : IGenericRepository<User>
{
    Task<User> AuthenticateAsync(string email, string password);

}
