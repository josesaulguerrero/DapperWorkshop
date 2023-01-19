namespace DapperWorkshop.DataAccess.Data.Entities;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string EmployeeCode { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }
    public DateTime HiredAt { get; set; }
    public DateTime? FiredAt { get; set; }
}