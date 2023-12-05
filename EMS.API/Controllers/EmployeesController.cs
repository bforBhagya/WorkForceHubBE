using EMS.API.Data;
using EMS.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly EmsDbContext _emsDbContext;
        public EmployeesController(EmsDbContext emsDbContext)
        {
            _emsDbContext = emsDbContext;

        }
        [HttpGet]

        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _emsDbContext.Employee.ToListAsync();
            return Ok(employees);
        }
        [HttpPost]

        public async Task<IActionResult> AddEmployee([FromBody] Employee employeeRequest)
        {
            employeeRequest.Id = Guid.NewGuid();
            await _emsDbContext.Employee.AddAsync(employeeRequest);
            await _emsDbContext.SaveChangesAsync();
            return Ok(employeeRequest);


        }
    }
}
