using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QABBB.API.Assemblers;
using QABBB.API.Models.Company.Employee;
using QABBB.API.Models.Company.Employee.Position;
using QABBB.Data;
using QABBB.Domain.Services;
using QABBB.Models;

namespace QABBB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class CompanyEmployeePositionController : ControllerBase
    {
        private readonly QABBBContext _context;
        private readonly CompanyEmployeePositionServices _cepServices;
        private readonly CompanyEmployeePositionAssembler _cepAssembler;

        public CompanyEmployeePositionController(QABBBContext context)
        {
            _context = context;
            _cepServices = new CompanyEmployeePositionServices(_context);
            _cepAssembler = new CompanyEmployeePositionAssembler();
        }

        // GET: api/CompanyEmployee
        [HttpGet]
        public ActionResult<List<CompanyEmployeePositionDTO>> GetCompanyEmployeePositions()
        {
            if (_context.CompanyEmployeePositions == null)
                return NotFound();

            List<CompanyEmployeePosition> _companyEmployeePositions = _cepServices.list();

            List<CompanyEmployeePositionDTO> _companyEmployeePositionDTOs = _cepAssembler.toCompanyEmployeePositionDTO(_companyEmployeePositions);
          
            return Ok(_companyEmployeePositionDTOs);
        }

        // // GET: api/CompanyEmployee/5
        // [HttpGet("{id}")]
        // public ActionResult GetCompanyEmployee(int id)
        // {
        //     if (_context.CompanyEmployees == null)
        //         return NotFound();
          
        //     CompanyEmployee? companyEmployee = _cepServices.findById(id);

        //     if (companyEmployee == null)
        //         return NotFound();

        //     return Ok(_cepAssembler.toCompanyEmployeeDTO(companyEmployee));
        // }

        // // PUT: api/CompanyEmployee/5
        // // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPut]
        // public IActionResult PutChangePosition(CompanyEmployeeEditInputDTO companyEmployeeEditInputDTO)
        // {
        //     CompanyEmployee? _companyEmployee = _cepServices.findById(companyEmployeeEditInputDTO.IdCompanyEmployee);
        //     if (_companyEmployee == null)
        //         return NotFound();

        //     string? idPerson = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        //     if (idPerson == null)
        //         return Unauthorized();

        //     _cepServices.inactivate(_companyEmployee, int.Parse(idPerson));

        //     CompanyEmployeeInputDTO companyEmployeeInputDTO = new CompanyEmployeeInputDTO();
        //     companyEmployeeInputDTO.IdPerson = _companyEmployee.IdPerson;
        //     companyEmployeeInputDTO.IdCompany = _companyEmployee.IdCompany;
        //     companyEmployeeInputDTO.IdPosition = companyEmployeeEditInputDTO.IdPosition;

        //     return PostCompanyEmployee(companyEmployeeInputDTO);

        // }

        // // POST: api/CompanyEmployee
        // // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPost]
        // public ActionResult PostCompanyEmployee(CompanyEmployeeInputDTO developerEmployeeInputDTO)
        // {
        //     if (_context.CompanyEmployees == null)
        //         return Problem("Entity set 'QABBBContext.CompanyEmployees'  is null.");

        //     CompanyEmployee _developerEmployee = _cepAssembler.toCompanyEmployee(developerEmployeeInputDTO);

        //     string? idPerson = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        //     if (idPerson == null)
        //         return Unauthorized();

        //     _cepServices.add(_developerEmployee, int.Parse(idPerson));

        //     _developerEmployee = _cepServices.findById(_developerEmployee.IdCompanyEmployee);

        //     CompanyEmployeeDTO _developerEmployeeDTO = _cepAssembler.toCompanyEmployeeDTO(_developerEmployee);

        //     return CreatedAtAction("GetCompanyEmployee", new { id = _developerEmployeeDTO.IdCompanyEmployee }, _developerEmployeeDTO);
        // }

        // // DELETE: api/CompanyEmployee/5
        // [HttpDelete("{id}")]
        // public IActionResult DeleteCompanyEmployee(int id)
        // {
        //     CompanyEmployee? _companyEmployee = _cepServices.findById(id);
        //     if (_companyEmployee == null)
        //         return NotFound();

        //     string? idPerson = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        //     if (idPerson == null)
        //         return Unauthorized();

        //     _cepServices.inactivate(_companyEmployee, int.Parse(idPerson));

        //     return NoContent();
        // }
    }
}
