using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Core;
using Core.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("/api/Login")]
        public IActionResult Login(User user)
        {
            using (var unitOfWork = new UnitOfWork(new StoreDBContext()))
            {
                var loggedInUser = unitOfWork.User.IsValidUser(user);
              
                if (loggedInUser == null)
                {
                    return Unauthorized();
                }
                user.Role = loggedInUser.Role;
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };
            var token = new JwtSecurityToken
         (
             issuer: _configuration["Issuer"],
             audience: _configuration["Audience"],
             claims: claims,
             expires: DateTime.UtcNow.AddDays(60),
             notBefore: DateTime.UtcNow,
             signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SigningKey"])),
                     SecurityAlgorithms.HmacSha256)
         );
           user.Token = new JwtSecurityTokenHandler().WriteToken(token);
            user.Password = string.Empty;
            return Ok(user);

        }


    }
}