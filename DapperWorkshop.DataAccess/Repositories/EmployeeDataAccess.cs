using DapperWorkshop.Data.DAO;
using DapperWorkshop.Data.Entities;

namespace DapperWorkshop.Data.Repositories;

public class EmployeeDataAccess : IEmployeeDataAccess
{
    private readonly ISqlDataAccess<Employee, int> _db;
    private const string TABLE_NAME = "dbo.Employee";
    private const string TABLE_PK = "Id";

    public EmployeeDataAccess(ISqlDataAccess<Employee, int> db)
    {
        _db = db;
    }

    public Task<IEnumerable<Employee>> GetAllEmployeesAsync() =>
        _db.SelectAllAsync(TABLE_NAME);

    public Task<Employee> GetEmployeeByIdAsync(int id) =>
        _db.SelectByPKAsync(id, TABLE_NAME, TABLE_PK);

    public Task<int> InsertEmployeeAsync(Employee employee) =>
        _db.InsertAsync(
            tableName: TABLE_NAME,
            insertObject: new
            {
                employee.Name,
                employee.EmployeeCode,
                employee.Email,
                employee.Age,
                employee.HiredAt
            }
        );

    public Task<bool> UpdateEmployeeAsync(Employee employee) =>
        _db.UpdateAsync(
            employee.Id,
            new
            {
                employee.Name,
                employee.Email,
                employee.Age,
                employee.FiredAt
            },
            TABLE_NAME,
            TABLE_PK
        );

    public Task<bool> DeleteEmployeeAsync(int id) =>
        _db.DeleteAsync(id, TABLE_NAME, TABLE_PK);
}