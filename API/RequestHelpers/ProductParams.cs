namespace API.RequestHelpers
{
  public class ProductParams : PaginationParams
  {
    public int Company_Id { get; set; }
    public string OrderBy { get; set; }
    public string SearchTerm { get; set; }
    public string Category_id { get; set; }
    public string Main_category { get; set; }
    public string size { get; set; }
    public string color { get; set; }

  }
}