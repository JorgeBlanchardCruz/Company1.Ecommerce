using AutoMapper;
using Company1.Ecommerce.Application.DTO;
using Company1.Ecommerce.Application.Interface.Persistence;
using Company1.Ecommerce.Application.Interface.UseCases;
using Company1.Ecommerce.Application.Validator;
using Company1.Ecommerce.Transverse.Common;

namespace Company1.Ecommerce.Application.UseCases.Users;

public class UsersApplication : IUsersApplication
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly UserDtoValidator _validationRules;

    public UsersApplication(IMapper mapper, UserDtoValidator validationRules, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _validationRules = validationRules;

        _unitOfWork = unitOfWork;
    }

    public Response<UserDTO> Authenticate(string userName, string password)
    {
        var response = new Response<UserDTO>();
        var validationResult = _validationRules.Validate(new UserDTO { UserName = userName, Password = password });

        if (!validationResult.IsValid)
        {
            response.Message = "Username or password is incorrect";
            response.Errors = validationResult.Errors;
            return response;
        }

        try
        {
            var user = _unitOfWork.Users.AuthenticateAsync(userName, password).GetAwaiter();
            response.Data = _mapper.Map<UserDTO>(user);
            response.Message = "User authenticated successfully";
            response.IsSuccess = true;
        }
        catch (InvalidOperationException)
        {
            response.IsSuccess = true;
            response.Message = "User not found";
        }

        return response;
    }
}
