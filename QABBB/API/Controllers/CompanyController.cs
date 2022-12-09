using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public ActionResult GetCompanies()
        {
            if (_context.Companies == null)
                return NotFound();

            List<Company>? _companies = _companyServices.list();

            List<CompanyDTO> _companiesDTO = _companyAssembler.toCompanyDTO(_companies);

            return Ok(_companiesDTO);
        }

        // GET: api/Company/5
        [HttpGet("{id}")]
        public ActionResult GetCompany(int id)
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
        public IActionResult PutUser(CompanyEditInputDTO companyEditInputDTO)
        {
            Company? company = _companyServices.findById(companyEditInputDTO.IdCompany);
            if(company == null)
                return NotFound();

            _companyAssembler.toCompany(company, companyEditInputDTO);

            _companyServices.edit(company);

            return NoContent();
        }

        // POST: api/Company
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult PostCompany(CompanyInputDTO companyInputDTO)
        {
            if (_context.Companies == null)
                return Problem("Entity set 'QABBBContext.Companies'  is null.");

            Company company = _companyAssembler.toCompany(companyInputDTO);
            
            _companyServices.add(company);

            CompanyDTO companyDTO = _companyAssembler.toCompanyDTO(company);

            return CreatedAtAction("GetCompany", new { id = companyDTO.IdCompany }, companyDTO);
        }

    }
}
