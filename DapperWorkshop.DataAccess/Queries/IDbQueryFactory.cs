using SqlKata.Execution;

namespace DapperWorkshop.Data.Queries
{
    public interface IDbQueryFactory
    {
        Task<QueryFactory> GetQueryFactoryAsync();
    }
}