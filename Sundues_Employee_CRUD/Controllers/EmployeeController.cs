using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sundues_Employee_CRUD.Data;
using Sundues_Employee_CRUD.Models;

namespace Sundues_Employee_CRUD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly EmployeeDbContext _employeeDbContext;

        public EmployeeController(EmployeeDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
        }

        [HttpGet("GetAllEmployees")]
        public async Task<IActionResult> GetAllEmployees()
        {
            var emp = await _employeeDbContext.Employees.ToListAsync();
            return Ok(emp);
        }

        [HttpGet("GetEmployeeById")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var emp = await _employeeDbContext.Employees.FirstOrDefaultAsync(e=>e.Id == id);
            if (emp == null) { return NotFound(); }
            return Ok(emp);
        }
        [HttpPost("Add_Employee")]
        public async Task<IActionResult> CreateEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeDbContext.Employees.Add(employee);
                await _employeeDbContext.SaveChangesAsync();
                return Ok("Employee Added");
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("Delete_Employee/{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var emp = await _employeeDbContext.Employees.FindAsync(id);

            if (emp == null)
            {
                return NotFound();
            }

            _employeeDbContext.Employees.Remove(emp);
            await _employeeDbContext.SaveChangesAsync();

            return Ok("Record Deleted Successfully");
        }

        [HttpPut("Update_Employee/{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, Employee employee)
        {
            var emp = await _employeeDbContext.Employees.FindAsync(id);
            if (emp != null) {
                emp.First_Name = employee.First_Name;
                emp.Last_Name= employee.Last_Name;
                emp.Designation= employee.Designation;
                emp.Salary= employee.Salary;
                emp.Email = employee.Email;
                emp.Phone = employee.Phone;
                await _employeeDbContext.SaveChangesAsync();
                return Ok("Updated successfully");
            }
            return NotFound();
        }
    }
}
