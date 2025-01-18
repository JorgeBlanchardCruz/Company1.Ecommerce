using AutoMapper;
using Company1.Ecommerce.Application.DTO;
using Company1.Ecommerce.Application.Interface;
using Company1.Ecommerce.Application.Validator;
using Company1.Ecommerce.Domain.Interface;
using Company1.Ecommerce.Transverse.Common;

namespace Company1.Ecommerce.Application.Main;

public class UsersApplication : IUsersApplication
{
    private readonly IUsersDomain _usersDomain;
    private readonly IMapper _mapper;
    private readonly UsersDtoValidator _validationRules;

    public UsersApplication(IUsersDomain usersDomain, IMapper mapper, UsersDtoValidator validationRules)
    {
        _usersDomain = usersDomain;
        _mapper = mapper;
        _validationRules = validationRules;
    }

    public Response<UsersDTO> Authenticate(string userName, string password)
    {
        var response = new Response<UsersDTO>();
        var validationResult = _validationRules.Validate(new UsersDTO { UserName = userName, Password = password });

        if (!validationResult.IsValid)
        {
            response.Message = "Username or password is incorrect";
            response.Errors = validationResult.Errors;
            return response;
        }

        try
        {
            var user = _usersDomain.Authenticate(userName, password);
            response.Data = _mapper.Map<UsersDTO>(user);
            response.Message = "User authenticated successfully";
            response.IsSuccess = true;
        }
        catch (InvalidOperationException)
        {
            response.IsSuccess = true;
            response.Message = "User not found";
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
        }

        return response;
    }
}
