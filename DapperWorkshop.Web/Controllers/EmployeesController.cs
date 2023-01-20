using DapperWorkshop.Data.Repositories;

using Microsoft.AspNetCore.Mvc;
using DapperWorkshop.Data.Entities;

namespace DapperWorkshop.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeDataAccess _employeeDataAccess;

    public EmployeesController(IEmployeeDataAccess employeeDataAccess)
    {
        _employeeDataAccess = employeeDataAccess;
    }

    // GET: api/<EmployeesController>
    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        return Ok(await _employeeDataAccess.GetAllEmployeesAsync());
    }

    // GET api/<EmployeesController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(int id)
    {
        Employee employee = await _employeeDataAccess.GetEmployeeByIdAsync(id);
        if (employee is null) return NotFound();
        return Ok(employee);
    }

    // POST api/<EmployeesController>
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] Employee employee)
    {
        int id = await _employeeDataAccess.InsertEmployeeAsync(employee);
        return CreatedAtAction(nameof(GetAsync), new { id });
    }

    // PUT api/<EmployeesController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] Employee employee)
    {
        employee.Id = id;
        bool updatedSuccessfully = await _employeeDataAccess.UpdateEmployeeAsync(employee);
        return Ok(updatedSuccessfully);
    }

    // DELETE api/<EmployeesController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        bool deletedSuccessfully = await _employeeDataAccess.DeleteEmployeeAsync(id);
        return Ok(deletedSuccessfully);
    }
}