using DapperWorkshop.Data.Repositories;

using Microsoft.AspNetCore.Mvc;
using DapperWorkshop.DataAccess.Data.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        await _employeeDataAccess.InsertEmployeeAsync(employee);
        return StatusCode(StatusCodes.Status201Created);
    }

    // PUT api/<EmployeesController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] Employee employee)
    {
        employee.Id = id;
        await _employeeDataAccess.UpdateEmployeeAsync(employee);
        return Ok();
    }

    // DELETE api/<EmployeesController>/5
    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
        await _employeeDataAccess.DeleteEmployeeAsync(id);
    }
}