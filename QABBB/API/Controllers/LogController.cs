namespace QABBB.API.Controllers
{
    // [Route("api/[controller]")]
    // [ApiController]
    // [Authorize(Roles = "Admin")]
    // public class LogController : ControllerBase
    // {
    //     private readonly QABBBContext _context;
    //     private readonly LogServices _logServices;
    //     private readonly LogAssembler _logAssembler;

    //     public LogController(QABBBContext context)
    //     {
    //         _context = context;
    //         _logServices = new LogServices(_context);
    //         _logAssembler = new LogAssembler();
    //     }

    //     // GET: api/Log/5
    //     [HttpGet("{idUser}")]
    //     public ActionResult<List<LogDTO>> GetLog(int idUser)
    //     {
    //       if (_context.Logs == null)
    //           return NotFound();

    //         var log = _logServices.findByIdUser(idUser);

    //         if (log == null)
    //             return NotFound();

    //         List<LogDTO>? logDTO = _logAssembler.toLogDTO(log);

    //         return Ok(logDTO);
    //     }
    // }
}
