using AutoMapper;
using Company1.Ecommerce.Application.DTO;
using Company1.Ecommerce.Application.Interface.Persistence;
using Company1.Ecommerce.Transverse.Common;
using MediatR;

namespace Company1.Ecommerce.Application.UseCases.Users.Commands.CreateUserTokenCommand;

public class CreateUserTokenHandler : IRequestHandler<CreateUserTokenCommand, Response<UserDTO>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateUserTokenHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Response<UserDTO>> Handle(CreateUserTokenCommand request, CancellationToken cancellationToken)
    {
        var response = new Response<UserDTO>();

        var user = await _unitOfWork.Users.AuthenticateAsync(request.UserName, request.Password);

        if (user is null)
        {
            response.Message = "Username or password is incorrect";
            response.IsSuccess = true;
            return response;
        }

        response.Data = _mapper.Map<UserDTO>(user);
        response.Message = "User authenticated successfully";
        response.IsSuccess = true;

        return response;
    }
}
