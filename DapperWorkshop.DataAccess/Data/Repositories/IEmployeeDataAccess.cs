using DapperWorkshop.DataAccess.Data.Entities;

namespace DapperWorkshop.Data.Repositories;

public interface IEmployeeDataAccess
{
    Task DeleteEmployeeAsync(int id);

    Task<IEnumerable<Employee>> GetAllEmployeesAsync();

    Task<Employee?> GetEmployeeByIdAsync(int id);

    Task InsertEmployeeAsync(Employee employee);

    Task UpdateEmployeeAsync(Employee employee);
}