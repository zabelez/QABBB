using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using QABBB.API.Assemblers;
using QABBB.API.Models.User;
using QABBB.Data;
using QABBB.Domain.Services;
using QABBB.Models;

namespace QABBB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly QABBBContext _context;
        private readonly UserAssembler _userAssembler;
        private readonly AuthServices _authServices;
        private readonly AdminServices _adminServices;
        private readonly UserServices _userServices;
        private readonly LogServices _logServices;

        public AuthController(QABBBContext context) {
            _context = context;
            _userAssembler = new UserAssembler();
            _authServices = new AuthServices(_context);
            _userServices = new UserServices(_context);
            _adminServices = new AdminServices(_context);
            _logServices = new LogServices(_context);
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] LoginINDTO inLoginDTO)
        {
            User? user = _userServices.login(inLoginDTO.Email, inLoginDTO.Password);

            if (user == null)
                return NotFound();

            if (user.IsPasswordResetRequired)
                return Unauthorized("Password change required");

            LoginOUTDTO userDTO = _userAssembler.toLoginOUTDTO(user, _authServices.BuildToken(user));
            userDTO.Roles = _authServices.getClaims(user);


            string? ipAddress = Request.HttpContext.Connection.RemoteIpAddress?.ToString();

            _logServices.add(ipAddress, user.IdPerson);

            return Ok(userDTO);

        }

        [HttpPost]
        [Route("resetPasswordRequired")]
        public IActionResult ResetPassword([FromBody] ResetPasswordRequiredDTO resetPasswordRequiredDTO)
        {
            User? user =  _userServices.login(resetPasswordRequiredDTO.UserName, resetPasswordRequiredDTO.OldPassword);

            if (user == null)
                return NotFound();

            if (!user.IsPasswordResetRequired)
                return NotFound();

            _userServices.resetPassword(user, resetPasswordRequiredDTO.NewPassword);

            LoginOUTDTO userDTO = _userAssembler.toLoginOUTDTO(user, _authServices.BuildToken(user));

            return Ok(userDTO);
        }
    }
}

