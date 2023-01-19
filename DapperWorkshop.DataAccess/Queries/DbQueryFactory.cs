using DapperWorkshop.Data.Connection;

using SqlKata.Compilers;
using SqlKata.Execution;

namespace DapperWorkshop.Data.Queries;

public class DbQueryFactory : IDbQueryFactory
{
    private readonly IDbConnectionFactory _dbConnectionFactory;
    private readonly Compiler _compiler;

    public DbQueryFactory(IDbConnectionFactory dbConnectionFactory, Compiler compiler)
    {
        _dbConnectionFactory = dbConnectionFactory;
        _compiler = compiler;
    }

    public async Task<QueryFactory> GetQueryFactoryAsync()
    {
        return new(await _dbConnectionFactory.GetConnectionAsync(), _compiler);
    }
}