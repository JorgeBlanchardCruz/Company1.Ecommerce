using Company1.Ecommerce.Domain.Entity;
using Company1.Ecommerce.Infrastructure.Data;
using Company1.Ecommerce.Infrastructure.Interface;
using Dapper;
using System.Data;

namespace Company1.Ecommerce.Infrastructure.Repository;

public class CustomersRepository : ICustomersRepository
{
    private readonly DapperContext _context;

    public CustomersRepository(DapperContext context)
    {
        _context = context;
    }

    #region Sinchronous Methods
    public bool Insert(Customers customer)
    {
        using var connection = _context.CreateConnection();

        var query = "CustomersInsert";

        var parameters = new DynamicParameters();
        parameters.Add("@CompanyName", customer.CompanyName);
        parameters.Add("@ContactName", customer.ContactName);
        parameters.Add("@ContactTitle", customer.ContactTitle);
        parameters.Add("@Address", customer.Address);
        parameters.Add("@City", customer.City);
        parameters.Add("@Region", customer.Region);
        parameters.Add("@PostalCode", customer.PostalCode);
        parameters.Add("@Country", customer.Country);
        parameters.Add("@Phone", customer.Phone);
        parameters.Add("@Fax", customer.Fax);

        var result = connection!.Execute(query, parameters, commandType: CommandType.StoredProcedure);

        return result > 0;
    }

    public bool Update(Customers customer)
    {
        using var connection = _context.CreateConnection();

        var query = "CustomersUpdate";

        var parameters = new DynamicParameters();

        parameters.Add("@CustomerId", customer.CustomerId);
        parameters.Add("@CompanyName", customer.CompanyName);
        parameters.Add("@ContactName", customer.ContactName);
        parameters.Add("@ContactTitle", customer.ContactTitle);
        parameters.Add("@Address", customer.Address);
        parameters.Add("@City", customer.City);
        parameters.Add("@Region", customer.Region);
        parameters.Add("@PostalCode", customer.PostalCode);
        parameters.Add("@Country", customer.Country);
        parameters.Add("@Phone", customer.Phone);
        parameters.Add("@Fax", customer.Fax);

        var result = connection!.Execute(query, parameters, commandType: CommandType.StoredProcedure);

        return result > 0;
    }

    public bool Delete(string customerId)
    {
        using var connection = _context.CreateConnection();

        var query = "CustomersDelete";

        var parameters = new DynamicParameters();

        parameters.Add("@CustomerId", customerId);

        var result = connection!.Execute(query, parameters, commandType: CommandType.StoredProcedure);

        return result > 0;
    }

    public Customers Get(string customerId)
    {
        using var connection = _context.CreateConnection();

        var query = "CustomersGetByID";

        var parameters = new DynamicParameters();

        parameters.Add("@CustomerId", customerId);

        var result = connection!.QuerySingle<Customers>(query, parameters, commandType: CommandType.StoredProcedure);

        return result;
    }

    public IEnumerable<Customers> GetAll()
    {
        using var connection = _context.CreateConnection();

        var query = "CustomersList";

        var result = connection!.Query<Customers>(query, commandType: CommandType.StoredProcedure);

        return result;
    }

    #endregion

    #region Asynchronous Methods
    public async Task<bool> InsertAsync(Customers customer)
    {
        using var connection = _context.CreateConnection();

        var query = "CustomersInsert";

        var parameters = new DynamicParameters();
        parameters.Add("@CompanyName", customer.CompanyName);
        parameters.Add("@ContactName", customer.ContactName);
        parameters.Add("@ContactTitle", customer.ContactTitle);
        parameters.Add("@Address", customer.Address);
        parameters.Add("@City", customer.City);
        parameters.Add("@Region", customer.Region);
        parameters.Add("@PostalCode", customer.PostalCode);
        parameters.Add("@Country", customer.Country);
        parameters.Add("@Phone", customer.Phone);
        parameters.Add("@Fax", customer.Fax);

        var result = await connection!.ExecuteAsync(query, parameters, commandType: CommandType.StoredProcedure);

        return result > 0;
    }

    public async Task<bool> UpdateAsync(Customers customer)
    {
        using var connection = _context.CreateConnection();

        var query = "CustomersUpdate";

        var parameters = new DynamicParameters();

        parameters.Add("@CustomerId", customer.CustomerId);
        parameters.Add("@CompanyName", customer.CompanyName);
        parameters.Add("@ContactName", customer.ContactName);
        parameters.Add("@ContactTitle", customer.ContactTitle);
        parameters.Add("@Address", customer.Address);
        parameters.Add("@City", customer.City);
        parameters.Add("@Region", customer.Region);
        parameters.Add("@PostalCode", customer.PostalCode);
        parameters.Add("@Country", customer.Country);
        parameters.Add("@Phone", customer.Phone);
        parameters.Add("@Fax", customer.Fax);

        var result = await connection!.ExecuteAsync(query, parameters, commandType: CommandType.StoredProcedure);

        return result > 0;
    }

    public async Task<bool> DeleteAsync(string customerId)
    {
        using var connection = _context.CreateConnection();

        var query = "CustomersDelete";

        var parameters = new DynamicParameters();

        parameters.Add("@CustomerId", customerId);

        var result = await connection!.ExecuteAsync(query, parameters, commandType: CommandType.StoredProcedure);

        return result > 0;
    }

    public async Task<Customers> GetAsync(string customerId)
    {
        using var connection = _context.CreateConnection();

        var query = "CustomersGetByID";

        var parameters = new DynamicParameters();

        parameters.Add("@CustomerId", customerId);

        var result = await connection!.QuerySingleAsync<Customers>(query, parameters, commandType: CommandType.StoredProcedure);

        return result;
    }

    public async Task<IEnumerable<Customers>> GetAllAsync()
    {
        using var connection = _context.CreateConnection();

        var query = "CustomersList";

        var result = await connection!.QueryAsync<Customers>(query, commandType: CommandType.StoredProcedure);

        return result;
    }

    public async Task<IEnumerable<Customers>> GetAllAsync(int page, int recordsPerPage)
    {
        using var connection = _context.CreateConnection();

        var query = "CustomersListWithPagination";

        var parameters = new DynamicParameters();
        parameters.Add("@PageNumber", page);
        parameters.Add("@PageSize", recordsPerPage);

        var result = await connection!.QueryAsync<Customers>(query, param: parameters, commandType: CommandType.StoredProcedure);

        return result;
    }

    public async Task<int> CountAsync()
    {
        using var connection = _context.CreateConnection();
        var query = "SELECT COUNT(1) FROM Customers";

        var result = await connection!.ExecuteScalarAsync<int>(query,commandType: CommandType.Text);
        return result;
    }

    #endregion
}
