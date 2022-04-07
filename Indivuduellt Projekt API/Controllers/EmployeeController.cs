using Individuellt_Projekt___Avancerad_.NET___Lukas_Rose_SUT21;
using Indivuduellt_Projekt_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Indivuduellt_Projekt_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public IEmpRepo<Employee> employees;
        public EmployeeController(IEmpRepo<Employee> e)
        {
            employees = e;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await employees.GetAll());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when retrieving all the employees from the database.");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var employee = await employees.Get(id);
                if (employee != null)
                {
                    return Ok(await employees.Get(id));
                }
                return NotFound();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error when retrieving employee with Id {id} from the database.");
            }
        }
        [HttpGet("timereport/{id:int}")]
        public async Task<IActionResult> GetWithReport(int id)
        {
            try
            {
                var employee = await employees.GetWithReport(id);
                if (employee != null)
                {
                    return Ok(await employees.Get(id));
                }
                return NotFound();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error when retrieving employee with Id {id} from the database.");
            }
        }
        [HttpGet("projectemployees/{id:int}")]
        public async Task<IActionResult> GetEmployeesInProjects(int id)
        {
            try
            {
                return Ok(await employees.EmployeesInProjects(id));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error when retrieving employees related to project with {id}.");

            }
        }
        [HttpGet("hoursbyweek/{id:int}/{week:int}")]
        public async Task<IActionResult> GetHoursByWeek(int id, int week)
        {
            try
            {
                return Ok(await employees.HoursByWeek(id, week));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error when retrieving employees work hours from week {week} from database.");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Add(Employee employee)
        {
            try
            {
                if (employee == null) { return BadRequest(); }
                var added = await employees.Add(employee);
                return CreatedAtAction(nameof(Get), new { id = added.Id }, added);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when adding employee to database.");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Employee>> Update(int id, Employee employee)
        {
            try
            {
                if (id != employee.Id)
                {
                    return BadRequest();
                }
                var empToUpdate = employees.Get(id);
                if(empToUpdate == null)
                {
                    return NotFound($"Employee with ID {id} could not be found.");
                }
                return await employees.Update(employee);

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when updating database");
            }
            
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Employee>> Delete(int id)
        {
            try
            {
                var empToDelete = employees.Get(id);
                if (empToDelete == null)
                {
                    return NotFound();
                }
                return await employees.Delete(id);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when deleting employee from database...");
            }
        }
    }
}
