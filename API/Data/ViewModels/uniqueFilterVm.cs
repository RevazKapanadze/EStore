using System.Collections.Generic;

namespace EStore.API.Data.ViewModels
{
  public class uniqueFilterVm
  {
    public string Company_Name { get; set; }
    public string Company_Details { get; set; }
    public string Company_Logo { get; set; }
    public List<int> Category_Id { get; set; }
    public List<int> Main_Category { get; set; }
    public List<string> Size { get; set; }
    public List<string> Colour { get; set; }
    public decimal Max_Price { get; set; }
    public decimal Min_Price { get; set; }
    public bool IsSaleAvailable { get; set; }

  }
}