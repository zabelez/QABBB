using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QABBB.API.Assemblers;
using QABBB.API.Models.ProjectPlatform;
using QABBB.Data;
using QABBB.Domain.Services;
using QABBB.Models;

namespace QABBB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ProjectPlatformController : ControllerBase
    {
        private readonly QABBBContext _context;
        private readonly ProjectPlatformServices _projectplatformServices;
        private readonly ProjectPlatformAssembler _projectplatformAssembler;

        public ProjectPlatformController(QABBBContext context)
        {
            _context = context;
            _projectplatformServices = new ProjectPlatformServices(_context);
            _projectplatformAssembler = new ProjectPlatformAssembler();
        }

        // GET: api/ProjectPlatform
        [HttpGet]
        public ActionResult<List<ProjectPlatformDTO>> GetCompanies()
        {
            if (_context.Companies == null)
                return NotFound();

            List<ProjectPlatform>? _companies = _projectplatformServices.list();

            List<ProjectPlatformDTO> _companiesDTO = _projectplatformAssembler.toProjectPlatformDTO(_companies);

            return Ok(_companiesDTO);
        }

        // GET: api/ProjectPlatform/5
        [HttpGet("{id}")]
        public ActionResult<ProjectPlatformDTO> GetProjectPlatform(int id)
        {
          if (_context.Companies == null)
              return NotFound();

            var projectplatform = _projectplatformServices.findById(id);

            if (projectplatform == null)
                return NotFound();

            ProjectPlatformDTO projectplatformDTO = _projectplatformAssembler.toProjectPlatformDTO(projectplatform);

            return Ok(projectplatformDTO);
        }


        // POST: api/ProjectPlatform
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<ProjectPlatformDTO> PostProjectPlatform(ProjectPlatformInputDTO projectplatformInputDTO)
        {
            if (_context.Companies == null)
                return Problem("Entity set 'QABBBContext.Companies'  is null.");

            ProjectPlatform projectplatform = _projectplatformAssembler.toProjectPlatform(projectplatformInputDTO);
            
            _projectplatformServices.add(projectplatform);

            ProjectPlatformDTO projectplatformDTO = _projectplatformAssembler.toProjectPlatformDTO(projectplatform);

            return CreatedAtAction("GetProjectPlatform", new { id = projectplatformDTO.IdProjectPlatform }, projectplatformDTO);
        }

    }
}
