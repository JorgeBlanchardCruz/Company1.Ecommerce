namespace Company1.Ecommerce.Application.Interface.Persistence;

public interface IUnitOfWork : IDisposable
{
    ICustomersRepository Customers { get; }
    IUsersRepository Users { get; }

    ICategoriesRepository Categories { get; }
}
