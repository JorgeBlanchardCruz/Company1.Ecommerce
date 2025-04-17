using Company1.Ecommerce.Application.Interface.Persistence;
using Company1.Ecommerce.Domain.Entities;
using Company1.Ecommerce.Persistence.Context;
using Dapper;
using System.Data;

namespace Company1.Ecommerce.Persistence.Repositories;

public class UsersRepository : IUsersRepository
{
    private readonly DapperContext _context;

    public UsersRepository(DapperContext context)
    {
        _context = context;
    }

    public User Authenticate(string userName, string password)
    {
        using var connection = _context.CreateConnection();
        var query = "UsersGetByUserAndPassword";
        var parameters = new DynamicParameters();
        parameters.Add("@UserName", userName);
        parameters.Add("@Password", password);

        var user = connection!.QuerySingle<User>(query, parameters, commandType: CommandType.StoredProcedure);

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

    public Customer Get(string id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Customer> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetAllAsync(int page, int recordsPerPage)
    {
        throw new NotImplementedException();
    }

    public Task<Customer> GetAsync(string id)
    {
        throw new NotImplementedException();
    }

    public bool Insert(User entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> InsertAsync(User entity)
    {
        throw new NotImplementedException();
    }

    public bool Update(User entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(User entity)
    {
        throw new NotImplementedException();
    }
}
