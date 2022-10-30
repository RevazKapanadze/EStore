using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using EStore.Data;
using EStore.Data.Models;
using EStore.Data.Services;
using EStore.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Extensions.Logging;

namespace EStore.Controllers
{
  [ApiController]
  public class adminController : ControllerBase
  {
    private AppDbContext _context;
    private UserManager<user> _user;
    private logic _logic;
    public adminController(AppDbContext context, UserManager<user> user, logic logic)
    {
      _context = context;
      _user = user;
      _logic = logic;
    }
    [Authorize]
    [HttpPost("Add_Main_Category")]
    public async Task<ActionResult> AddMainCategory(mainCategoryVm _main)
    {
      var role = await _logic.IsUserAdmin(User.Identity.Name);
      if (role)
      {
        var _mainCategory = new mainCategory
        {
          Name = _main.Name,
          Description = _main.Description
        };
        await _context.MAINCATEGORY.AddAsync(_mainCategory);
        await _context.SaveChangesAsync();
        return Ok(_mainCategory);
      }
      else
      {
        return Unauthorized("ur not an admin");
      }
    }
    [Authorize]
    [HttpPost("Add_Category")]
    public async Task<ActionResult> AddCategory(categoryVm _main)
    {
      var role = await _logic.IsUserAdmin(User.Identity.Name);
      if (role)
      {
        var _category = new category
        {
          Name = _main.Name,
          Description = _main.Description,
          mainCategory_Id = _main.mainCategory_Id
        };
        await _context.AddAsync(_category);
        await _context.SaveChangesAsync();
        return Ok(_category);
      }
      else
      {
        return Unauthorized("ur not an admin");
      }
    }
    [Authorize]
    [HttpPost("Add_Company")]
    public async Task<ActionResult> AddCompany(companyVm _company)
    {
      var role = await _logic.IsUserAdmin(User.Identity.Name);
      if (role)
      {
        var _newcompany = new company
        {
          Name = _company.Name,
          Details = _company.Details,
          Company_Logo = _company.Company_Logo
        };
        await _context.AddAsync(_newcompany);
        await _context.SaveChangesAsync();
        return Ok(_newcompany);
      }
      else
      {
        return Unauthorized("ur not an admin");
      }
    }

    [Authorize]
    [HttpGet("Users_Not_Active")]
    public async Task<ActionResult> UsersNotActive()
    {
      var role = await _logic.IsUserAdmin(User.Identity.Name);
      if (role)
      {
        var users = await _context.ASPNETUSERS.Where(o => o.IsActive == 0 || o.Company_Id == 1).ToListAsync();
        var usersVm = users.Select(o => new { o.Email, o.User_Id, o.IsActive, o.Company_Id, o.UserName }).ToList();
        return Ok(usersVm);
      }
      else
      {
        return Unauthorized("ur not an admin");
      }
    }
    [Authorize]
    [HttpPut("Activate_User/{user_Id}")]
    public async Task<ActionResult> ActivateUser(int user_Id)
    {

      var role = await _logic.IsUserAdmin(User.Identity.Name);
      if (role)
      {
        var user = await _context.ASPNETUSERS.Where(o => o.User_Id == user_Id).FirstOrDefaultAsync();
        user.IsActive = 1;
        await _context.SaveChangesAsync();
        return Ok();
      }
      else
      {
        return Unauthorized("ur not an admin");
      }
    }
    [Authorize]
    [HttpPut("Deactivate_User/{user_Id}")]
    public async Task<ActionResult> Deactivate_User(int user_Id)
    {
      var role = await _logic.IsUserAdmin(User.Identity.Name);
      if (role)
      {
        var user = await _context.ASPNETUSERS.Where(o => o.User_Id == user_Id).FirstOrDefaultAsync();
        user.IsActive = 0;
        await _context.SaveChangesAsync();
        return Ok();
      }
      else
      {
        return Unauthorized("ur not an admin");
      }
    }
    [Authorize]
    [HttpPut("Assign_Company/{user_Id}/{company_Id}")]
    public async Task<ActionResult> AssignCompany(int user_Id, int company_Id)
    {
      var role = await _logic.IsUserAdmin(User.Identity.Name);
      if (role)
      {
        var user = await _context.ASPNETUSERS.Where(o => o.User_Id == user_Id).FirstOrDefaultAsync();
        user.Company_Id = company_Id;
        await _context.SaveChangesAsync();
        return Ok("Success");
      }
      else
      {
        return Unauthorized("ur not an admin");
      }
    }

  }
}