using System;
using System.Collections.Generic;
using System.Linq;
using EStore.API.Data;
using EStore.API.Data.Models;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace API.Extentions
{
  public static class ProductExtentions
  {
    public static IQueryable<item> Sort(this IQueryable<item> query, string orderBy)
    {
      if (string.IsNullOrWhiteSpace(orderBy)) return query.OrderByDescending(p => p.Id);
      query = orderBy switch
      {
        "price" => query.OrderBy(o => o.Price).ThenByDescending(p => p.Id),
        "priceDesc" => query.OrderByDescending(o => o.Price).ThenByDescending(p => p.Id),
        _ => query.OrderByDescending(p => p.Id)
      };
      return query;
    }
    public static IQueryable<item> Search(this IQueryable<item> query, string searchTerm)
    {
      if (string.IsNullOrWhiteSpace(searchTerm)) return query;
      var lowerCaseSearchTerm = searchTerm.Trim().ToLower();
      return query.Where(p => p.Short_Name.ToLower().Contains(lowerCaseSearchTerm) || p.Short_Description.ToLower().Contains(lowerCaseSearchTerm));
    }
    public static IQueryable<item> Filter(this IQueryable<item> query, string category_id, string main_category)
    {
      var category_idList = new List<string>();
      var category_idList2 = new List<int>();
      var main_categoryList = new List<string>();
      var main_categoryList2 = new List<int>();
      if (!string.IsNullOrEmpty(category_id))
        category_idList.AddRange(category_id.ToLower().Split(",").ToList());
      category_idList2 = category_idList.Select(s => int.Parse(s)).ToList();
      if (!string.IsNullOrEmpty(main_category))
        main_categoryList.AddRange(main_category.ToLower().Split(",").ToList());
      main_categoryList2 = main_categoryList.Select(s => int.Parse(s)).ToList();

      query = query.Where(p => category_idList2.Count == 0 || category_idList2.Contains(p.Category_Id));
      query = query.Where(p => main_categoryList2.Count == 0 || main_categoryList2.Contains(p.Main_Category));
      return query;
    }


  }
}