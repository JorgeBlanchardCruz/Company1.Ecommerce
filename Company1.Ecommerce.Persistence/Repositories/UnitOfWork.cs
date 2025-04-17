using Company1.Ecommerce.Application.Interface.Persistence;
using Company1.Ecommerce.Persistence.Context;

namespace Company1.Ecommerce.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    public ICustomersRepository Customers { get; }
    public IUsersRepository Users { get; }
    public ICategoriesRepository Categories { get; }
    public IDiscountRepository Discounts { get; }

    public UnitOfWork(ApplicationDbContext context,
        ICustomersRepository customers, IUsersRepository users, ICategoriesRepository categories, IDiscountRepository discounts)
    {
        _context = context;

        Customers = customers;
        Users = users;
        Categories = categories;
        Discounts = discounts;
    }

    public async Task<int> SaveAsync(CancellationToken cancellationToken)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
