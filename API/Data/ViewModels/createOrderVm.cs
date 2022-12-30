namespace API.Data.ViewModels
{
    public class createOrderVm
    {
        public int company_id { get; set; }
        public bool SaveAdress { get; set; }
        public shippingAdress ShippingAdress { get; set; }
    }
}
