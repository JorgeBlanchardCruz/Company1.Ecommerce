using Company1.Ecommerce.Application.Interface.Persistence;
using Company1.Ecommerce.Domain.Entities;
using Company1.Ecommerce.Persistence.Context;
using Dapper;
using System.Data;

namespace Company1.Ecommerce.Persistence.Repositories;

public class CategoriesRepository : ICategoriesRepository
{
    private readonly DapperContext _context;

    public CategoriesRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        using var connection = _context.CreateConnection();
        var query = "SELECT * FROM Categories";

        var categories = await connection.QueryAsync<Category>(query, commandType: CommandType.Text);
        return categories;
    }
}
