using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QABBB.API.Assemblers;
using QABBB.API.Models.User.Platform;
using QABBB.Data;
using QABBB.Domain.Services;
using QABBB.Models;

namespace QABBB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserPlatformController : ControllerBase
    {
        private readonly QABBBContext _context;
        private readonly UserPlatformServices _upServices;
        private readonly UserServices _uServices;
        private readonly PlatformServices _pServices;
        private readonly UserPlatformAssembler _upAssembler;

        public UserPlatformController(QABBBContext context)
        {
            _context = context;
            _upAssembler = new UserPlatformAssembler();
            _upServices = new UserPlatformServices(_context);
            _uServices = new UserServices(_context);
            _pServices = new PlatformServices(_context);
        }

        // GET: api/UserPlatform/5
        [HttpGet("{idUser}")]
        public ActionResult GetUserPlatform(int idUser)
        {
          if (_context.UserPlatforms == null)
              return NotFound();
          
            List<UserPlatform>? userPlatforms = _upServices.findByIdUser(idUser);

            List<UserPlatformDTO>? userPlatformDTOs = _upAssembler.toUserPlatformDTO(userPlatforms);

            return Ok(userPlatformDTOs);
        }

        // POST: api/UserPlatform
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult PostUserPlatform(UserPlatformInputDTO userPlatformInputDTO)
        {
            if (_context.UserPlatforms == null)
                return Problem("Entity set 'QABBBContext.UserPlatforms'  is null.");

            string? idPerson = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (idPerson == null)
                return Unauthorized();

            User? user = _uServices.findById(userPlatformInputDTO.IdUser);
            if(user == null)
                return NotFound("Invalid IdUser");

            Platform? platform = _pServices.findById(userPlatformInputDTO.IdPlatform);
            if(platform == null)
                return NotFound("Invalid IdPlatform");
          
            UserPlatform userPlatform = _upAssembler.toUserPlatform(userPlatformInputDTO);

            _upServices.add(userPlatform, int.Parse(idPerson));

            UserPlatformDTO userPlatformDTO = _upAssembler.toUserPlatformDTO(userPlatform);

            return CreatedAtAction("GetUserPlatform", new { idUser = userPlatformDTO.IdUserPlatform }, userPlatformDTO);
        }

        // DELETE: api/UserPlatform/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUserPlatform(int id)
        {
            if (_context.UserPlatforms == null)
                return NotFound();

            UserPlatform? userPlatform = _upServices.findById(id);
            if(userPlatform == null)
                return NotFound("Invalid Id");

            string? idPerson = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (idPerson == null)
                return Unauthorized();

            _upServices.inactivate(userPlatform, int.Parse(idPerson));
            
            return NoContent();
        }
    }
}
