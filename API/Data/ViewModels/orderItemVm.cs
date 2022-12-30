namespace API.Data.ViewModels
{
    public class orderItemVm
    {
        public long itemId { get; set; }
        public string Name { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
