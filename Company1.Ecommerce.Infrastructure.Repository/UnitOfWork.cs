using Company1.Ecommerce.Infrastructure.Interface;

namespace Company1.Ecommerce.Infrastructure.Repository;

public class UnitOfWork : IUnitOfWork
{
    public ICustomersRepository Customers { get; }
    public IUsersRepository Users { get; }

    public UnitOfWork(ICustomersRepository customers, IUsersRepository users)
    {
        Customers = customers;
        Users = users;
    }

    public void Dispose()
    {
        System.GC.SuppressFinalize(this);
    }
}
