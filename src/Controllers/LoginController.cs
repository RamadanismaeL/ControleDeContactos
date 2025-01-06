using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using controleDeContactos.Models;
using controleDeContactos.src.Models;
using controleDeContactos.src.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
/**
** @author Ramadan Ismael
*/
namespace controleDeContactos.src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IUserRepository _iUserRepository;
        private readonly ILogger<LoginController> _logger;
        private const string keyRam = "2a01df3ae34b5032b7c6ea2e4211e1d8c49effbae7825d76184481658713c16fbae20799648b3f81b2b872e1702ea73b18b5b462fd8d74df21b21e5b50098a55";

        public LoginController(IUserRepository iUserRepository, ILogger<LoginController> logger)
        {
            this._iUserRepository = iUserRepository;
            this._logger = logger;
        }

        public static string GetTokenJWT(UserModel userModel)
        {
            if(userModel.UserName == null) { throw new ArgumentException("User cannot be null", nameof(userModel)); }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyRam));
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, userModel.UserName),
                new Claim(ClaimTypes.Role, "Administrator"),
                new Claim("name", "System Administrator")
            };

            var token = new JwtSecurityToken(
                issuer: "IsmaelBusinessSolution",
                audience: "ContactAndTaskManagementSystem",
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddSeconds(30),
                signingCredentials: credential
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginModel loginModel)
        {
            if(loginModel == null || string.IsNullOrEmpty(loginModel.Username) || string.IsNullOrEmpty(loginModel.Password)) return BadRequest(new { message = "Invalid login request. Please check your input." });
            var user = _iUserRepository.FindByUsername(loginModel.Username);
            if(user == null || !user.VerifyPassword(loginModel.Password)) return Unauthorized(new { message = "Invalid credentials. Please check your username or password." });
            var token = GetTokenJWT(user);
            return Ok(new {token});
        }
    }
}