using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QABBB.API.Assemblers;
using QABBB.API.Models.Game.Platform;
using QABBB.Data;
using QABBB.Domain.Services;
using QABBB.Models;

namespace QABBB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GamePlatformController : ControllerBase
    {
        private readonly QABBBContext _context;
        private readonly GamePlatformServices _gpServices;
        private readonly GameServices _gServices;
        private readonly PlatformServices _pServices;
        private readonly GamePlatformAssembler _gpAssembler;

        public GamePlatformController(QABBBContext context)
        {
            _context = context;
            _gpAssembler = new GamePlatformAssembler();
            _gpServices = new GamePlatformServices(_context);
            _gServices = new GameServices(_context);
            _pServices = new PlatformServices(_context);
        }

        // GET: api/GamePlatform/5
        [HttpGet("{idGame}")]
        public ActionResult<List<GamePlatformDTO>> GetGamePlatform(int idGame)
        {
          if (_context.GamePlatforms == null)
              return NotFound();
          
            List<GamePlatform>? gamePlatforms = _gpServices.findByIdGame(idGame);

            List<GamePlatformDTO>? gamePlatformDTOs = _gpAssembler.toGamePlatformDTO(gamePlatforms);

            return Ok(gamePlatformDTOs);
        }

        // POST: api/GamePlatform
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<GamePlatformDTO> PostGamePlatform(GamePlatformInputDTO gamePlatformInputDTO)
        {
            if (_context.GamePlatforms == null)
                return Problem("Entity set 'QABBBContext.GamePlatforms'  is null.");

            string? idPerson = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (idPerson == null)
                return Unauthorized();

            Game? game = _gServices.findById(gamePlatformInputDTO.IdGame);
            if(game == null)
                return NotFound("Invalid IdGame");

            Platform? platform = _pServices.findById(gamePlatformInputDTO.IdPlatform);
            if(platform == null)
                return NotFound("Invalid IdPlatform");
          
            GamePlatform gamePlatform = _gpAssembler.toGamePlatform(gamePlatformInputDTO);

            _gpServices.add(gamePlatform, int.Parse(idPerson));

            GamePlatformDTO gamePlatformDTO = _gpAssembler.toGamePlatformDTO(gamePlatform);

            return CreatedAtAction("GetGamePlatform", new { idGame = gamePlatformDTO.IdGamePlatform }, gamePlatformDTO);
        }

        // DELETE: api/GamePlatform/5
        [HttpDelete("{id}")]
        public ActionResult DeleteGamePlatform(int id)
        {
            if (_context.GamePlatforms == null)
                return NotFound();

            GamePlatform? gamePlatform = _gpServices.findById(id);
            if(gamePlatform == null)
                return NotFound("Invalid Id");

            string? idPerson = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (idPerson == null)
                return Unauthorized();

            _gpServices.delete(gamePlatform);
            
            return NoContent();
        }
    }
}
