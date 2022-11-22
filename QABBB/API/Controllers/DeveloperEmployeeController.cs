using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QABBB.API.Assemblers;
using QABBB.API.Models.Developer.Employee;
using QABBB.Data;
using QABBB.Domain.Services;
using QABBB.Models;

namespace QABBB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperEmployeeController : ControllerBase
    {
        private readonly QABBBContext _context;
        private readonly DeveloperEmployeeServices _deServices;
        private readonly DeveloperEmployeeAssembler _deAssembler;

        public DeveloperEmployeeController(QABBBContext context)
        {
            _context = context;
            _deServices = new DeveloperEmployeeServices(_context);
            _deAssembler = new DeveloperEmployeeAssembler();
        }

        // GET: api/DeveloperEmployee
        [HttpGet]
        public ActionResult GetDeveloperEmployees()
        {
            if (_context.DeveloperEmployees == null)
                return NotFound();

            List<DeveloperEmployee> _developerEmployees = _deServices.list();

            List<DeveloperEmployeeDTO> _developerEmployeeDTOs = _deAssembler.toDeveloperEmployeeDTO(_developerEmployees);
          
            return Ok(_developerEmployeeDTOs);
        }

        // GET: api/DeveloperEmployee/5
        [HttpGet("{id}")]
        public ActionResult GetDeveloperEmployee(int id)
        {
            if (_context.DeveloperEmployees == null)
                return NotFound();
          
            DeveloperEmployee? developerEmployee = _deServices.findById(id);

            if (developerEmployee == null)
                return NotFound();

            return Ok(_deAssembler.toDeveloperEmployeeDTO(developerEmployee));
        }

        // PUT: api/DeveloperEmployee/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutDeveloperEmployee(int id, DeveloperEmployeeEditInputDTO developerEmployeeEditInputDTO)
        {
            DeveloperEmployee? _developerEmployee = _deServices.findById(developerEmployeeEditInputDTO.IdDeveloperEmployee);
            if(_developerEmployee == null)
                return NotFound();

            _deAssembler.toDeveloperEmployee(_developerEmployee, developerEmployeeEditInputDTO);

            _deServices.edit(_developerEmployee);

            return NoContent();
        }

        // POST: api/DeveloperEmployee
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult PostDeveloperEmployee(DeveloperEmployeeInputDTO developerEmployeeInputDTO)
        {
            if (_context.DeveloperEmployees == null)
                return Problem("Entity set 'QABBBContext.DeveloperEmployees'  is null.");

            DeveloperEmployee _developerEmployee = _deAssembler.toDeveloperEmployee(developerEmployeeInputDTO);
            
            _deServices.add(_developerEmployee);

            DeveloperEmployeeDTO _developerEmployeeDTO = _deAssembler.toDeveloperEmployeeDTO(_developerEmployee);

            return CreatedAtAction("GetDeveloperEmployee", new { id = _developerEmployeeDTO.IdDeveloperEmployee }, _developerEmployeeDTO);
        }

        // // DELETE: api/DeveloperEmployee/5
        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteDeveloperEmployee(int id)
        // {
        //     if (_context.DeveloperEmployees == null)
        //     {
        //         return NotFound();
        //     }
        //     var developerEmployee = await _context.DeveloperEmployees.FindAsync(id);
        //     if (developerEmployee == null)
        //     {
        //         return NotFound();
        //     }

        //     _context.DeveloperEmployees.Remove(developerEmployee);
        //     await _context.SaveChangesAsync();

        //     return NoContent();
        // }

        // private bool DeveloperEmployeeExists(int id)
        // {
        //     return (_context.DeveloperEmployees?.Any(e => e.IdDeveloperEmployee == id)).GetValueOrDefault();
        // }
    }
}
