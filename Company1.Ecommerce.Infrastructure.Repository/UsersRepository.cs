using Company1.Ecommerce.Domain.Entity;
using Company1.Ecommerce.Infrastructure.Interface;
using Company1.Ecommerce.Transverse.Common;
using Dapper;
using System.Data;

namespace Company1.Ecommerce.Infrastructure.Repository;

public class UsersRepository : IUsersRepository
{
    private readonly IConnectionFactory _connection;

    public UsersRepository(IConnectionFactory connection)
    {
        _connection = connection;
    }

    public Users Authenticate(string userName, string password)
    {
        using var connection = _connection.GetConnection;
        var query = "UsersGetByUserAndPassword";
        var parameters = new DynamicParameters();
        parameters.Add("@UserName", userName);
        parameters.Add("@Password", password);

        var user = connection!.QuerySingle<Users>(query, parameters, commandType: CommandType.StoredProcedure);

        return user;
    }
}
