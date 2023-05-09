using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QABBB.API.Assemblers;
using QABBB.API.Models.ProjectDeveloper;
using QABBB.Data;
using QABBB.Domain.Services;
using QABBB.Models;

namespace QABBB.API.Controllers
{
    // [Route("api/[controller]")]
    // [ApiController]
    // [Authorize(Roles = "Admin")]
    // public class ProjectDeveloperController : ControllerBase
    // {
    //     private readonly QABBBContext _context;
    //     private readonly ProjectDeveloperServices _projectdeveloperServices;
    //     private readonly ProjectDeveloperAssembler _projectdeveloperAssembler;

    //     public ProjectDeveloperController(QABBBContext context)
    //     {
    //         _context = context;
    //         _projectdeveloperServices = new ProjectDeveloperServices(_context);
    //         _projectdeveloperAssembler = new ProjectDeveloperAssembler();
    //     }

    //     // GET: api/ProjectDeveloper
    //     [HttpGet]
    //     public ActionResult<List<ProjectDeveloperDTO>> GetCompanies()
    //     {
    //         if (_context.Companies == null)
    //             return NotFound();

    //         List<ProjectDeveloper>? _companies = _projectdeveloperServices.list();

    //         List<ProjectDeveloperDTO> _companiesDTO = _projectdeveloperAssembler.toProjectDeveloperDTO(_companies);

    //         return Ok(_companiesDTO);
    //     }

    //     // GET: api/ProjectDeveloper/5
    //     [HttpGet("{id}")]
    //     public ActionResult<ProjectDeveloperDTO> GetProjectDeveloper(int id)
    //     {
    //       if (_context.Companies == null)
    //           return NotFound();

    //         var projectdeveloper = _projectdeveloperServices.findById(id);

    //         if (projectdeveloper == null)
    //             return NotFound();

    //         ProjectDeveloperDTO projectdeveloperDTO = _projectdeveloperAssembler.toProjectDeveloperDTO(projectdeveloper);

    //         return Ok(projectdeveloperDTO);
    //     }


    //     // POST: api/ProjectDeveloper
    //     // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    //     [HttpPost]
    //     public ActionResult<ProjectDeveloperDTO> PostProjectDeveloper(ProjectDeveloperInputDTO projectdeveloperInputDTO)
    //     {
    //         if (_context.Companies == null)
    //             return Problem("Entity set 'QABBBContext.Companies'  is null.");

    //         ProjectDeveloper projectdeveloper = _projectdeveloperAssembler.toProjectDeveloper(projectdeveloperInputDTO);
            
    //         _projectdeveloperServices.add(projectdeveloper);

    //         ProjectDeveloperDTO projectdeveloperDTO = _projectdeveloperAssembler.toProjectDeveloperDTO(projectdeveloper);

    //         return CreatedAtAction("GetProjectDeveloper", new { id = projectdeveloperDTO.IdProjectDeveloper }, projectdeveloperDTO);
    //     }

    // }
}
