using EStore.API.Data.Models;
using EStore.API.Data.Services;
using Microsoft.AspNetCore.Identity;
using API.Controllers;
using EStore.API.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using API.Data.ViewModels;
using Microsoft.AspNetCore.Components.Web;
using API.Data.Models.OrderAgregate;
using API.Extentions;

[Authorize]
public class ordersController : baseApiContoller
{
    private readonly UserManager<user> _user;
    private readonly tokenService _token;
    private readonly AppDbContext _context;

    public ordersController(UserManager<user> user, tokenService token, AppDbContext context)
    {
        _context = context;
        _user = user;
        _token = token;
    }

    [HttpGet]
    public async Task<ActionResult<List<orderVm>>> GetOrders()
    {
        return await _context.ORDERS
            .projectOrderToOrderVm()
            .Where(x => x.BuyerId == User.Identity.Name)
            .ToListAsync();
    }

    [HttpGet("{id}", Name = "GetOrder")]
    public async Task<ActionResult<orderVm>> GetOrder(int id)
    {
        return await _context.ORDERS
            .projectOrderToOrderVm()
            .Where(x => x.BuyerId == User.Identity.Name && x.Id == id)
            .FirstOrDefaultAsync();
    }

    [HttpPost]
    public async Task<ActionResult<order>> CreateOrder(createOrderVm ordervm)
    {
        var basket = await _context.BASKETS
            .RetriveBasketWithItems(User.Identity.Name)
            .FirstOrDefaultAsync();
        if (basket == null)
            return BadRequest(new ProblemDetails { Title = "ვერ ვიპოვე კალათა" });

        var items = new List<orderItem>();
        foreach (var item in basket.Items)
        {
            var productItem = await _context.ITEMS.FindAsync(item.ProductId);
            var itemOrdered = new productItemOrdered
            {
                ItemId = productItem.Id,
                Name = productItem.Short_Name,
                PictureUrl = productItem.Main_Photo
            };
            var orderItem = new orderItem
            {
                ItemOrdered = itemOrdered,
                Price = productItem.Price,
                Quantity = item.Quantity
            };
            items.Add(orderItem);
            productItem.Quantity -= item.Quantity;
        }
        var subtotal = items.Sum(item => item.Price * item.Quantity);
        var deliveryFee = subtotal > 1000 ? 0 : 500;
        var order = new order
        {
            Company_Id = ordervm.company_id,
            OrderItems = items,
            BuyerId = User.Identity.Name,
            ShippingAdress = ordervm.ShippingAdress,
            SubTotal = subtotal,
            DeliveryFee = deliveryFee
        };
        _context.ORDERS.Add(order);
        _context.BASKETS.Remove(basket);
        if (ordervm.SaveAdress)
        {
            var user = await _context.Users
                .Include(a => a.userAdress)
                .FirstOrDefaultAsync(x => x.UserName == User.Identity.Name);
            var adress = new userAdress
            {
                FullName = ordervm.ShippingAdress.FullName,
                Adress1 = ordervm.ShippingAdress.Adress1,
                Google_Map = ordervm.ShippingAdress.Google_Map,
                City = ordervm.ShippingAdress.City,
                State = ordervm.ShippingAdress.State,
                Phone_Number = ordervm.ShippingAdress.Phone_Number,
                EMail = ordervm.ShippingAdress.EMail
            };
            user.userAdress = adress;
        }
        var result = await _context.SaveChangesAsync() > 0;
        if (result)
            return CreatedAtRoute("GetOrder", new { id = order.Id }, order.Id);
        return BadRequest("რაღაც პრობლემა, გთხოვთ ცადოთ თავიდან");
    }

    [Authorize]
    [HttpGet("saveAdress")]
    public async Task<ActionResult<userAdress>> getSavedAdress()
    {
        return await _user.Users
            .Where(x => x.UserName == User.Identity.Name)
            .Select(user => user.userAdress)
            .FirstOrDefaultAsync();
    }
}
