using System;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using EStore.API.Data.Models;
using EStore.API.Data.ViewModels;
using Microsoft.EntityFrameworkCore;

public static class BasketExtentions
{
    public static basketVM MapbasketToVM(this basket basket)
    {
        if (basket == null)
        {
            return null;
        }
        else
        {
            return new basketVM
            {
                Id = basket.Id,
                BuyerId = basket.BuyerId,
                Items = basket.Items
                    .Select(
                        item =>
                            new basketItemVM
                            {
                                ProductId = item.ProductId,
                                Name = item.Product.Short_Name,
                                Price = item.Product.Price,
                                PictureUrl = item.Product.Main_Photo,
                                Category = item.Product.Category_Id,
                                Main_Category = item.Product.Main_Category,
                                Quantity = item.Quantity
                            }
                    )
                    .ToList()
            };
        }
    }

    public static IQueryable<basket> RetriveBasketWithItems(
        this IQueryable<basket> query,
        string BuyerId
    ) {
        return query.Include(i=>i.Items).ThenInclude(p=>p.Product).Where(b=>b.BuyerId==BuyerId);
     }
}
