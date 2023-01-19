using DapperWorkshop.Data.DAO;
using DapperWorkshop.DataAccess.Data.Entities;

namespace DapperWorkshop.Data.Repositories;

public class EmployeeDataAccess : IEmployeeDataAccess
{
    private readonly ISqlDataAccess _db;

    public EmployeeDataAccess(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<Employee>> GetAllEmployeesAsync() =>
        _db.SelectAsync<Employee, dynamic>("dbo.SPEmployee_SelectAll", new { });

    public async Task<Employee?> GetEmployeeByIdAsync(int id)
    {
        IEnumerable<Employee> results = await _db.SelectAsync<Employee, dynamic>(
            "dbo.SPEmployee_SelectByPK",
            new { Id = id }
        );

        return results.FirstOrDefault();
    }

    public Task InsertEmployeeAsync(Employee employee) =>
        _db.SaveAsync<dynamic>(
            "dbo.SPEmployee_Insert",
            new
            {
                employee.Name,
                employee.EmployeeCode,
                employee.Email,
                employee.Age,
                employee.HiredAt
            }
        );

    public Task UpdateEmployeeAsync(Employee employee) =>
        _db.SaveAsync<dynamic>(
            "dbo.SPEmployee_UpdateByPK",
            new
            {
                employee.Id,
                employee.Name,
                employee.Email,
                employee.Age,
                employee.FiredAt
            }
        );

    public Task DeleteEmployeeAsync(int id) =>
        _db.SaveAsync<dynamic>(
            "dbo.SPEmployee_DeleteByPK",
            new { Id = id, FiredAt = DateTime.Now }
        );
}