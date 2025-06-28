namespace Company1.Ecommerce.Application.Interface.Presentation;

public interface ICurrentUser
{
    string? UserId { get; }
    string? UserName { get; }
}
