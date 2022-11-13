using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EStore.API.Data;
using EStore.API.Data.Models;
using EStore.API.Data.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EStore.Controllers
{
  [ApiController]
  public class mainController : ControllerBase
  {

    private AppDbContext _context;
    private UserManager<user> _user;
    public mainController(AppDbContext context, UserManager<user> user) { _context = context; _user = user; }

    [HttpGet("Search_All_Items/{company_Id}")]
    public async Task<ActionResult<List<item>>> Search_All_Items(string OrderBy, int company_Id)
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
    public async Task<ActionResult<List<item>>> Get_All_Items(int company_Id, [FromQuery] List<string> orderSize, string orderBy = "_")
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
      var _company = await _context.COMPANY
      .Where(o => o.Id == company_Id)
      .Select(o => new { o.Id, o.Company_Logo, o.Details, o.Name })
      .FirstOrDefaultAsync();
      return Ok(_company);
    }
    [HttpGet("Get_Item_Details/{item_Id}")]
    public async Task<ActionResult> GetItemDetails(int item_Id)
    {
      var _items = await _context.ITEM_DETAILS
      .Where(o => o.Item_Id == item_Id)
      .ToListAsync();
      var _items2 = _items.Select(o => new { o.Id, o.Size, o.Price, o.Quantity, o.Colour, o.Sale }).ToList();
      return Ok(_items2);
    }
    [HttpGet("Get_Company_Unique_Filters/{company_Id}")]
    public async Task<ActionResult> GetUniqueFilters(int company_Id)
    {
      // uniqueFilterVm uniqueFilters;
      var _item = await _context.ITEMS.Where(o => o.Company_Id == company_Id && o.Is_Active == 1).ToListAsync();
      var _item_Details = await _context.ITEM_DETAILS.Where(u => _item.Select(o => o.Id).ToList().Contains(u.Item_Id)).ToListAsync();
      var _company_Details = await _context.COMPANY.Where(i => i.Id == company_Id).FirstOrDefaultAsync();

      var uniqueFilters = new uniqueFilterVm
      {
        Company_Name = _company_Details.Name,
        Company_Details = _company_Details.Details,
        Company_Logo = _company_Details.Company_Logo,
        Max_Price = _item_Details.Select(o => o.Price).Max(),
        Min_Price = _item_Details.Select(o => o.Price).Min(),
        IsSaleAvailable = _item_Details.Select(o => o.Sale).Max() > 0 ? true : false,
        Category_Id = _item.Select(o => o.Category_Id).Distinct().ToList(),
        Main_Category = _item.Select(o => o.Main_Category).Distinct().ToList(),
        Size = _item_Details.Select(o => o.Size).Distinct().ToList(),
        Colour = _item_Details.Select(o => o.Colour).Distinct().ToList()
      };
      return Ok(uniqueFilters);
    }
    [HttpGet("Get_All_Companies")]
    public async Task<ActionResult> GetAllCompanies()
    {
      var _companies = await _context.COMPANY.Select(o => new { o.Id, o.Company_Logo, o.Details, o.Name }).ToListAsync();
      return Ok(_companies);
    }
    [HttpGet("Get_All_Items")]
    public async Task<ActionResult> Get_All_items()
    {
      var items = await _context.ITEMS.Select(o => new
      {
        o.Id,
        o.Short_Name,
        o.Short_Description,
        o.Price,
        o.Quantity,
        o.Main_Category,
        o.Is_Active,
        o.Main_Photo,
        o.Category_Id,
        o.Company_Id
      }).ToListAsync();
      return Ok(items);
    }
    [HttpGet("Get_Item_By_Id/{Item_Id}")]
    public async Task<ActionResult> Get_Item_By_Id(int Item_Id)
    {
      var items = await _context.ITEMS.Select(o => new
      {
        o.Id,
        o.Short_Name,
        o.Short_Description,
        o.Price,
        o.Quantity,
        o.Main_Category,
        o.Is_Active,
        o.Main_Photo,
        o.Category_Id,
        o.Company_Id
      }).Where(o => o.Id == Item_Id).FirstOrDefaultAsync();
      return Ok(items);
    }
  }
}
