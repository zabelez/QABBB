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
        public async Task<ActionResult<Company>> GetCompany(int id)
        {
          if (_context.Companies == null)
          {
              return NotFound();
          }
            var company = await _context.Companies.FindAsync(id);

            if (company == null)
            {
                return NotFound();
            }

            return company;
        }

        // PUT: api/Company/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompany(int id, Company company)
        {
            if (id != company.IdCompany)
            {
                return BadRequest();
            }

            _context.Entry(company).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Company
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Company>> PostCompany(Company company)
        {
          if (_context.Companies == null)
          {
              return Problem("Entity set 'QABBBContext.Companies'  is null.");
          }
            _context.Companies.Add(company);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompany", new { id = company.IdCompany }, company);
        }

        // // DELETE: api/Company/5
        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteCompany(int id)
        // {
        //     if (_context.Companies == null)
        //     {
        //         return NotFound();
        //     }
        //     var company = await _context.Companies.FindAsync(id);
        //     if (company == null)
        //     {
        //         return NotFound();
        //     }

        //     _context.Companies.Remove(company);
        //     await _context.SaveChangesAsync();

        //     return NoContent();
        // }

        private bool CompanyExists(int id)
        {
            return (_context.Companies?.Any(e => e.IdCompany == id)).GetValueOrDefault();
        }
    }
}
