using Company1.Ecommerce.Application.Interface.Persistence;
using Company1.Ecommerce.Domain.Entities;
using Company1.Ecommerce.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Company1.Ecommerce.Persistence.Repositories;

public class DiscountRepository : IDiscountRepository
{
    protected readonly ApplicationDbContext _context;

    public DiscountRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    #region Async
    public async Task<Discount> GetAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.Set<Discount>()
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);
    }

    public async Task<IEnumerable<Discount>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Set<Discount>()
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<bool> InsertAsync(Discount entity)
    {
        _context.Discounts.Add(entity);
        return await Task.FromResult(true);
    }

    public async Task<bool> UpdateAsync(Discount discount)
    {
        var entity = await _context.Set<Discount>()
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.Id.Equals(discount.Id));

        if (entity is null)
            return await Task.FromResult(false);

        entity.Name = discount.Name;
        entity.Description = discount.Description;
        entity.Percentage = discount.Percentage;
        entity.Status = discount.Status;

        _context.Update(entity);
        return await Task.FromResult(true);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.Set<Discount>()
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.Id.Equals(id));

        if (entity is null)
            return await Task.FromResult(false);

        _context.Remove(entity);
        return await Task.FromResult(true);
    }

    public async Task<Customer> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Discount>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Discount>> GetAllAsync(int page, int recordsPerPage)
    {
        throw new NotImplementedException();
    }

    public async Task<int> CountAsync()
    {
        throw new NotImplementedException();
    }

    #endregion

    #region Sync
    public bool Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Customer Get(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Customer> GetAll()
    {
        throw new NotImplementedException();
    }

    public bool Insert(Discount entity)
    {
        throw new NotImplementedException();
    }

    public bool Update(Discount entity)
    {
        throw new NotImplementedException();
    }
    #endregion

}
