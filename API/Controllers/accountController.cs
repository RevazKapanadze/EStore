using System.Threading.Tasks;
using EStore.API.Data.Models;
using EStore.API.Data.Services;
using EStore.API.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using API.Controllers;
using EStore.API.Data;
using Microsoft.EntityFrameworkCore;

namespace EStore.Controllers
{
    public class accountController : baseApiContoller
    {
        private readonly UserManager<user> _user;
        private readonly tokenService _token;
        private readonly AppDbContext _context;

        public accountController(UserManager<user> user, tokenService token, AppDbContext context)
        {
            _context = context;
            _user = user;
            _token = token;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<userVm>> Login(loginVm loginvm)
        {
            var user = await _user.FindByNameAsync(loginvm.Username);
            if (
                user == null
                || !await _user.CheckPasswordAsync(user, loginvm.Password)
                || user.IsActive == 0
            )
                return Unauthorized();
            var userBasket = await Retrievebasket(loginvm.Username);
            var anonBasket = await Retrievebasket(Request.Cookies["buyerId"]);
            if (anonBasket != null)
            {
                if (userBasket != null)
                    _context.BASKETS.Remove(userBasket);
                anonBasket.BuyerId = user.UserName;
                Response.Cookies.Delete("buyerId");
                await _context.SaveChangesAsync();
            }
            return new userVm
            {
                Email = user.Email,
                Token = await _token.GenerateToken(user),
                Basket =
                    anonBasket != null ? anonBasket.MapbasketToVM() : userBasket.MapbasketToVM()
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
            await _user.AddToRoleAsync(user, "Peasant");
            return StatusCode(201);
        }

        [Authorize]
        [HttpGet("get_Current_User")]
        public async Task<ActionResult<userVm>> GetCurrentUser()
        {
            var user = await _user.FindByNameAsync(User.Identity.Name);
            var userBasket = await Retrievebasket(User.Identity.Name);
            return new userVm
            {
                Email = user.Email,
                Token = await _token.GenerateToken(user),
                Basket = userBasket?.MapbasketToVM()
            };
        }

        private async Task<basket> Retrievebasket(string buyerId)
        {
            if (string.IsNullOrEmpty(buyerId))
            {
                Response.Cookies.Delete("buyerId");
                return null;
            }
            return await _context.BASKETS
                .Include(i => i.Items)
                .ThenInclude(p => p.Product)
                .FirstOrDefaultAsync(x => x.BuyerId == buyerId);
        }
    }
}
