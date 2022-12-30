namespace API.Data.Models.OrderAgregate
{
    public class orderItem
    {
        public int Id { get; set; }
        public productItemOrdered ItemOrdered { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
