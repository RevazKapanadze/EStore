using System.Data.Common;
using System.Linq;
using API.Data.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace API.Extentions
{
    public static class orderExtentions
    {
        public static IQueryable<orderVm> projectOrderToOrderVm(this IQueryable<order> query)
        {
            return query
                .Select(
                    order =>
                        new orderVm
                        {
                            Id = order.Id,
                            Company_Id = order.Company_Id,
                            BuyerId = order.BuyerId,
                            ShippingAdress = order.ShippingAdress,
                            OrderDate = order.OrderDate,
                            SubTotal = order.SubTotal,
                            DeliveryFee = order.DeliveryFee,
                            OrderStatus = order.OrderStatus.ToString(),
                            Total = order.GetTotal(),
                            OrderItems = order.OrderItems
                                .Select(
                                    item =>
                                        new orderItemVm
                                        {
                                            itemId = item.ItemOrdered.ItemId,
                                            Name = item.ItemOrdered.Name,
                                            PictureUrl = item.ItemOrdered.PictureUrl,
                                            Price = item.Price,
                                            Quantity = item.Quantity
                                        }
                                )
                                .ToList()
                        }
                )
                .AsNoTracking();
        }

       
    }
}
