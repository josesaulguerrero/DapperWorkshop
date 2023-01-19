using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

using Microsoft.Extensions.Configuration;

namespace DapperWorkshop.Data.Connection;

public class DbConnectionFactory : IDbConnectionFactory
{
    private readonly IConfiguration _configuration;

    public DbConnectionFactory(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<IDbConnection> GetConnectionAsync(string connectionStringName)
    {
        DbConnection connection = new SqlConnection(_configuration.GetConnectionString(connectionStringName));
        await connection.OpenAsync();
        return connection;
    }
}