using System.Linq;
using EStore.API.Data.Models;
using EStore.API.Data.ViewModels;

public static class BasketExtentions
{
    public static basketVM MapbasketToVM(this basket basket)
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
