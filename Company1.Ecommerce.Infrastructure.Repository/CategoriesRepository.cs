using Company1.Ecommerce.Domain.Entity;
using Company1.Ecommerce.Infrastructure.Data;
using Company1.Ecommerce.Infrastructure.Interface;
using Dapper;
using System.Data;

namespace Company1.Ecommerce.Infrastructure.Repository;

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
