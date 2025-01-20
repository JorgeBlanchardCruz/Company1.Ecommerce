using Company1.Ecommerce.Domain.Entity;
using Company1.Ecommerce.Domain.Interface;
using Company1.Ecommerce.Infrastructure.Interface;

namespace Company1.Ecommerce.Domain.Core;

public class UsersDomain : IUsersDomain
{
    private readonly IUnitOfWork _unitOfWork;

    public UsersDomain(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Users Authenticate(string email, string password)
    {
        return _unitOfWork.Users.Authenticate(email, password);
    }

}
