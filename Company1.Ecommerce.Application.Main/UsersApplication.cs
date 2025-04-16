using AutoMapper;
using Company1.Ecommerce.Application.DTO;
using Company1.Ecommerce.Application.Interface.Persistence;
using Company1.Ecommerce.Application.Interface.UseCases;
using Company1.Ecommerce.Application.Validator;
using Company1.Ecommerce.Transverse.Common;

namespace Company1.Ecommerce.Application.UseCases;

public class UsersApplication : IUsersApplication
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly UsersDtoValidator _validationRules;

    public UsersApplication(IMapper mapper, UsersDtoValidator validationRules, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _validationRules = validationRules;

        _unitOfWork = unitOfWork;
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
            var user = _unitOfWork.Users.Authenticate(userName, password);
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
