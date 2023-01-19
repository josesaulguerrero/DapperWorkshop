namespace DapperWorkshop.DataAccess.DBAccess
{
    public interface ISqlDataAccess
    {
        Task SaveAsync<T>(string storedProcedure, T parameters, string connectionStringName = "Default");

        Task<IEnumerable<T>> SelectAsync<T, K>(string storedProcedure, K parameters, string connectionStringName = "Default");
    }
}