using Company1.Ecommerce.Domain.Entity;
using Company1.Ecommerce.Domain.Interface;
using Company1.Ecommerce.Infrastructure.Interface;

namespace Company1.Ecommerce.Domain.Core;

public class UsersDomain : IUsersDomain
{
    private readonly IUsersRepository _usersRepository;

    public UsersDomain(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public Users Authenticate(string email, string password)
    {
        return _usersRepository.Authenticate(email, password);
    }

}
