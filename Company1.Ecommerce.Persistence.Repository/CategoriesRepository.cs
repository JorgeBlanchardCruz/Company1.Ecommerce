using Company1.Ecommerce.Application.Interface.Persistence;
using Company1.Ecommerce.Domain.Entity;
using Company1.Ecommerce.Persistence.Data;
using Dapper;
using System.Data;

namespace Company1.Ecommerce.Persistence.Repository;

public class CategoriesRepository : ICategoriesRepository
{
    private readonly DapperContext _context;

    public CategoriesRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Categories>> GetAllAsync()
    {
        using var connection = _context.CreateConnection();
        var query = "SELECT * FROM Categories";

        var categories = await connection.QueryAsync<Categories>(query, commandType: CommandType.Text);
        return categories;
    }
}
