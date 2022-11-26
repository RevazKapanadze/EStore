using System.Collections.Generic;

namespace EStore.API.Data.ViewModels
{
  public class basketVM
  {
    public int Id { get; set; }
    public string BuyerId { get; set; }
    public List<basketItemVM> Items { get; set; }
  }
}