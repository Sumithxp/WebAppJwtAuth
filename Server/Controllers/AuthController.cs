using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    // GET api/values
    [HttpPost, Route("login")]
    public IActionResult Login([FromBody] LoginModel user)
    {
        // if (user == null)
        // {
        //     return BadRequest("Invalid client request");
        // }

        //var user = new LoginModel();
        //user.UserName = "johndoe";
        //user.Password = "def@123";

        if (user.UserName == "johndoe" && user.Password == "pass@123")
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SymmetricSecurityKey@123"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokeOptions = new JwtSecurityToken(
                issuer: "https://localhost:4300",
                audience: "https://localhost:4300",
                claims: new List<Claim>(),
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: signinCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return Ok(new { Token = tokenString });
        }
        else
        {
            return Unauthorized();
        }
    }
}