using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QABBB.API.Assemblers;
using QABBB.API.Models.Admin;
using QABBB.API.Models.User;
using QABBB.Data;
using QABBB.Domain.Services;
using QABBB.Models;

namespace QABBB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        private readonly QABBBContext _context;
        private readonly AdminAssembler _adminAssembler;
        private readonly AdminServices _adminServices;
        private readonly AuthServices _authServices;
        private readonly UserServices _userServices;

        public AdminController(QABBBContext context)
        {
            _context = context;
            _adminAssembler = new AdminAssembler();
            _adminServices = new AdminServices(_context);
            _authServices = new AuthServices(_context);
            _userServices = new UserServices(_context);
        }

        // GET: api/Admin
        [HttpGet]
        public ActionResult GetAdmins()
        {

            if (_context.Admins == null)
            {
                return NotFound();
            }
            
            List<Admin> admins = _adminServices.adminList();

            if(admins == null)
                return NoContent();

            return Ok(_adminAssembler.toAdminDTO(admins));
        }

        // GET: api/Admin/5
        [HttpGet("{id}")]
        public ActionResult GetAdmin(int id)
        {
            if (_context.Admins == null)
            {
                return NotFound();
            }
            var admin = _context.Admins.Find(id);

            if (admin == null)
            {
                return NotFound();
            }

            AdminDTO adminDTO = _adminAssembler.toAdminDTO(admin);

            return Ok(adminDTO);
        }

        //// PUT: api/Admin/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutAdmin(int id, Admin admin)
        //{
        //    if (id != admin.IdAdmin)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(admin).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!AdminExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Admin
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult PostAdmin(AdminINDTO adminINDTO)
        {
            if (_context.Admins == null)
                return Problem("Entity set 'QABBBContext.Admins'  is null.");

            // VALIDATION
            Admin? userAdmin = _adminServices.findByIdUser(adminINDTO.IdPerson);
            if(userAdmin != null)
                return BadRequest("User already admin.");

            // USER
            User? user = _userServices.findById(adminINDTO.IdPerson);
            if (user == null)
                return BadRequest("IdPerson incorrect.");

            // CREATED BY
            string? idPerson = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if(idPerson == null)
                return Unauthorized();

            Admin admin = _adminAssembler.toAdmin(adminINDTO, user);

            _adminServices.add(admin, int.Parse(idPerson));

            Admin? newAdmin = _adminServices.findById(admin.IdAdmin);
            if(newAdmin == null)
                return Problem();

            AdminDTO? adminDTO = _adminAssembler.toAdminDTO(newAdmin);
            if(adminDTO == null)
                return Problem();

            return CreatedAtAction("GetAdmin", new { id = adminDTO.IdAdmin }, adminDTO);
        }

        // DELETE: api/Admin/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAdmin(int id)
        {
           if (_context.Admins == null)
           {
               return NotFound();
           }
           Admin? admin = _adminServices.findById(id, "Active");
           if (admin == null)
           {
               return NotFound();
           }

           string? idPerson = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if(idPerson == null)
                return Unauthorized();

           _adminServices.inactivate(admin, int.Parse(idPerson));

           return NoContent();
        }

        private bool AdminExists(int id)
        {
            return (_context.Admins?.Any(e => e.IdAdmin == id)).GetValueOrDefault();
        }
    }
}
