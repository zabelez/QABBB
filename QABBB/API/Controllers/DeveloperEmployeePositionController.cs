using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QABBB.API.Assemblers;
using QABBB.API.Models.Company.Employee;
using QABBB.API.Models.Developer.Employee;
using QABBB.Data;
using QABBB.Domain.Services;
using QABBB.Models;

namespace QABBB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperEmployeePositionController : ControllerBase
    {
        private readonly QABBBContext _context;
        private readonly DeveloperEmployeePositionServices _depServices;
        private readonly DeveloperEmployeePositionAssembler _depAssembler;

        public DeveloperEmployeePositionController(QABBBContext context)
        {
            _context = context;
            _depServices = new DeveloperEmployeePositionServices(_context);
            _depAssembler = new DeveloperEmployeePositionAssembler();
        }

        // GET: api/DeveloperEmployeePosition
        [HttpGet]
        public ActionResult GetDeveloperEmployeePositions()
        {
            if (_context.DeveloperEmployeePositions == null)
                return NotFound();

            List<DeveloperEmployeePosition> _depPositions = _depServices.list();

            List<DeveloperEmployeePositionDTO> positionListDTO = _depAssembler.toDeveloperEmployeePositionDTO(_depPositions);

            return Ok(positionListDTO);
        }

        // GET: api/DeveloperEmployeePosition/5
        [HttpGet("{id}")]
        public ActionResult GetDeveloperEmployeePosition(int id)
        {
            if (_context.DeveloperEmployeePositions == null)
                return NotFound();
          
            DeveloperEmployeePosition? _dePosition = _depServices.findById(id);

            if (_dePosition == null)
                return NotFound();
            
            DeveloperEmployeePositionDTO _dePositionDTO = _depAssembler.toDeveloperEmployeePositionDTO(_dePosition);

            return Ok(_dePositionDTO);
        }

        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut()]
        public IActionResult PutDeveloperEmployeePosition(DeveloperEmployeePositionEditInputDTO _depInputDTO)
        {
            DeveloperEmployeePosition? _dePosition = _depServices.findById(_depInputDTO.IdPosition);
            if(_dePosition == null)
                return NotFound();

            _depAssembler.toDeveloperEmployeePosition(_dePosition, _depInputDTO);

            _depServices.edit(_dePosition);

            return NoContent();
        }

        // POST: api/DeveloperEmployeePosition
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult PostDeveloperEmployeePosition(DeveloperEmployeePositionInputDTO developerEmployeePositionInputDTO)
        {
            if (_context.DeveloperEmployeePositions == null)
                return Problem("Entity set 'QABBBContext.DeveloperEmployeePositions'  is null.");

            DeveloperEmployeePosition? _dePosition = _depAssembler.toDeveloperEmployeePosition(developerEmployeePositionInputDTO);

            _depServices.add(_dePosition);

            DeveloperEmployeePositionDTO _depPositionDTO = _depAssembler.toDeveloperEmployeePositionDTO(_dePosition);

            return CreatedAtAction("GetDeveloperEmployeePosition", new { id = _depPositionDTO.IdPosition }, _depPositionDTO);
        }
    }
}
