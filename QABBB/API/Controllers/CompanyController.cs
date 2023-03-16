using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QABBB.API.Assemblers;
using QABBB.API.Models.Company;
using QABBB.Data;
using QABBB.Domain.Services;
using QABBB.Models;

namespace QABBB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class CompanyController : ControllerBase
    {
        private readonly QABBBContext _context;
        private readonly CompanyServices _companyServices;
        private readonly CompanyAssembler _companyAssembler;

        public CompanyController(QABBBContext context)
        {
            _context = context;
            _companyServices = new CompanyServices(_context);
            _companyAssembler = new CompanyAssembler();
        }

        // GET: api/Company
        [HttpGet]
        public ActionResult<List<CompanyDTO>> GetCompanies()
        {
            if (_context.Companies == null)
                return NotFound();

            List<Company>? _companies = _companyServices.list();

            List<CompanyDTO> _companiesDTO = _companyAssembler.toCompanyDTO(_companies);

            return Ok(_companiesDTO);
        }

        // GET: api/Company/5
        [HttpGet("{id}")]
        public ActionResult<CompanyDTO> GetCompany(int id)
        {
          if (_context.Companies == null)
              return NotFound();

            var company = _companyServices.findById(id);

            if (company == null)
                return NotFound();

            CompanyDTO companyDTO = _companyAssembler.toCompanyDTO(company);

            return Ok(companyDTO);
        }

        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public ActionResult PutUser(CompanyEditInputDTO companyEditInputDTO)
        {
            CompanyEmployeeServices ceServices = new CompanyEmployeeServices(_context);

            Company? company = _companyServices.findById(companyEditInputDTO.IdCompany);
            if(company == null)
                return NotFound();

            string? idPerson = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (idPerson == null)
                return Unauthorized();

            using var transaction = _context.Database.BeginTransaction();

            foreach (CompanyEmployee companyEmployee in company.CompanyEmployees)
            {
                if (!companyEditInputDTO.employees.Exists(x => x.IdCompanyEmployee == companyEmployee.IdCompanyEmployee))
                    ceServices.inactivate(companyEmployee, int.Parse(idPerson));
            }

            _companyAssembler.toCompany(company, companyEditInputDTO, int.Parse(idPerson));

            _companyServices.edit(company);

            transaction.Commit();

            return NoContent();
        }

        // POST: api/Company
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<CompanyDTO> PostCompany(CompanyInputDTO companyInputDTO)
        {
            if (_context.Companies == null)
                return Problem("Entity set 'QABBBContext.Companies'  is null.");

            string? idPerson = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (idPerson == null)
                return Unauthorized();

            Company company = _companyAssembler.toCompany(companyInputDTO, int.Parse(idPerson));
            
            _companyServices.add(company);

            company = _companyServices.findById(company.IdCompany);
            CompanyDTO companyDTO = _companyAssembler.toCompanyDTO(company);

            return CreatedAtAction("GetCompany", new { id = companyDTO.IdCompany }, companyDTO);
        }

    }
}
