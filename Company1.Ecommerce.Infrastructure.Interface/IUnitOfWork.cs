namespace Company1.Ecommerce.Infrastructure.Interface;

public interface IUnitOfWork : IDisposable
{
    ICustomersRepository Customers { get; }
    IUsersRepository Users { get; }

    ICategoriesRepository Categories { get; }
}
