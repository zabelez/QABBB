using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QABBB.API.Assemblers;
using QABBB.API.Models.Project.ProjectPlatform;
using QABBB.Data;
using QABBB.Domain.Services;
using QABBB.Models;

namespace QABBB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectPlatformController : ControllerBase
    {
        private readonly QABBBContext _context;
        private readonly ProjectPlatformServices _projectplatformServices;
        private readonly ProjectPlatformAssembler _projectplatformAssembler;

        public ProjectPlatformController(QABBBContext context) {
            _context = context;
            _projectplatformServices = new ProjectPlatformServices(_context);
            _projectplatformAssembler = new ProjectPlatformAssembler();
        }

        // GET: api/ProjectPlatform
        [HttpGet]
        public ActionResult<List<ProjectPlatformDTO>> GetProjectPlatforms() {
            if (_context.ProjectPlatforms == null)
                return NotFound();

            List<ProjectPlatform> projectplatforms = _projectplatformServices.list();

            List<ProjectPlatformDTO> projectplatformDTOs = _projectplatformAssembler.toProjectPlatformDTO(projectplatforms);

            return Ok(projectplatformDTOs);
        }

        // GET: api/ProjectPlatform/5
        [HttpGet("{id}")]
        public ActionResult<ProjectPlatformDTO> GetProjectPlatform(int id) {
            if (_context.ProjectPlatforms == null)
                return NotFound();

            ProjectPlatform? projectplatform = _projectplatformServices.findById(id);
            if (projectplatform == null)
                return NotFound();

            ProjectPlatformDTO projectplatformDTO = _projectplatformAssembler.toProjectPlatformDTO(projectplatform);

            return Ok(projectplatformDTO);
        }

        // PUT: api/ProjectPlatform/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public ActionResult PutProjectPlatform(ProjectPlatformEditDTO projectplatformEditDTO) {
            ProjectPlatform? projectplatform = _projectplatformServices.findById(projectplatformEditDTO.IdProjectPlatform);
            if (projectplatform == null)
                return NotFound();

            _projectplatformAssembler.toProjectPlatform(projectplatform, projectplatformEditDTO);

            _projectplatformServices.edit(projectplatform);

            return NoContent();
        }

        // POST: api/ProjectPlatform
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<ProjectPlatformDTO> PostProjectPlatform(ProjectPlatformInputDTO projectplatformInputDTO) {
            if (_context.ProjectPlatforms == null)
                return Problem("Entity set 'QABBBContext.ProjectPlatforms'  is null.");

            ProjectPlatform projectplatform = _projectplatformAssembler.toProjectPlatform(projectplatformInputDTO);

            _projectplatformServices.add(projectplatform);

            ProjectPlatformDTO projectplatformDTO = _projectplatformAssembler.toProjectPlatformDTO(projectplatform);

            return CreatedAtAction("GetProjectPlatform", new {
                id = projectplatformDTO.IdProjectPlatform
            }, projectplatformDTO);
        }

        // DELETE: api/ProjectPlatform/5
        [HttpDelete("{id}")]
        public ActionResult DeleteProjectPlatform(int id) {
            if (_context.ProjectPlatforms == null)
                return NotFound();

            ProjectPlatform? projectplatform = _projectplatformServices.findById(id);
            if (projectplatform == null)
                return NotFound();

            _projectplatformServices.delete(projectplatform);

            return NoContent();
        }
    }
}
