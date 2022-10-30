using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EStore.Data.Models
{
  public class mainCategory
  {
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<category> category { get; set; }
  }
}