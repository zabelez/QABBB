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
using QABBB.Data;
using QABBB.Domain.Services;
using QABBB.Models;

namespace QABBB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class CompanyEmployeeController : ControllerBase
    {
        private readonly QABBBContext _context;
        private readonly CompanyEmployeeServices _ceServices;
        private readonly CompanyEmployeeAssembler _ceAssembler;

        public CompanyEmployeeController(QABBBContext context)
        {
            _context = context;
            _ceServices = new CompanyEmployeeServices(_context);
            _ceAssembler = new CompanyEmployeeAssembler();
        }

        // GET: api/CompanyEmployee
        [HttpGet]
        public ActionResult GetCompanyEmployees()
        {
            if (_context.CompanyEmployees == null)
                return NotFound();

            List<CompanyEmployee> _companyEmployees = _ceServices.list();

            List<CompanyEmployeeDTO> _companyEmployeeDTOs = _ceAssembler.toCompanyEmployeeDTO(_companyEmployees);
          
            return Ok(_companyEmployeeDTOs);
        }

        // GET: api/CompanyEmployee/5
        [HttpGet("{id}")]
        public ActionResult GetCompanyEmployee(int id)
        {
            if (_context.CompanyEmployees == null)
                return NotFound();
          
            CompanyEmployee? companyEmployee = _ceServices.findById(id);

            if (companyEmployee == null)
                return NotFound();

            return Ok(_ceAssembler.toCompanyEmployeeDTO(companyEmployee));
        }

        // PUT: api/CompanyEmployee/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public IActionResult PutChangePosition(CompanyEmployeeEditInputDTO companyEmployeeEditInputDTO)
        {
            CompanyEmployee? _companyEmployee = _ceServices.findById(companyEmployeeEditInputDTO.IdCompanyEmployee);
            if (_companyEmployee == null)
                return NotFound();

            string? idPerson = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (idPerson == null)
                return Unauthorized();

            _ceServices.inactivate(_companyEmployee, int.Parse(idPerson));

            CompanyEmployeeInputDTO companyEmployeeInputDTO = new CompanyEmployeeInputDTO();
            companyEmployeeInputDTO.IdPerson = _companyEmployee.IdPerson;
            companyEmployeeInputDTO.IdCompany = _companyEmployee.IdCompany;
            companyEmployeeInputDTO.IdCompanyEmployeePosition = companyEmployeeEditInputDTO.IdPosition;

            return PostCompanyEmployee(companyEmployeeInputDTO);

        }

        // POST: api/CompanyEmployee
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult PostCompanyEmployee(CompanyEmployeeInputDTO developerEmployeeInputDTO)
        {
            if (_context.CompanyEmployees == null)
                return Problem("Entity set 'QABBBContext.CompanyEmployees'  is null.");

            CompanyEmployee _developerEmployee = _ceAssembler.toCompanyEmployee(developerEmployeeInputDTO);

            string? idPerson = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (idPerson == null)
                return Unauthorized();

            _ceServices.add(_developerEmployee, int.Parse(idPerson));

            _developerEmployee = _ceServices.findById(_developerEmployee.IdCompanyEmployee);

            CompanyEmployeeDTO _developerEmployeeDTO = _ceAssembler.toCompanyEmployeeDTO(_developerEmployee);

            return CreatedAtAction("GetCompanyEmployee", new { id = _developerEmployeeDTO.IdCompanyEmployee }, _developerEmployeeDTO);
        }

        // DELETE: api/CompanyEmployee/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCompanyEmployee(int id)
        {
            CompanyEmployee? _companyEmployee = _ceServices.findById(id);
            if (_companyEmployee == null)
                return NotFound();

            string? idPerson = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (idPerson == null)
                return Unauthorized();

            _ceServices.inactivate(_companyEmployee, int.Parse(idPerson));

            return NoContent();
        }
    }
}
