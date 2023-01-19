using System.Data;
using System.Data.SqlClient;

using Dapper;

using Microsoft.Extensions.Configuration;

namespace DapperWorkshop.DataAccess.DBAccess;

public class SqlDataAccess : ISqlDataAccess
{
    private readonly IConfiguration _configuration;

    public SqlDataAccess(IConfiguration configuration)
    {
        this._configuration = configuration;
    }

    public async Task<IEnumerable<T>> SelectAsync<T, K>(
        string storedProcedure,
        K parameters,
        string connectionStringName = "Default")
    {
        IDbConnection dbConnection = OpenDbConnection(connectionStringName);

        IEnumerable<T> results = await dbConnection.QueryAsync<T>(
            storedProcedure,
            parameters,
            commandType: CommandType.StoredProcedure
        );
        dbConnection.Dispose();
        return results;
    }

    public async Task SaveAsync<T>(
        string storedProcedure,
        T parameters,
        string connectionStringName = "Default")
    {
        IDbConnection dbConnection = OpenDbConnection(connectionStringName);

        await dbConnection.QueryAsync<T>(
            storedProcedure,
            parameters,
            commandType: CommandType.StoredProcedure
        );
        dbConnection.Dispose();
    }

    private IDbConnection OpenDbConnection(string connectionStringName)
    {
        return new SqlConnection(_configuration.GetConnectionString(connectionStringName));
    }
}