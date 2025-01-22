using Company1.Ecommerce.Domain.Entity;
using Company1.Ecommerce.Infrastructure.Data;
using Company1.Ecommerce.Infrastructure.Interface;
using Dapper;
using System.Data;

namespace Company1.Ecommerce.Infrastructure.Repository;

public class UsersRepository : IUsersRepository
{
    private readonly DapperContext _context;

    public UsersRepository(DapperContext context)
    {
        _context = context;
    }

    public Users Authenticate(string userName, string password)
    {
        using var connection = _context.CreateConnection();
        var query = "UsersGetByUserAndPassword";
        var parameters = new DynamicParameters();
        parameters.Add("@UserName", userName);
        parameters.Add("@Password", password);

        var user = connection!.QuerySingle<Users>(query, parameters, commandType: CommandType.StoredProcedure);

        return user;
    }

    public Task<int> CountAsync()
    {
        throw new NotImplementedException();
    }

    public bool Delete(string entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Customers Get(string id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Customers> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Users>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Users>> GetAllAsync(int page, int recordsPerPage)
    {
        throw new NotImplementedException();
    }

    public Task<Customers> GetAsync(string id)
    {
        throw new NotImplementedException();
    }

    public bool Insert(Users entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> InsertAsync(Users entity)
    {
        throw new NotImplementedException();
    }

    public bool Update(Users entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(Users entity)
    {
        throw new NotImplementedException();
    }
}
