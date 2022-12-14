using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QABBB.API.Assemblers;
using QABBB.API.Models.Project.ProjectSummary;
using QABBB.Data;
using QABBB.Domain.Services;
using QABBB.Models;

namespace QABBB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ProjectSummaryDocController : ControllerBase
    {
        private readonly QABBBContext _context;
        private readonly ProjectSummaryDocServices _projectsummarydocServices;
        private readonly ProjectSummaryDocAssembler _projectsummarydocAssembler;

        public ProjectSummaryDocController(QABBBContext context)
        {
            _context = context;
            _projectsummarydocServices = new ProjectSummaryDocServices(_context);
            _projectsummarydocAssembler = new ProjectSummaryDocAssembler();
        }

        // GET: api/ProjectSummaryDoc
        [HttpGet]
        public ActionResult<List<ProjectSummaryDocDTO>> GetProjectSummaryDocs()
        {
            if (_context.ProjectSummaryDocs == null)
                return NotFound();

            List<ProjectSummaryDoc> projectsummarydocs = _projectsummarydocServices.list();

            List<ProjectSummaryDocDTO> projectsummarydocDTOs = _projectsummarydocAssembler.toProjectSummaryDocDTO(projectsummarydocs);
          
            return Ok(projectsummarydocDTOs);
        }

        // GET: api/ProjectSummaryDoc/5
        [HttpGet("{id}")]
        public ActionResult<ProjectSummaryDocDTO> GetProjectSummaryDoc(int id)
        {
            if (_context.ProjectSummaryDocs == null)
                return NotFound();
          
            ProjectSummaryDoc? projectsummarydoc = _projectsummarydocServices.findById(id);
            if(projectsummarydoc == null)
                return NotFound();

            ProjectSummaryDocDTO projectsummarydocDTO = _projectsummarydocAssembler.toProjectSummaryDocDTO(projectsummarydoc);

            return Ok(projectsummarydocDTO);
        }

        // PUT: api/ProjectSummaryDoc/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public ActionResult PutProjectSummaryDoc(ProjectSummaryDocEditDTO projectsummarydocEditDTO)
        {
            ProjectSummaryDoc? projectsummarydoc = _projectsummarydocServices.findById(projectsummarydocEditDTO.IdProjectSummaryDoc);
            if(projectsummarydoc == null)
                return NotFound();

            _projectsummarydocAssembler.toProjectSummaryDoc(projectsummarydoc, projectsummarydocEditDTO);
            
            _projectsummarydocServices.edit(projectsummarydoc);
            
            return NoContent();
        }

        // POST: api/ProjectSummaryDoc
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<ProjectSummaryDocDTO> PostProjectSummaryDoc(ProjectSummaryDocInputDTO projectsummarydocInputDTO)
        {
            if (_context.ProjectSummaryDocs == null)
                return Problem("Entity set 'QABBBContext.ProjectSummaryDocs'  is null.");

            ProjectSummaryDoc projectsummarydoc = _projectsummarydocAssembler.toProjectSummaryDoc(projectsummarydocInputDTO);

            _projectsummarydocServices.add(projectsummarydoc);

            ProjectSummaryDocDTO projectsummarydocDTO = _projectsummarydocAssembler.toProjectSummaryDocDTO(projectsummarydoc);

            return CreatedAtAction("GetProjectSummaryDoc", new { id = projectsummarydocDTO.IdProjectSummaryDoc }, projectsummarydocDTO);
        }

        // DELETE: api/ProjectSummaryDoc/5
        [HttpDelete("{id}")]
        public ActionResult DeleteProjectSummaryDoc(int id)
        {
            if (_context.ProjectSummaryDocs == null)
                return NotFound();
            
            ProjectSummaryDoc? projectsummarydoc = _projectsummarydocServices.findById(id);
            if(projectsummarydoc == null)
                return NotFound();

            _projectsummarydocServices.delete(projectsummarydoc);

            return NoContent();
        }
    }
}
