using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EStore.API.Data.Models
{
  public class company
  {
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Details { get; set; }
    public string Company_Logo { get; set; }
    public ICollection<item> items { get; set; }
    public ICollection<user> users { get; set; }

  }
}