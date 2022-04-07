using Individuellt_Projekt___Avancerad_.NET___Lukas_Rose_SUT21;
using Indivuduellt_Projekt_API.Data;
using Indivuduellt_Projekt_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Indivuduellt_Projekt_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        IRepo<Project> projects { get; set; }
        public ProjectController(IRepo<Project> projects)
        {
            this.projects = projects;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await projects.GetAll());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when retrieving all projects from database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await projects.Get(id));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error when retrieving project with Id {id} from database");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Add(Project project)
        {
            try
            {
                if (project == null) { return BadRequest(); }
                var added = await projects.Add(project);
                return CreatedAtAction(nameof(Get), new { id = added.Id }, added);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error when adding project to database");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Project>> Update(int id, Project project)
        {
            try
            {
                if (id != project.Id) { return BadRequest(); }
                var projToUpdate = projects.Get(id);
                if (projToUpdate == null) 
                {
                    return NotFound();
                }
                return await projects.Update(project);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when updating database");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Project>> Delete(int id)
        {
            try
            {
                var projToDelete = projects.Get(id);
                if (projToDelete == null)
                {
                    return NotFound();
                }
                return await projects.Delete(id);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when deleting project from database");
            }
        }
    }
}
