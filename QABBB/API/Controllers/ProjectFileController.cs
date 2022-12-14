using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QABBB.API.Assemblers;
using QABBB.API.Models.Project.ProjectFile;
using QABBB.Data;
using QABBB.Domain.Services;
using QABBB.Models;

namespace QABBB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ProjectFileController : ControllerBase
    {
        private readonly QABBBContext _context;
        private readonly ProjectFileServices _projectfileServices;
        private readonly ProjectFileAssembler _projectfileAssembler;

        public ProjectFileController(QABBBContext context)
        {
            _context = context;
            _projectfileServices = new ProjectFileServices(_context);
            _projectfileAssembler = new ProjectFileAssembler();
        }

        // GET: api/ProjectFile
        [HttpGet]
        public ActionResult<List<ProjectFileDTO>> GetProjectFiles()
        {
            if (_context.ProjectFiles == null)
                return NotFound();

            List<ProjectFile> projectfiles = _projectfileServices.list();

            List<ProjectFileDTO> projectfileDTOs = _projectfileAssembler.toProjectFileDTO(projectfiles);
          
            return Ok(projectfileDTOs);
        }

        // GET: api/ProjectFile/5
        [HttpGet("{id}")]
        public ActionResult<ProjectFileDTO> GetProjectFile(int id)
        {
            if (_context.ProjectFiles == null)
                return NotFound();
          
            ProjectFile? projectfile = _projectfileServices.findById(id);
            if(projectfile == null)
                return NotFound();

            ProjectFileDTO projectfileDTO = _projectfileAssembler.toProjectFileDTO(projectfile);

            return Ok(projectfileDTO);
        }

        // PUT: api/ProjectFile/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public ActionResult PutProjectFile(ProjectFileEditDTO projectfileEditDTO)
        {
            ProjectFile? projectfile = _projectfileServices.findById(projectfileEditDTO.IdProjectFile);
            if(projectfile == null)
                return NotFound();

            _projectfileAssembler.toProjectFile(projectfile, projectfileEditDTO);
            
            _projectfileServices.edit(projectfile);
            
            return NoContent();
        }

        // POST: api/ProjectFile
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<ProjectFile> PostProjectFile(ProjectFileInputDTO projectfileInputDTO)
        {
            if (_context.ProjectFiles == null)
                return Problem("Entity set 'QABBBContext.ProjectFiles'  is null.");

            ProjectFile projectfile = _projectfileAssembler.toProjectFile(projectfileInputDTO);

            return projectfile;
            _projectfileServices.add(projectfile);

            //ProjectFileDTO projectfileDTO = _projectfileAssembler.toProjectFileDTO(projectfile);

            //return CreatedAtAction("GetProjectFile", new { id = projectfileDTO.IdProjectFile }, projectfileDTO);
        }

        // DELETE: api/ProjectFile/5
        [HttpDelete("{id}")]
        public ActionResult DeleteProjectFile(int id)
        {
            if (_context.ProjectFiles == null)
                return NotFound();
            
            ProjectFile? projectfile = _projectfileServices.findById(id);
            if(projectfile == null)
                return NotFound();

            _projectfileServices.delete(projectfile);

            return NoContent();
        }
    }
}
