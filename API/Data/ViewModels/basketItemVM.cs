namespace EStore.API.Data.ViewModels
{
  public class basketItemVM
  {
    public long ProductId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string PictureUrl { get; set; }
    public int Main_Category { get; set; }
    public int Category { get; set; }
    public int Quantity { get; set; }
  }
}