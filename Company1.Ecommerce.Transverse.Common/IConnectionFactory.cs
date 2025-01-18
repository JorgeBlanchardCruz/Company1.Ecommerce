using System.Data;

namespace Company1.Ecommerce.Transverse.Common;

public interface IConnectionFactory
{
    IDbConnection? GetConnection { get; }
}
