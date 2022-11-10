using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EStore.API.Data.Models
{
  public class category
  {
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    //navigation prop
    public int mainCategory_Id { get; set; }
    public mainCategory mainCategory { get; set; }
    public ICollection<item> item { get; set; }
    
  }
}