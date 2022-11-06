using System.Threading.Tasks;
using EStore.Data.Models;
using EStore.Data.Services;
using EStore.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EStore.Controllers
{
  public class accountController : ControllerBase
  {
    private readonly UserManager<user> _user;
    private readonly tokenService _token;
    public accountController(UserManager<user> user, tokenService token)
    {
      _user = user;
      _token = token;
    }
    [HttpPost("Login")]
    public async Task<ActionResult<userVm>> Login(loginVm loginvm)
    {
      var user = await _user.FindByNameAsync(loginvm.Username);
      if (user == null || !await _user.CheckPasswordAsync(user, loginvm.Password))
        return Unauthorized();
      return new userVm
      {
        Email = user.Email,
        Token = await _token.GenerateToken(user)
      };
    }
    [HttpPost("register_User")]
    public async Task<ActionResult> Register(registerVm _registerVm)
    {
      var user = new user
      {
        UserName = _registerVm.Username,
        Email = _registerVm.Email,
        IsActive = 0,
        Company_Id = 1
      };
      var result = await _user.CreateAsync(user, _registerVm.Password);
      if (!result.Succeeded)
      {
        foreach (var error in result.Errors)
        {
          ModelState.AddModelError(error.Code, error.Description);
        }
        return ValidationProblem();
      }
      await _user.AddToRoleAsync(user, "User");
      return StatusCode(201);
    }
    [Authorize]
    [HttpGet("get_Current_User")]
    public async Task<ActionResult<userVm>> GetCurrentUser()
    {
      var user = await _user.FindByNameAsync(User.Identity.Name);
      return new userVm
      {
        Email = user.Email,
        Token = await _token.GenerateToken(user)
      };
    }
  }
}