using Company1.Ecommerce.Domain.Entity;

namespace Company1.Ecommerce.Application.Interface.Persistence;

public interface IUsersRepository : IGenericRepository<Users>
{
    Users Authenticate(string email, string password);

}
