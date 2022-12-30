using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using API.Data.Models.OrderAgregate;
using EStore.API.Data.Models;

namespace API.Data.ViewModels
{
    public class orderVm
    {
        public int Id { get; set; }
        public int Company_Id { get; set; }
        public company Company { get; set; }
        public string BuyerId { get; set; }
        public shippingAdress ShippingAdress { get; set; }
        public DateTime OrderDate { get; set; }
        public List<orderItemVm> OrderItems { get; set; }
        public decimal SubTotal { get; set; }
        public decimal DeliveryFee { get; set; }
        public string OrderStatus { get; set; }
        public decimal Total { get; set; }
    }
}
