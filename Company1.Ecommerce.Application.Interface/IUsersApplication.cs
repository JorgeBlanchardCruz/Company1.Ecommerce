using Company1.Ecommerce.Application.DTO;
using Company1.Ecommerce.Transverse.Common;

namespace Company1.Ecommerce.Application.Interface;

public interface IUsersApplication
{
    Response<UsersDTO> Authenticate(string userName, string password);
}
