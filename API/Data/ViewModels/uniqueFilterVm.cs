using System.Collections.Generic;

namespace EStore.API.Data.ViewModels
{
  public class uniqueFilterVm
  {

    public List<int> Category_Id { get; set; }
    public List<int> Main_Category { get; set; }
    public List<string> Size { get; set; }
    public List<string> Colour { get; set; }


  }
}