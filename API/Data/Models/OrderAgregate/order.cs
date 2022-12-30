using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using API.Data.Models.OrderAgregate;
using EStore.API.Data.Models;

public class order
{
    public int Id { get; set; }
    public int Company_Id { get; set; }
    public company Company { get; set; }
    public string BuyerId { get; set; }
    public shippingAdress ShippingAdress { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public List<orderItem> OrderItems { get; set; }
    public decimal SubTotal { get; set; }
    public decimal DeliveryFee { get; set; }
    public orderStatus OrderStatus { get; set; } = orderStatus.Pending;

    public decimal GetTotal()
    {
        return SubTotal + DeliveryFee;
    }
}
