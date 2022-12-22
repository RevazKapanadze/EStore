using System;
using System.Linq;
using System.Threading.Tasks;
using EStore.API.Data;
using EStore.API.Data.Models;
using EStore.API.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;

namespace API.Controllers
{
    public class basketController : baseApiContoller
    {
        private readonly AppDbContext _context;

        public basketController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetBasket")]
        public async Task<ActionResult<basketVM>> GetBasket()
        {
            var basket = await Retrievebasket(GetBuyerId());

            if (basket == null)
                return NotFound();

            return basket.MapbasketToVM();
        }

        [HttpPost("AddItemTobasket")]
        public async Task<ActionResult<basketVM>> AddItemTobasket(long productId, int quantity)
        {
            var basket = await Retrievebasket(GetBuyerId());

            if (basket == null)
                basket = Createbasket();

            var product = await _context.ITEMS.FindAsync(productId);

            if (product == null)
                return NotFound();

            basket.AddItem(product, quantity);

            var result = await _context.SaveChangesAsync() > 0;

            if (result)
                return CreatedAtAction("Getbasket", basket.MapbasketToVM());

            return BadRequest(new ProblemDetails { Title = "Problem saving item to basket" });
        }

        [HttpDelete("RemovebasketItem")]
        public async Task<ActionResult> RemovebasketItem(int productId, int quantity)
        {
            var basket = await Retrievebasket(GetBuyerId());

            if (basket == null)
                return NotFound();

            basket.RemoveItem(productId, quantity);

            var result = await _context.SaveChangesAsync() > 0;

            if (result)
                return Ok();

            return BadRequest(
                new ProblemDetails { Title = "Problem removing item from the basket" }
            );
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

        private string GetBuyerId()
        {
            return User.Identity?.Name ?? Request.Cookies["buyerId"];
        }

        private basket Createbasket()
        {
            var buyerId = User?.Identity.Name;
            if (string.IsNullOrEmpty(buyerId))
            {
                buyerId = Guid.NewGuid().ToString();
                var cookieOptions = new CookieOptions
                {
                    IsEssential = true,
                    Expires = DateTime.Now.AddDays(30)
                };
                Response.Cookies.Append("buyerId", buyerId, cookieOptions);
            }
            var basket = new basket { BuyerId = buyerId };
            _context.BASKETS.Add(basket);
            return basket;
        }
    }
}
