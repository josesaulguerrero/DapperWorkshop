using System.Data;

namespace DapperWorkshop.Data.Connection;

public interface IDbConnectionFactory
{
    Task<IDbConnection> GetConnectionAsync(string? connectionStringName = "Default");
}