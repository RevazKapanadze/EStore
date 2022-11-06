using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EStore.Data;
using EStore.Data.Models;
using EStore.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EStore.Controllers
{
  [ApiController]
  public class mainController : ControllerBase
  {

    private AppDbContext _context;
    private UserManager<user> _user;
    public mainController(AppDbContext context, UserManager<user> user) { _context = context; _user = user; }

    [HttpGet("Search_All_Items/{company_Id}/{searchString}")]
    public async Task<ActionResult<List<item>>> Search_All_Items(string OrderBy, int company_Id, string searchString)
    {
      var _query = _context.ITEMS.Where(o => o.Company_Id == company_Id || o.Is_Active == 1).AsQueryable();
      _query = OrderBy switch
      {
        "price" => _query.OrderBy(o => o.Price),
        "priceDesc" => _query.OrderBy(o => o.Price),
        _ => _query.OrderByDescending(p => p.Id)
      };
      return await _query.ToListAsync(); ;
    }
    [HttpGet("Get_All_Items/{company_Id}/{orderBy}")]
    public async Task<ActionResult<List<item>>> Get_All_Items(int company_Id, string orderBy, [FromQuery] List<string> orderSize)
    {
      var _query = _context.ITEMS.Where(o => o.Company_Id == company_Id && o.Is_Active == 1 && o.Quantity != 0).AsQueryable();
      _query = orderBy switch
      {
        "price" => _query.OrderBy(o => o.Price),
        "priceDesc" => _query.OrderBy(o => o.Price),
        _ => _query
      };
      var _items = await _query.OrderByDescending(p => p.Id).ToListAsync();
      var _query2 = _context.ITEM_DETAILS.Where(o => _items.Select(o => o.Id).ToList().Contains(o.Item_Id)).AsQueryable();
      _query2 = orderSize[0] switch
      {
        "0" => _query2,
        _ => _query2.Where(o => orderSize.Contains(o.Size))
      };
      var item2 = await _query2.ToListAsync();

      if (item2 == null)
      {
        return BadRequest("nothing in item details");
      }
      var _itemVm = _items.
          Where(o => item2.Select(o => o.Item_Id).ToList().Contains(o.Id)).
          Select(o => new
          {
            o.Id,
            o.Short_Name,
            o.Short_Description,
            o.Price,
            o.Quantity,
            o.Main_Category,
            o.Is_Active,
            o.Main_Photo,
            o.Company_Id,
            o.Category_Id
          }).ToList();
      //var _itemDetails = await _context.ITEMS.Where
      return Ok(_itemVm);
    }
    [HttpGet("Get_Company_Details/{company_Id}")]
    public async Task<ActionResult> GetCompanydetails(int company_Id)
    {
      var _company = await _context.COMPANY.Where(o => o.Id == company_Id).Select(o => new { o.Id, o.Company_Logo, o.Details, o.Name }).FirstOrDefaultAsync();
      return Ok(_company);
    }
    [HttpGet("Get_Item_Details/{item_Id}")]
    public async Task<ActionResult> GetItemDetails(int item_Id)
    {
      var _items = await _context.ITEM_DETAILS.Where(o => o.Item_Id == item_Id && o.Quantity > 0).ToListAsync();
      return Ok(_items);
    }
  }
}
