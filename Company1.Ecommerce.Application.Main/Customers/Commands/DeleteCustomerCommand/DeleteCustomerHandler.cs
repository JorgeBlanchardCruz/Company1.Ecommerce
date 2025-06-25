using Company1.Ecommerce.Application.Interface.Persistence;
using Company1.Ecommerce.Transverse.Common;
using MediatR;

namespace Company1.Ecommerce.Application.UseCases.Customers.Commands.DeleteCustomerCommand;

public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand, Response<bool>>
{
    private readonly IUnitOfWork _unitOfWork;
    public DeleteCustomerHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Response<bool>> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var response = new Response<bool>
        {
            Data = await _unitOfWork.Customers.DeleteAsync(request.CustomerId)
        };

        if (response.Data)
        {
            response.IsSuccess = true;
            response.Message = "Customer deleted successfully";
        }
        return response;
    }
}
