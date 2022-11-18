using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QABBB.API.Assemblers;
using QABBB.API.Models.Developer;
using QABBB.Data;
using QABBB.Domain.Services;
using QABBB.Models;

namespace QABBB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class DeveloperController : ControllerBase
    {
        private readonly QABBBContext _context;
        private readonly DeveloperServices _developerServices;
        private readonly DeveloperAssembler _developerAssembler;

        public DeveloperController(QABBBContext context)
        {
            _context = context;
            _developerServices = new DeveloperServices(_context);
            _developerAssembler = new DeveloperAssembler();
        }

        // GET: api/Developer
        [HttpGet]
        public ActionResult GetDevelopers()
        {
            if (_context.Developers == null)
                return NotFound();

            List<Developer> developers = _developerServices.list();

            List<DeveloperDTO> developerDTOs = _developerAssembler.toDeveloperDTO(developers);

            return Ok(developerDTOs);
        }

        // GET: api/Developer/5
        [HttpGet("{id}")]
        public ActionResult GetDeveloper(int id)
        {
            if (_context.Developers == null)
                return NotFound();

            Developer? developer = _developerServices.findById(id);

            if (developer == null)
                return NotFound();

            DeveloperDTO developerDTO = _developerAssembler.toDeveloperDTO(developer);

            return Ok(developerDTO);
        }

        // POST: api/Developer
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult PostDeveloper(DeveloperInputDTO developerInputDTO)
        {
            if (_context.Developers == null)
                return Problem("Entity set 'QABBBContext.Developers'  is null.");
            
            Developer developer = _developerAssembler.toDeveloper(developerInputDTO);

            _developerServices.add(developer);

            DeveloperDTO developerDTO = _developerAssembler.toDeveloperDTO(developer);

            return CreatedAtAction("GetDeveloper", new { id = developerDTO.IdDeveloper }, developerDTO);
        }
    }
}
