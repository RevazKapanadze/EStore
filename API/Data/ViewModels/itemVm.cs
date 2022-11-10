namespace EStore.API.Data.ViewModels
{
  public class itemVm
  {
    
    public string Short_Name { get; set; }
    public string Short_Description { get; set; }
    public decimal Price { get; set; }
    public string Main_Photo { get; set; }
    //navigation
    public int Category_Id { get; set; }
  }
}