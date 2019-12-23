using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Dto.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace MailSenderExample.Controllers
{
    [Route("token")]
    [AllowAnonymous()]
    public class TokenController : Controller
    {
        [HttpPost("[action]")]
        //https://localhost:44368/token/GetToken
        public IActionResult GetToken([FromBody]UserInfo user)
        {
            if (IsValidUserAndPassword(user.Username, user.Password))
                return new ObjectResult(GenerateToken(user.Username));

            return Unauthorized();
        }

        private string GenerateToken(string userName)
        {
            var someClaims = new Claim[]{
                new Claim(JwtRegisteredClaimNames.UniqueName,userName),
                new Claim(JwtRegisteredClaimNames.Email,"test@testmail.com"),
                new Claim(JwtRegisteredClaimNames.NameId,Guid.NewGuid().ToString())
            };

            SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("!temp_@security_*key_<>225588_^lorem_-ipsum"));
            var token = new JwtSecurityToken(
                issuer: "admin-",
                audience: "admin",
                claims: someClaims,
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private bool IsValidUserAndPassword(string userName, string password)
        {
            //todo: check user credentials on sql
            return userName == "admin" && password == "tempPassword";
        }
    }
}
