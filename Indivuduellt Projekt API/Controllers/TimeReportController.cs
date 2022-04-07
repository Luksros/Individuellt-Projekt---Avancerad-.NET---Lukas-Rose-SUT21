using Individuellt_Projekt___Avancerad_.NET___Lukas_Rose_SUT21;
using Indivuduellt_Projekt_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Indivuduellt_Projekt_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeReportController : ControllerBase
    {
        IRepo<TimeReport> timereports { get; set; }
        public TimeReportController(IRepo<TimeReport> timereports)
        {
            this.timereports = timereports;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await timereports.GetAll());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when retrieving all timereports from database.");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await timereports.Get(id));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error when retrieving timereport with Id {id} from database.");
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> Add(TimeReport timereport)
        {
            try
            {
                if (timereport == null) { return BadRequest(); }
                var added = await timereports.Add(timereport);
                return CreatedAtAction(nameof(Get), new { id = added.Id }, added);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error when adding timereport to database.");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<TimeReport>> Update(int id, TimeReport timereport)
        {
            try
            {
                if (id != timereport.Id) { return BadRequest(); }
                var projToUpdate = timereports.Get(id);
                if (projToUpdate == null)
                {
                    return NotFound();
                }
                return await timereports.Update(timereport);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when updating database.");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<TimeReport>> Delete(int id)
        {
            try
            {
                var projToDelete = timereports.Get(id);
                if (projToDelete == null)
                {
                    return NotFound();
                }
                return await timereports.Delete(id);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when deleting timereports from database.");
            }
        }
    }
}
