using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EStore.Data.Models
{
  public class item_Photoes
  {
    [Key]
    public long Id { get; set; }
    public string item_Logo { get; set; }
    public long Item_Id { get; set; }
    [ForeignKey("Id")]
    public item item { get; set; }
  }
}