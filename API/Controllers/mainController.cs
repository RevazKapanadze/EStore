using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EStore.API.Data;
using EStore.API.Data.Models;
using EStore.API.Data.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Controllers;
using API.Extentions;
using API.RequestHelpers;
using Newtonsoft.Json;
using Microsoft.OpenApi.Any;
using System.IdentityModel.Tokens.Jwt;

namespace EStore.Controllers
{
  [ApiController]
  public class mainController : baseApiContoller
  {

    private AppDbContext _context;
    private UserManager<user> _user;
    public mainController(AppDbContext context, UserManager<user> user) { _context = context; _user = user; }
    [HttpGet("Get_All_Items")]
    public async Task<ActionResult<PagedList<item>>> Get_All_Items([FromQuery] ProductParams productParams)
    {
      var sizeList = new List<string>();
      var colorList = new List<string>();
      if (!string.IsNullOrEmpty(productParams.size))
        sizeList.AddRange(productParams.size.ToLower().Split(",").ToList());
      if (!string.IsNullOrEmpty(productParams.color))
        colorList.AddRange(productParams.color.ToLower().Split(",").ToList());
      var _query = _context.ITEMS
      .Where(c => c.Company_Id == productParams.Company_Id && c.Is_Active == 1)
       .Where(u => _context.ITEM_DETAILS
        .Where(i =>
          i.Item_Id == u.Id
        && (sizeList.Count == 0 || sizeList.Contains(i.Size))
        && (colorList.Count == 0 || colorList.Contains(i.Colour))
        )
        .Select(o => o.Item_Id).ToList().Contains(u.Id)
        )
      .Sort(productParams.OrderBy)
      .Search(productParams.SearchTerm)
      .Filter(productParams.Category_id, productParams.Main_category)
      .AsQueryable();
      var items = await PagedList<item>
      .ToPagedList(_query, productParams.PageNumber, productParams.PageSize);
      Response.AddPaginationHeader(items.MetaData);
      return items;
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
    public async Task<IActionResult> GetUniqueFilters(int company_Id)
    {
      // uniqueFilterVm uniqueFilters;
      var _item = await _context.ITEMS.Where(o => o.Company_Id == company_Id && o.Is_Active == 1).ToListAsync();
      var _item_Details = await _context.ITEM_DETAILS.Where(u => _item.Select(o => o.Id).ToList().Contains(u.Item_Id)).ToListAsync();
      var _company_Details = await _context.COMPANY.Where(i => i.Id == company_Id).FirstOrDefaultAsync();

      var uniqueFilters = new uniqueFilterVm
      {
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
    /*
    [HttpGet("Get_All_Items1")]
    public async Task<ActionResult> Get_All_items(string size, string color)
    {
      var sizeList = new List<string>();
      var colorList = new List<string>();
      if (!string.IsNullOrEmpty(size))
        sizeList.AddRange(size.ToLower().Split(",").ToList());
      if (!string.IsNullOrEmpty(color))
        colorList.AddRange(color.ToLower().Split(",").ToList());

      var items = await _context.ITEMS
        .Where(u => _context.ITEM_DETAILS
        .Where(i =>
          i.Item_Id == u.Id
        && (sizeList.Count == 0 || sizeList.Contains(i.Size))
        && (colorList.Count == 0 || colorList.Contains(i.Colour))
        )
        .Select(o => o.Item_Id).ToList().Contains(u.Id)
        )
        .ToListAsync();
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
        }*/
  }
}
