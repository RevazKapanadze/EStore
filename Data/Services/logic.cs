using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using EStore.Data;
using EStore.Data.Models;
using EStore.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EStore.Data.Services
{
  public class logic
  {
    private UserManager<user> _user;
    public logic(UserManager<user> user)
    {
      _user = user;
    }
    public async Task<bool> IsUserAdmin(string userName)
    {
      var user = await _user.FindByNameAsync(userName);
      var role = await _user.GetRolesAsync(user);
      if (role == null)
      {
        return false;
      }
      var isAdmin = role[0] == "Admin";
      return isAdmin;
    }

  }
}