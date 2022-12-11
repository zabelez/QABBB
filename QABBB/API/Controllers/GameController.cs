using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QABBB.API.Assemblers;
using QABBB.API.Models.Game;
using QABBB.Data;
using QABBB.Domain.Services;
using QABBB.Models;

namespace QABBB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class GameController : ControllerBase
    {
        private readonly QABBBContext _context;
        private readonly GameServices _gameServices;
        private readonly GameAssembler _gameAssembler;

        public GameController(QABBBContext context)
        {
            _context = context;
            _gameServices = new GameServices(_context);
            _gameAssembler = new GameAssembler();
        }

        // GET: api/Game
        [HttpGet]
        public ActionResult<List<GameDTO>> GetGames()
        {
            if (_context.Games == null)
                return NotFound();

            List<Game>? _companies = _gameServices.list();

            List<GameDTO> _companiesDTO = _gameAssembler.toGameDTO(_companies);

            return Ok(_companiesDTO);
        }

        // GET: api/Game/5
        [HttpGet("{id}")]
        public ActionResult<GameAndPlatformsDTO> GetGame(int id)
        {
          if (_context.Games == null)
              return NotFound();

            var game = _gameServices.findById(id);

            if (game == null)
                return NotFound();

            GameAndPlatformsDTO gameDTO = _gameAssembler.toGameAndPlatformsDTO(game);

            return Ok(gameDTO);
        }

        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public ActionResult PutUser(GameEditInputDTO gameEditInputDTO)
        {
            Game? game = _gameServices.findById(gameEditInputDTO.IdGame);
            if(game == null)
                return NotFound();

            _gameAssembler.toGame(game, gameEditInputDTO);

            _gameServices.edit(game);

            return NoContent();
        }

        // POST: api/Game
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<GameDTO> PostGame(GameInputDTO gameInputDTO)
        {
            if (_context.Games == null)
                return Problem("Entity set 'QABBBContext.Games'  is null.");

            Game game = _gameAssembler.toGame(gameInputDTO);
            
            _gameServices.add(game);

            game = _gameServices.findById(game.IdGame)!;

            GameDTO gameDTO = _gameAssembler.toGameDTO(game);

            return CreatedAtAction("GetGame", new { id = gameDTO.IdGame }, gameDTO);
        }

    }
}
