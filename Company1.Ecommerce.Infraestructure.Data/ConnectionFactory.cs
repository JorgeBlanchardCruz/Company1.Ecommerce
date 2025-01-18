using Company1.Ecommerce.Transverse.Common;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Company1.Ecommerce.Infraestructure.Data;

public class ConnectionFactory : IConnectionFactory
{

    private readonly IConfiguration _configuration;

    public ConnectionFactory(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IDbConnection? GetConnection 
    {
        get
        {
            var sqlConnection = new SqlConnection();
            if (sqlConnection is null)
                return null;

            sqlConnection.ConnectionString = _configuration.GetConnectionString("NorthwindConnection");
            sqlConnection.Open();

            return sqlConnection;
        }
    }
}
