using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QABBB.API.Assemblers;
using QABBB.API.Models.ProjectPublisher;
using QABBB.Data;
using QABBB.Domain.Services;
using QABBB.Models;

namespace QABBB.API.Controllers
{
    // [Route("api/[controller]")]
    // [ApiController]
    // [Authorize(Roles = "Admin")]
    // public class ProjectPublisherController : ControllerBase
    // {
    //     private readonly QABBBContext _context;
    //     private readonly ProjectPublisherServices _projectpublisherServices;
    //     private readonly ProjectPublisherAssembler _projectpublisherAssembler;

    //     public ProjectPublisherController(QABBBContext context)
    //     {
    //         _context = context;
    //         _projectpublisherServices = new ProjectPublisherServices(_context);
    //         _projectpublisherAssembler = new ProjectPublisherAssembler();
    //     }

    //     // GET: api/ProjectPublisher
    //     [HttpGet]
    //     public ActionResult<List<ProjectPublisherDTO>> GetCompanies()
    //     {
    //         if (_context.Companies == null)
    //             return NotFound();

    //         List<ProjectPublisher>? _companies = _projectpublisherServices.list();

    //         List<ProjectPublisherDTO> _companiesDTO = _projectpublisherAssembler.toProjectPublisherDTO(_companies);

    //         return Ok(_companiesDTO);
    //     }

    //     // GET: api/ProjectPublisher/5
    //     [HttpGet("{id}")]
    //     public ActionResult<ProjectPublisherDTO> GetProjectPublisher(int id)
    //     {
    //       if (_context.Companies == null)
    //           return NotFound();

    //         var projectpublisher = _projectpublisherServices.findById(id);

    //         if (projectpublisher == null)
    //             return NotFound();

    //         ProjectPublisherDTO projectpublisherDTO = _projectpublisherAssembler.toProjectPublisherDTO(projectpublisher);

    //         return Ok(projectpublisherDTO);
    //     }


    //     // POST: api/ProjectPublisher
    //     // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    //     [HttpPost]
    //     public ActionResult<ProjectPublisherDTO> PostProjectPublisher(ProjectPublisherInputDTO projectpublisherInputDTO)
    //     {
    //         if (_context.Companies == null)
    //             return Problem("Entity set 'QABBBContext.Companies'  is null.");

    //         ProjectPublisher projectpublisher = _projectpublisherAssembler.toProjectPublisher(projectpublisherInputDTO);
            
    //         _projectpublisherServices.add(projectpublisher);

    //         ProjectPublisherDTO projectpublisherDTO = _projectpublisherAssembler.toProjectPublisherDTO(projectpublisher);

    //         return CreatedAtAction("GetProjectPublisher", new { id = projectpublisherDTO.IdProjectPublisher }, projectpublisherDTO);
    //     }

    // }
}
