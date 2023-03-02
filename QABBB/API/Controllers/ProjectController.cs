using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QABBB.API.Assemblers;
using QABBB.API.Models.Project;
using QABBB.Data;
using QABBB.Domain.Services;
using QABBB.Models;

namespace QABBB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ProjectController : ControllerBase
    {
        private readonly QABBBContext _context;
        private readonly ProjectServices _projectServices;
        private readonly ProjectAssembler _projectAssembler;

        public ProjectController(QABBBContext context)
        {
            _context = context;
            _projectServices = new ProjectServices(_context);
            _projectAssembler = new ProjectAssembler();
        }

        // GET: api/Project
        [HttpGet]
        public ActionResult<List<ProjectForDashboardScreenDTO>> GetProjects()
        {
            if (_context.Projects == null)
                return NotFound();

            List<Project> projects = _projectServices.list();

            List<ProjectForDashboardScreenDTO> projectDTOs = _projectAssembler.toProjectForDashboardScreenDTO(projects);
          
            return Ok(projectDTOs);
        }

        // GET: api/Project/byUser/{id}
        [HttpGet("byUser/{id}")]
        public ActionResult<List<ProjectForDashboardScreenDTO>> GetProjectsByUser(int id)
        {
            if (_context.Projects == null)
                return NotFound();

            List<Project> projects = _projectServices.listByUser(id);

            List<ProjectForDashboardScreenDTO> projectDTOs = _projectAssembler.toProjectForDashboardScreenDTO(projects);

            return Ok(projectDTOs);
        }

        // GET: api/Project/byCompany/{id}
        [HttpGet("byCompany/{id}")]
        public ActionResult<List<ProjectForDashboardScreenDTO>> GetProjectsByCompany(int id)
        {
            if (_context.Projects == null)
                return NotFound();

            List<Project> projects = _projectServices.listByCompany(id);

            List<ProjectForDashboardScreenDTO> projectDTOs = _projectAssembler.toProjectForDashboardScreenDTO(projects);

            return Ok(projectDTOs);
        }

        // GET: api/Project/5
        [HttpGet("{id}")]
        public ActionResult<ProjectFullDTO> GetProject(int id)
        {
            if (_context.Projects == null)
                return NotFound();
          
            Project? project = _projectServices.findById(id);
            if(project == null)
                return NotFound();

            ProjectFullDTO projectDTO = _projectAssembler.toProjectFullDTO(project);

            return Ok(projectDTO);
        }

        // PUT: api/Project/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public ActionResult PutProject(ProjectEditDTO projectEditDTO)
        {
            Project? project = _projectServices.findById(projectEditDTO.IdProject);
            if(project == null)
                return NotFound();

            _projectAssembler.toProject(project, projectEditDTO);
            
            _projectServices.edit(project);
            
            return NoContent();
        }

        // POST: api/Project
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<ProjectDTO> PostProject(ProjectInputDTO projectInputDTO)
        {
            if (_context.Projects == null)
                return Problem("Entity set 'QABBBContext.Projects'  is null.");

            Project project = _projectAssembler.toProject(projectInputDTO);

            _projectServices.add(project);

            ProjectDTO projectDTO = _projectAssembler.toProjectDTO(project);

            return CreatedAtAction("GetProject", new { id = projectDTO.IdProject }, projectDTO);
        }

        // DELETE: api/Project/5
        [HttpDelete("{id}")]
        public ActionResult DeleteProject(int id)
        {
            if (_context.Projects == null)
                return NotFound();
            
            Project? project = _projectServices.findById(id);
            if(project == null)
                return NotFound();

            _projectServices.delete(project);

            return NoContent();
        }
    }
}
