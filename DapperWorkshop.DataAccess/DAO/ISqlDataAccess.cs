namespace DapperWorkshop.Data.DAO;

public interface ISqlDataAccess<EntityType, PKType>
{
    Task<bool> DeleteAsync(PKType PKValue, string tableName = nameof(EntityType), string tablePKName = "Id");

    Task<PKType> InsertAsync(object insertObject, string tableName = nameof(EntityType));

    Task<IEnumerable<EntityType>> SelectAllAsync(string? tableName = nameof(EntityType));

    Task<EntityType> SelectByPKAsync(PKType PKValue, string tableName = nameof(EntityType), string tablePKName = "Id");

    Task<bool> UpdateAsync(PKType PKValue, object insertObject, string tableName = nameof(EntityType), string tablePKName = "Id");
}