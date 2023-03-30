using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QABBB.API.Assemblers;
using QABBB.API.Models.User;
using QABBB.Data;
using QABBB.Domain.Services;
using QABBB.Models;

namespace QABBB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly QABBBContext _context;
        private readonly UserAssembler _userAssembler;
        private readonly UserServices _userServices;
        private readonly AdminServices _adminServices;
        private readonly AuthServices _authServices;

        public UserController(QABBBContext context)
        {
            _context = context;
            _userAssembler = new UserAssembler();
            _authServices = new AuthServices(_context);
            _adminServices = new AdminServices(_context);
            _userServices = new UserServices(_context);
        }

        // GET: api/User
        [HttpGet]
        public ActionResult<List<UserDTO>> GetUsers()
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            List<User> users =  _userServices.userList();

            List<UserDTO> userDTOs = _userAssembler.toUserDTO(users);

            userDTOs.ForEach(user =>{
                user.Roles = _authServices.getClaims(user);
            });

            return Ok(userDTOs);
        }

        // GET: api/User/5x
        [HttpGet("{id}")]
        public ActionResult<UserPlatformsEmployeeDTO> GetUser(int id)
        {
          if (_context.Users == null)
              return NotFound();

            User? user = _userServices.findById(id);

            if (user == null)
                return NotFound();

            return _userAssembler.toUserAndPlatformsDTO(user);
        }

        [HttpPost("resetPassword")]
        public ActionResult ResetPassword([FromBody] ResetPasswordDTO resetPasswordDTO)
        {
            string? idPerson = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if(idPerson == null)
                return Unauthorized();

            User? user = _userServices.findById(int.Parse(idPerson));

            if (user == null)
                return NotFound();

            if (user.Password != resetPasswordDTO.OldPassword)
                return NotFound("Incorrect Old Password. Try again.");

            _userServices.resetPassword(user, resetPasswordDTO.NewPassword!);

            return NoContent();

        }

        [HttpPost("inactivate/{id}")]
        public ActionResult Inactivate(int id)
        {
            User? user = _userServices.findById(id);

            if (user == null)
                return NotFound();

            string? idPerson = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if(idPerson == null)
                return Unauthorized();

            _userServices.inactivate(user);

            Admin? admin = _adminServices.findByIdUser(id);
            if(admin != null)
                _adminServices.inactivate(admin, int.Parse(idPerson));

            return NoContent();

        }

        

        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut()]
        public ActionResult PutUser(EditUserDTO editUserDTO)
        {
            CompanyEmployeeServices ceServices = new CompanyEmployeeServices(_context);

            User? user = _userServices.findById(editUserDTO.IdPerson);
            if(user == null)
                return NotFound();

            string? idPerson = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (idPerson == null)
                return Unauthorized();

            using var transaction = _context.Database.BeginTransaction();

            foreach (CompanyEmployee companyEmployee in user.CompanyEmployeeIdPersonNavigations)
            {
                if (!editUserDTO.employers.Exists(x => x.IdCompanyEmployee == companyEmployee.IdCompanyEmployee))
                    ceServices.inactivate(companyEmployee, int.Parse(idPerson));
            }

            _userAssembler.toUser(user, editUserDTO, int.Parse(idPerson));

            _userServices.edit(user);

            transaction.Commit();

            return NoContent();
        }

        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult<UserDTO> PostUser(NewUserDTO user) {
            
            using var transaction = _context.Database.BeginTransaction();

            if (_context.Users == null)
                return Problem("Entity set 'QABBBContext.Users'  is null.");

            List<string> error = _userServices.newUserValidation(user);
            if (error.Count > 0)
                return BadRequest(error);

            string? idPerson = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (idPerson == null)
                return Unauthorized();

            User newUser = _userAssembler.toUser(user, int.Parse(idPerson));

            _userServices.add(newUser);

            foreach (String role in user.roles){
                switch (role){
                    case "Admin":
                        _adminServices.add(newUser, int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value));
                        break;
                    
                    default:
                        transaction.Rollback();
                        return BadRequest($"Role {role} is not valid.");
                }
            }


            transaction.Commit();

            UserPlatformsEmployeeDTO userDTO = _userAssembler.toUserAndPlatformsDTO(_userServices.findById(newUser.IdPerson));
            userDTO.Roles = _authServices.getClaims(newUser);

            return CreatedAtAction("GetUser", new { id = userDTO.IdPerson }, userDTO);

        }
    }
}
