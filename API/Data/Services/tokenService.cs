using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EStore.API.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace EStore.API.Data.Services
{
  public class tokenService
  {
    private readonly IConfiguration _config;
    private readonly UserManager<user> _user;
    public tokenService(UserManager<user> user, IConfiguration config)
    {
      _user = user;
      _config = config;
    }
    public async Task<string> GenerateToken(user user)
    {
      var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email,user.Email),
            new Claim(ClaimTypes.Name,user.UserName),
        };
      var roles = await _user.GetRolesAsync(user);
      foreach (var role in roles)
      {
        claims.Add(new Claim(ClaimTypes.Role, role));
      }
      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWTSetting:TokenKey"]));
      var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
      var tokenOptions = new JwtSecurityToken(
        issuer: null,
        audience: null,
        claims: claims,
        expires: DateTime.Now.AddDays(3000),
        signingCredentials: creds
      );
      return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
    }
  }
}