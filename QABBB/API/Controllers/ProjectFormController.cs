using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QABBB.API.Assemblers;
using QABBB.API.Models.Project.ProjectForm;
using QABBB.Data;
using QABBB.Domain.Services;
using QABBB.Models;

namespace QABBB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ProjectFormController : ControllerBase
    {
        private readonly QABBBContext _context;
        private readonly ProjectFormServices _projectformServices;
        private readonly ProjectFormAssembler _projectformAssembler;

        public ProjectFormController(QABBBContext context)
        {
            _context = context;
            _projectformServices = new ProjectFormServices(_context);
            _projectformAssembler = new ProjectFormAssembler();
        }

        // GET: api/ProjectForm
        [HttpGet]
        public ActionResult<List<ProjectFormDTO>> GetProjectForms()
        {
            if (_context.ProjectForms == null)
                return NotFound();

            List<ProjectForm> projectforms = _projectformServices.list();

            List<ProjectFormDTO> projectformDTOs = _projectformAssembler.toProjectFormDTO(projectforms);
          
            return Ok(projectformDTOs);
        }

        // GET: api/ProjectForm/5
        [HttpGet("{id}")]
        public ActionResult<ProjectFormDTO> GetProjectForm(int id)
        {
            if (_context.ProjectForms == null)
                return NotFound();
          
            ProjectForm? projectform = _projectformServices.findById(id);
            if(projectform == null)
                return NotFound();

            ProjectFormDTO projectformDTO = _projectformAssembler.toProjectFormDTO(projectform);

            return Ok(projectformDTO);
        }

        // PUT: api/ProjectForm/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public ActionResult PutProjectForm(ProjectFormEditDTO projectformEditDTO)
        {
            ProjectForm? projectform = _projectformServices.findById(projectformEditDTO.IdProjectForm);
            if(projectform == null)
                return NotFound();

            _projectformAssembler.toProjectForm(projectform, projectformEditDTO);
            
            _projectformServices.edit(projectform);
            
            return NoContent();
        }

        // POST: api/ProjectForm
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<ProjectFormDTO> PostProjectForm(ProjectFormInputDTO projectformInputDTO)
        {
            if (_context.ProjectForms == null)
                return Problem("Entity set 'QABBBContext.ProjectForms'  is null.");

            ProjectForm projectform = _projectformAssembler.toProjectForm(projectformInputDTO);

            _projectformServices.add(projectform);

            ProjectFormDTO projectformDTO = _projectformAssembler.toProjectFormDTO(projectform);

            return CreatedAtAction("GetProjectForm", new { id = projectformDTO.IdProjectForm }, projectformDTO);
        }

        // DELETE: api/ProjectForm/5
        [HttpDelete("{id}")]
        public ActionResult DeleteProjectForm(int id)
        {
            if (_context.ProjectForms == null)
                return NotFound();
            
            ProjectForm? projectform = _projectformServices.findById(id);
            if(projectform == null)
                return NotFound();

            _projectformServices.delete(projectform);

            return NoContent();
        }
    }
}
