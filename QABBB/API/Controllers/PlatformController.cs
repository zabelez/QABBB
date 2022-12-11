using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QABBB.API.Assemblers;
using QABBB.API.Models.Platform;
using QABBB.Data;
using QABBB.Domain.Services;
using QABBB.Models;

namespace QABBB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class PlatformController : ControllerBase
    {
        private readonly QABBBContext _context;
        private readonly PlatformServices _platformServices;
        private readonly PlatformAssembler _platformAssembler;

        public PlatformController(QABBBContext context)
        {
            _context = context;
            _platformServices = new PlatformServices(_context);
            _platformAssembler = new PlatformAssembler();
        }

        // GET: api/Platform
        [HttpGet]
        public ActionResult<List<PlatformDTO>> GetPlatforms()
        {
          if (_context.Platforms == null)
                return NotFound();

            List<Platform>? _companies = _platformServices.list();

            List<PlatformDTO> _companiesDTO = _platformAssembler.toPlatformDTO(_companies);

            return Ok(_companiesDTO);
        }

        // GET: api/Platform/5
        [HttpGet("{id}")]
        public ActionResult<PlatformDTO> GetPlatform(int id)
        {
          if (_context.Companies == null)
              return NotFound();

            var platform = _platformServices.findById(id);

            if (platform == null)
                return NotFound();

            PlatformDTO platformDTO = _platformAssembler.toPlatformDTO(platform);

            return Ok(platformDTO);
        }

        // PUT: api/Platform/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public ActionResult PutPlatform(PlatformEditInputDTO platformEditInputDTO)
        {
            Platform? platform = _platformServices.findById(platformEditInputDTO.IdPlatform);
            if(platform == null)
                return NotFound();

            _platformAssembler.toPlatform(platform, platformEditInputDTO);

            _platformServices.edit(platform);

            return NoContent();
        }

        // POST: api/Platform
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<PlatformDTO> PostPlatform(PlatformInputDTO platformInputDTO)
        {
          if (_context.Companies == null)
                return Problem("Entity set 'QABBBContext.Companies'  is null.");

            Platform platform = _platformAssembler.toPlatform(platformInputDTO);
            
            _platformServices.add(platform);

            PlatformDTO platformDTO = _platformAssembler.toPlatformDTO(platform);

            return CreatedAtAction("GetPlatform", new { id = platformDTO.IdPlatform }, platformDTO);
        }
    }
}
