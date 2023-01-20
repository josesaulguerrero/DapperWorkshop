using DapperWorkshop.Data.Entities;

namespace DapperWorkshop.Data.Repositories;

public interface IEmployeeDataAccess
{
    Task<bool> DeleteEmployeeAsync(int id);

    Task<IEnumerable<Employee>> GetAllEmployeesAsync();

    Task<Employee> GetEmployeeByIdAsync(int id);

    Task<int> InsertEmployeeAsync(Employee employee);

    Task<bool> UpdateEmployeeAsync(Employee employee);
}