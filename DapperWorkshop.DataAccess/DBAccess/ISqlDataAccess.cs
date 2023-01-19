namespace DapperWorkshop.DataAccess.DBAccess
{
    public interface ISqlDataAccess
    {
        Task InsertAsync<T>(string storedProcedure, T parameters, string connectionStringName = "Default");
        Task<IEnumerable<T>> SelectAllAsync<T, K>(string storedProcedure, K parameters, string connectionStringName = "Default");
    }
}