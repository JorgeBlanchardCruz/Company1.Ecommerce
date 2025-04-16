using Company1.Ecommerce.Application.Interface.Persistence;

namespace Company1.Ecommerce.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    public ICustomersRepository Customers { get; }
    public IUsersRepository Users { get; }
    public ICategoriesRepository Categories { get; }

    public UnitOfWork(ICustomersRepository customers, IUsersRepository users, ICategoriesRepository categories)
    {
        Customers = customers;
        Users = users;
        Categories = categories;
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
