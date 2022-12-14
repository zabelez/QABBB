using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QABBB.API.Assemblers;
using QABBB.API.Models.Project.TesterUploadedFile;
using QABBB.Data;
using QABBB.Domain.Services;
using QABBB.Models;

namespace QABBB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class TesterUploadedFileController : ControllerBase
    {
        private readonly QABBBContext _context;
        private readonly TesterUploadedFileServices _testeruploadedfileServices;
        private readonly TesterUploadedFileAssembler _testeruploadedfileAssembler;

        public TesterUploadedFileController(QABBBContext context)
        {
            _context = context;
            _testeruploadedfileServices = new TesterUploadedFileServices(_context);
            _testeruploadedfileAssembler = new TesterUploadedFileAssembler();
        }

        // GET: api/TesterUploadedFile
        [HttpGet]
        public ActionResult<List<TesterUploadedFileDTO>> GetTesterUploadedFiles()
        {
            if (_context.TesterUploadedFiles == null)
                return NotFound();

            List<TesterUploadedFile> testeruploadedfiles = _testeruploadedfileServices.list();

            List<TesterUploadedFileDTO> testeruploadedfileDTOs = _testeruploadedfileAssembler.toTesterUploadedFileDTO(testeruploadedfiles);
          
            return Ok(testeruploadedfileDTOs);
        }

        // GET: api/TesterUploadedFile/5
        [HttpGet("{id}")]
        public ActionResult<TesterUploadedFileDTO> GetTesterUploadedFile(int id)
        {
            if (_context.TesterUploadedFiles == null)
                return NotFound();
          
            TesterUploadedFile? testeruploadedfile = _testeruploadedfileServices.findById(id);
            if(testeruploadedfile == null)
                return NotFound();

            TesterUploadedFileDTO testeruploadedfileDTO = _testeruploadedfileAssembler.toTesterUploadedFileDTO(testeruploadedfile);

            return Ok(testeruploadedfileDTO);
        }

        // PUT: api/TesterUploadedFile/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public ActionResult PutTesterUploadedFile(TesterUploadedFileEditDTO testeruploadedfileEditDTO)
        {
            TesterUploadedFile? testeruploadedfile = _testeruploadedfileServices.findById(testeruploadedfileEditDTO.IdTesterUploadedFile);
            if(testeruploadedfile == null)
                return NotFound();

            _testeruploadedfileAssembler.toTesterUploadedFile(testeruploadedfile, testeruploadedfileEditDTO);
            
            _testeruploadedfileServices.edit(testeruploadedfile);
            
            return NoContent();
        }

        // POST: api/TesterUploadedFile
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<TesterUploadedFileDTO> PostTesterUploadedFile(TesterUploadedFileInputDTO testeruploadedfileInputDTO)
        {
            if (_context.TesterUploadedFiles == null)
                return Problem("Entity set 'QABBBContext.TesterUploadedFiles'  is null.");

            TesterUploadedFile testeruploadedfile = _testeruploadedfileAssembler.toTesterUploadedFile(testeruploadedfileInputDTO);

            _testeruploadedfileServices.add(testeruploadedfile);

            TesterUploadedFileDTO testeruploadedfileDTO = _testeruploadedfileAssembler.toTesterUploadedFileDTO(testeruploadedfile);

            return CreatedAtAction("GetTesterUploadedFile", new { id = testeruploadedfileDTO.IdTesterUploadedFile }, testeruploadedfileDTO);
        }

        // DELETE: api/TesterUploadedFile/5
        [HttpDelete("{id}")]
        public ActionResult DeleteTesterUploadedFile(int id)
        {
            if (_context.TesterUploadedFiles == null)
                return NotFound();
            
            TesterUploadedFile? testeruploadedfile = _testeruploadedfileServices.findById(id);
            if(testeruploadedfile == null)
                return NotFound();

            _testeruploadedfileServices.delete(testeruploadedfile);

            return NoContent();
        }
    }
}
