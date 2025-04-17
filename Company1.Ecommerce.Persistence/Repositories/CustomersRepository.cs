using Company1.Ecommerce.Application.Interface.Persistence;
using Company1.Ecommerce.Domain.Entities;
using Company1.Ecommerce.Persistence.Context;
using Dapper;
using System.Data;

namespace Company1.Ecommerce.Persistence.Repositories;

public class CustomersRepository : ICustomersRepository
{
    private readonly DapperContext _context;

    public CustomersRepository(DapperContext context)
    {
        _context = context;
    }

    #region Sinchronous Methods
    public bool Insert(Customer customer)
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

    public bool Update(Customer customer)
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

    public Customer Get(string customerId)
    {
        using var connection = _context.CreateConnection();

        var query = "CustomersGetByID";

        var parameters = new DynamicParameters();

        parameters.Add("@CustomerId", customerId);

        var result = connection!.QuerySingle<Customer>(query, parameters, commandType: CommandType.StoredProcedure);

        return result;
    }

    public IEnumerable<Customer> GetAll()
    {
        using var connection = _context.CreateConnection();

        var query = "CustomersList";

        var result = connection!.Query<Customer>(query, commandType: CommandType.StoredProcedure);

        return result;
    }

    #endregion

    #region Asynchronous Methods
    public async Task<bool> InsertAsync(Customer customer)
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

    public async Task<bool> UpdateAsync(Customer customer)
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

    public async Task<Customer> GetAsync(string customerId)
    {
        using var connection = _context.CreateConnection();

        var query = "CustomersGetByID";

        var parameters = new DynamicParameters();

        parameters.Add("@CustomerId", customerId);

        var result = await connection!.QuerySingleAsync<Customer>(query, parameters, commandType: CommandType.StoredProcedure);

        return result;
    }

    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        using var connection = _context.CreateConnection();

        var query = "CustomersList";

        var result = await connection!.QueryAsync<Customer>(query, commandType: CommandType.StoredProcedure);

        return result;
    }

    public async Task<IEnumerable<Customer>> GetAllAsync(int page, int recordsPerPage)
    {
        using var connection = _context.CreateConnection();

        var query = "CustomersListWithPagination";

        var parameters = new DynamicParameters();
        parameters.Add("@PageNumber", page);
        parameters.Add("@PageSize", recordsPerPage);

        var result = await connection!.QueryAsync<Customer>(query, param: parameters, commandType: CommandType.StoredProcedure);

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
