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
using Microsoft.Extensions.Logging;
namespace EStore.Controllers
{
  [ApiController]
  public class companyController : ControllerBase
  {
    private AppDbContext _context;
    private UserManager<user> _user;
    private logic _logic;
    public companyController(AppDbContext context, UserManager<user> user, logic logic)
    {
      _context = context;
      _user = user;
      _logic = logic;
    }
    [Authorize]
    [HttpPost("Add_Item")]
    public async Task<ActionResult> AddItem(itemVm _itemVm)
    {
      var user = await _user.FindByNameAsync(User.Identity.Name);
      var _item = new item
      {
        Short_Name = _itemVm.Short_Name,
        Short_Description = _itemVm.Short_Description,
        Price = _itemVm.Price,
        Quantity = 0,
        Is_Active = 0,
        Main_Photo = _itemVm.Main_Photo,
        Main_Category = await _context.CATEGORY.Where(o => o.Id == _itemVm.Category_Id).Select(o => o.mainCategory_Id).FirstOrDefaultAsync(),
        Category_Id = _itemVm.Category_Id,
        Company_Id = user.Company_Id
      };
      await _context.ITEMS.AddAsync(_item);
      await _context.SaveChangesAsync();
      return Ok(_item.Id);
    }
    [Authorize]
    [HttpPost("Add_Item_Photoes")]
    public async Task<ActionResult> AddItemPhotoes(itemPhotoesVm _itemPhotoesVm)
    {
      var user = await _user.FindByNameAsync(User.Identity.Name);
      var item = await _context.ITEMS.Where(o => o.Id == _itemPhotoesVm.Item_Id).FirstOrDefaultAsync();
      if (item.Company_Id != user.Company_Id)
      {
        return Unauthorized();
      }
      var _itemPhoto = new item_Photoes
      {
        Item_Id = _itemPhotoesVm.Item_Id,
        item_Logo = _itemPhotoesVm.item_Logo
      };
      await _context.ITEM_PHOTOES.AddAsync(_itemPhoto);
      await _context.SaveChangesAsync();
      return Ok();
    }
    [Authorize]
    [HttpPost("Add_Item_Details")]
    public async Task<ActionResult> AddItemDetails(itemDetailsVm _itemDetailsVm)
    {
      var user = await _user.FindByNameAsync(User.Identity.Name);
      var item = await _context.ITEMS.Where(o => o.Id == _itemDetailsVm.Item_Id).FirstOrDefaultAsync();
      if (item.Company_Id != user.Company_Id)
      {
        return Unauthorized();
      }
      var _itemDetails = new item_Details
      {
        Item_Id = _itemDetailsVm.Item_Id,
        Size=_itemDetailsVm.Size,
        Colour=_itemDetailsVm.Colour,
        Price=_itemDetailsVm.Price,
        Sale=0
      };
      await _context.ITEM_DETAILS.AddAsync(_itemDetails);
      await _context.SaveChangesAsync();
      return Ok();
    }
  }
}