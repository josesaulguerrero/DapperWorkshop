using System.Data;

using Dapper;

using DapperWorkshop.Data.Connection;

namespace DapperWorkshop.Data.DAO;

public class SqlDataAccess : ISqlDataAccess
{
    private readonly IDbConnectionFactory _connectionFactory;

    public SqlDataAccess(IDbConnectionFactory connectionFactory)
    {
        this._connectionFactory = connectionFactory;
    }

    public async Task<IEnumerable<T>> SelectAsync<T, K>(
        string storedProcedure,
        K parameters,
        string connectionStringName = "Default")
    {
        IDbConnection dbConnection = await _connectionFactory.GetConnectionAsync(connectionStringName);

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
        IDbConnection dbConnection = await _connectionFactory.GetConnectionAsync(connectionStringName);

        await dbConnection.QueryAsync<T>(
            storedProcedure,
            parameters,
            commandType: CommandType.StoredProcedure
        );
        dbConnection.Dispose();
    }
}