using Company1.Ecommerce.Application.DTO;
using Company1.Ecommerce.Transverse.Common;

namespace Company1.Ecommerce.Application.Interface.UseCases;

public interface IUsersApplication
{
    Response<UserDTO> Authenticate(string userName, string password);
}
