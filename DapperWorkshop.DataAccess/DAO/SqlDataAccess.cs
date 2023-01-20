using DapperWorkshop.Data.Queries;

using SqlKata.Execution;

namespace DapperWorkshop.Data.DAO;

public class SqlDataAccess<EntityType, PKType> : ISqlDataAccess<EntityType, PKType>
{
    private readonly IDbQueryFactory _dbQueryFactory;

    public SqlDataAccess(IDbQueryFactory dbQueryFactory)
    {
        _dbQueryFactory = dbQueryFactory;
    }

    public async Task<IEnumerable<EntityType>> SelectAllAsync(string? tableName = nameof(EntityType))
    {
        QueryFactory queryFactory = await _dbQueryFactory.GetQueryFactoryAsync();
        IEnumerable<EntityType> results = await queryFactory
            .Query(tableName)
            .GetAsync<EntityType>();
        queryFactory.Dispose();

        return results;
    }

    public async Task<EntityType> SelectByPKAsync(PKType PKValue, string tableName = nameof(EntityType), string tablePKName = "Id")
    {
        QueryFactory queryFactory = await _dbQueryFactory.GetQueryFactoryAsync();
        IEnumerable<EntityType> results = await queryFactory
            .Query(tableName)
            .Where(tablePKName, "=", PKValue)
            .GetAsync<EntityType>();
        queryFactory.Dispose();

        return results.FirstOrDefault()!;
    }

    public async Task<PKType> InsertAsync(object insertObject, string tableName = nameof(EntityType))
    {
        QueryFactory queryFactory = await _dbQueryFactory.GetQueryFactoryAsync();
        PKType results = await queryFactory
            .Query(tableName)
            .InsertGetIdAsync<PKType>(insertObject);
        queryFactory.Dispose();

        return results;
    }

    public async Task<bool> UpdateAsync(PKType PKValue, object insertObject, string tableName = nameof(EntityType), string tablePKName = "Id")
    {
        QueryFactory queryFactory = await _dbQueryFactory.GetQueryFactoryAsync();
        int affectedRows = await queryFactory
            .Query(tableName)
            .Where(tablePKName, "=", PKValue)
            .UpdateAsync(insertObject);
        queryFactory.Dispose();

        return affectedRows > 0;
    }

    public async Task<bool> DeleteAsync(PKType PKValue, string tableName = nameof(EntityType), string tablePKName = "Id")
    {
        QueryFactory queryFactory = await _dbQueryFactory.GetQueryFactoryAsync();
        int affectedRows = await queryFactory
            .Query(tableName)
            .Where(tablePKName, "=", PKValue)
            .DeleteAsync();
        queryFactory.Dispose();

        return affectedRows > 0;
    }
}